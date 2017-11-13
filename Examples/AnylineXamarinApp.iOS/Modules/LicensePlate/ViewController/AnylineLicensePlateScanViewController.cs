using System;
using CoreGraphics;
using Foundation;
using UIKit;

using AnylineXamarinSDK.iOS;

namespace AnylineXamarinApp.iOS.Modules.LicensePlate.ViewController
{
    public class AnylineLicensePlateScanViewController : UIViewController, IAnylineLicensePlateModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineLicensePlateModuleView _scanView;
        LicensePlateResultOverlayView _resultView;
        
        NSError _error;
        bool _success;
        bool _isScanning;
        public UIAlertView Alert { get; private set; }

        private void SetTitle(string title)
        {
            Title = title;
        }

        public AnylineLicensePlateScanViewController(string name)
        {
            SetTitle(name);
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the License Plate module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _scanView = new AnylineLicensePlateModuleView(frame);
            
            // important: set up the scanView with the license key BEFORE calling CopyTrainedData, else it will fail!

            // We tell the module to bootstrap itself with the license key and delegate. The delegate will later get called
            // by the module once we start receiving results.
            _error = null;
            _success = _scanView.SetupWithLicenseKey(_licenseKey, Self, out _error);
            // SetupWithLicenseKey:delegate:error returns true if everything went fine. In the case something wrong
            // we have to check the error object for the error message.
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
                        
            // We stop scanning manually
            _scanView.CancelOnResult = false;
            
            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_scanView);

            /*
             The following view will present the scanned values. Here we start listening for taps
             to later dismiss the view.
             */
            _resultView = new LicensePlateResultOverlayView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height), UIImage.FromBundle(@"drawable/license_plate_background.png"));
            _resultView.AddGestureRecognizer(new UITapGestureRecognizer(this, new ObjCRuntime.Selector("ViewTapSelector:")));

            _resultView.Center = View.Center;
            _resultView.Alpha = 0;

            _resultView.Result.Center = new CGPoint(View.Center.X, View.Center.Y);
            _resultView.Result.Font = UIFont.BoldSystemFontOfSize(27);
            _resultView.Result.TextColor = UIColor.Black;

            _resultView.Country.Center = new CGPoint(View.Center.X - 136, View.Center.Y + 13);
            _resultView.Country.Font = UIFont.BoldSystemFontOfSize(16);
            _resultView.Country.TextColor = UIColor.White;

            View.AddSubview(_resultView);
        }

        /*
         Dismiss the view if the user taps the screen
         */
        [Export("ViewTapSelector:")]
        private void AnimateFadeOut(UIGestureRecognizer sender)
        {
            _resultView.AnimateFadeOut(this.View, StartAnyline);
        }

        /*
         This method will be called once the view controller and its subviews have appeared on screen
         */
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
            // We use this subroutine to start Anyline. The reason it has its own subroutine is
            // so that we can later use it to restart the scanning process.
            StartAnyline();
        }

        public void StartAnyline()
        {
            if (_isScanning) return;

            //send the result view to the back before we start scanning
            View.SendSubviewToBack(_resultView);

            _error = null;
            _success = _scanView.StartScanningAndReturnError(out _error);
            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            else
                _isScanning = true;
        }

        public void StopAnyline()
        {
            if (!_isScanning) return;
            _isScanning = false;

            if (_scanView == null) return;

            _error = null;
            _scanView.CancelScanningAndReturnError(out _error);
            
            View.BringSubviewToFront(_resultView);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            // We have to stop scanning before the view dissapears
            StopAnyline();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            
            Dispose();
        }

        new void Dispose()
        {
            //un-register any event handlers here, if you have any

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.

            //remove result view
            _resultView?.RemoveFromSuperview();
            _resultView?.Dispose();
            _resultView = null;

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;

            GC.Collect(GC.MaxGeneration);

            base.Dispose();
        }

        /*
        This is the main delegate method Anyline uses to report its results
        */
        void IAnylineLicensePlateModuleDelegate.DidFindResult(AnylineLicensePlateModuleView anylineLicensePlateModuleView, ALLicensePlateResult scanResult)
        {
            StopAnyline();
            if (_resultView != null)
                View.BringSubviewToFront(_resultView);

            var country = scanResult.Country;
            var textResult = scanResult.Result.ToString();
            
            _resultView?.UpdateResult(textResult);
            _resultView?.UpdateCountry(country);
        
            // Present the information to the user
            _resultView?.AnimateFadeIn(View);
        }
    }
}
