using System;
using AnylineXamarinApp.iOS.Modules.Document.View;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Document.ViewController
{
    public sealed class AnylineDocumentScanViewController : UIViewController, IAnylineDocumentModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineDocumentModuleView _scanView;
        NotificationView _notificationView;
        UIImage _resultImage;

        bool _showingNotification;
        bool _keepScanViewControllerAlive;
        bool _disposing;

        NSError _error;
        bool _success;
        private UIAlertView _alert { get; set; }
        
        public AnylineDocumentScanViewController(string name)
        {
            Title = name;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the Document scan module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _scanView = new AnylineDocumentModuleView(frame);

            NSError e;
            string date = ALCoreController.LicenseExpirationDateForLicense(AnylineViewController.LicenseKey, out e);

            Console.WriteLine("Date: " + date);

            // We tell the module to bootstrap itself with the license key and delegate. The delegate will later get called
            // by the module once we start receiving results.
            _error = null;
            _success = _scanView.SetupWithLicenseKey(_licenseKey, Self, out _error);
            // SetupWithLicenseKey:delegate:error returns true if everything went fine. In the case something wrong
            // we have to check the error object for the error message.
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            //stop scanning on result
            _scanView.CancelOnResult = true;

            // to set certain supported ratios, they can be provided as follows:
            //NSNumber[] ratios = { DocumentRatio.BusinessCardLandscape, DocumentRatio.DINAXLandscape };
            //_scanView.SetDocumentRatios(ratios);

            // you can set the max output resolution of your image here so it will be scaled to a desired size
            //_scanView.MaxOutputResolution = new CGSize(width, height);

            // you can set post processing to enabled here
            _scanView.PostProcessingEnabled = true;

            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_scanView);

            // This view notifies the user of any problems that occur while scanning
            _notificationView = new NotificationView(new CGRect(20, 115, View.Bounds.Width - 40, 30));
            _notificationView.FillColor = new UIColor((nfloat)(98.0 / 255.0), (nfloat)(39.0 / 255.0), (nfloat)(232.0 / 255.0), (nfloat)(0.6)).CGColor;
            _notificationView.TextLabel.Text = "";
            _notificationView.Alpha = 0;
            View.Add(_notificationView);

        }

        /*
         This method will be called once the view controller and its subviews have appeared on screen
         */
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            //we want to kill the controller if we navigate back to the previous viewcontroller
            _keepScanViewControllerAlive = false;

            // We use this subroutine to start Anyline. The reason it has its own subroutine is
            // so that we can later use it to restart the scanning process.
            StartAnyline();
        }

        public void StartAnyline()
        {
            if (_scanView == null) return;
            _error = null;
            _success = _scanView.StartScanningAndReturnError(out _error);
            if (!_success)
            {
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            // We have to stop scanning before the view dissapears
            _error = null;
            _scanView?.CancelScanningAndReturnError(out _error);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            //don't clean up objects, if we want the controller to be kept alive
            if (_keepScanViewControllerAlive)
                return;

            _disposing = true;

            Dispose();
        }

        new void Dispose()
        {
            //un-register any event handlers here, if you have any

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.

            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;

            _resultImage?.Dispose();
            _resultImage = null;
            
            base.Dispose();
        }

        /*
         A little helper method to show live scanning errors.
         */
        private void ShowNotification<T>(T info)
        {

            if (_disposing) return;
            if (_notificationView == null) return;

            var txt = "";

            if (typeof(T) == typeof(ALDocumentError))
            {
                ALDocumentError error = (ALDocumentError)Convert.ChangeType(info, typeof(ALDocumentError));
                switch (error)
                {
                    case ALDocumentError.ImageTooDark:
                        txt = "Too dark";
                        break;
                    case ALDocumentError.NotSharp:
                        txt = "Document not sharp";
                        break;
                    case ALDocumentError.ShakeDetected:
                        txt = "Shake detected";
                        break;
                    case ALDocumentError.SkewTooHigh:
                        txt = "Wrong perspective";
                        break;                    
                }
            }

            if (typeof(T) == typeof(string))
            {
                txt = Convert.ChangeType(info, typeof(string)) as string;
            }

            if (_showingNotification || txt == null || txt.Equals(""))
                return;

            if (_notificationView == null)
                return;

            _showingNotification = true;
            
            _notificationView.TextLabel.Text = txt;
            
            //fade in
            UIView.Animate(0.8, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
            {
                _notificationView.Alpha = 1;
            }, () => //fade out
            {
                UIView.Animate(0.8, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
                {
                    _notificationView.Alpha = 0;
                }, () => { _showingNotification = false; });
            });
            
        }
        
        /*
         * Called if a full result is found. A full result is considered to be a successful preview, folloewd by a successful full scan.
         */
        void IAnylineDocumentModuleDelegate.HasResult(AnylineDocumentModuleView anylineDocumentModuleView, UIImage transformedImage, UIImage fullFrame, ALSquare corners)
        {
            if (_disposing) return;

            if (_scanView == null) return;

            //we'll go to a temporary new view controller, so we keep this one alive
            _keepScanViewControllerAlive = true;

            _resultImage = transformedImage;

            using (var vc = new UIViewController())
            {
                var iv = new UIImageView(_scanView.Frame)
                {
                    Image = _resultImage,
                    ContentMode = UIViewContentMode.ScaleAspectFit
                };
                vc.View.AddSubview(iv);

                NavigationController?.PushViewController(vc, true);
            }

            fullFrame?.Dispose();
            transformedImage?.Dispose();
        }
        
        /*
         Called if the preview run failed on an image. The error is provided, and the next run is started automatically.
         */
        void IAnylineDocumentModuleDelegate.ReportsPreviewProcessingFailure(AnylineDocumentModuleView anylineDocumentModuleView, ALDocumentError error)
        {
            ShowNotification(error);
        }

        /*
         Called if the run on the full frame was unsuccessful. The scanning process automatically starts again with a preview scan.
         */
        void IAnylineDocumentModuleDelegate.ReportsPictureProcessingFailure(AnylineDocumentModuleView anylineDocumentModuleView, ALDocumentError error)
        {
            ShowNotification(error);
        }

        /*
         * Called if the preview scan detected a sharp and correctly placed document.
         * After this callback, a full frame scan of the document starts automatically.
         */
        void IAnylineDocumentModuleDelegate.ReportsPreviewResult(AnylineDocumentModuleView anylineDocumentModuleView, UIImage image)
        {
            _showingNotification = false;
            ShowNotification("Processing.. Please hold still.");
        }

        void IAnylineDocumentModuleDelegate.TakePictureError(AnylineDocumentModuleView anylineDocumentModuleView, NSError error)
        {
            _showingNotification = false;
            ShowNotification("Failed to take picture.");
        }

        /*
         * Return true if your implementation consumed the outline (e.g. drew the outline), or false if the DocumentScanView should draw the outline.
         */
        bool IAnylineDocumentModuleDelegate.DocumentOutlineDetected(AnylineDocumentModuleView anylineDocumentModuleView, NSObject[] outline, bool anglesValid)
        {
            return false;
        }

        /*
         * The taken picture will be processed after this method call.
         */
        void IAnylineDocumentModuleDelegate.TakePictureSuccess(AnylineDocumentModuleView anylineDocumentModuleView)
        {
            
        }

        /*
         * Will be called when AnylineDocumentModuleView.TriggerPictureCornerDetectionAndReturnError is invoked.
         */
        void IAnylineDocumentModuleDelegate.DetectedPictureCorners(AnylineDocumentModuleView anylineDocumentModuleView, ALSquare corners, UIImage image)
        {

        }
    }
}
