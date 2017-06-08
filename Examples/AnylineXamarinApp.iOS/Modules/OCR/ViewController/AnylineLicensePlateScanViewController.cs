using System;
using CoreGraphics;
using Foundation;
using UIKit;

using AnylineXamarinSDK.iOS;

namespace AnylineXamarinApp.iOS.Modules.OCR.ViewController
{
    public class AnylineLicensePlateScanViewController : UIViewController, IAnylineOCRModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineOCRModuleView _scanView;
        ResultOverlayView _resultView;

        protected ALOCRConfig OcrConfig;
        
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

        public virtual void SetupLicensePlateConfig()
        {
            // We'll define the OCR Config here:
            OcrConfig = new ALOCRConfig
            {
                CustomCmdFilePath = NSBundle.MainBundle.PathForResource(@"Modules/OCR/license_plates", @"ale")
            };
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the Voucher Code module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _scanView = new AnylineOCRModuleView(frame);

            SetupLicensePlateConfig();

            // important: set up the scanView with the license key BEFORE calling CopyTrainedData, else it will fail!

            // We tell the module to bootstrap itself with the license key and delegate. The delegate will later get called
            // by the module once we start receiving results.
            _error = null;
            _success = _scanView.SetupWithLicenseKey(_licenseKey, Self, OcrConfig, out _error);
            // SetupWithLicenseKey:delegate:error returns true if everything went fine. In the case something wrong
            // we have to check the error object for the error message.
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            // We'll copy the required traineddata files here
            _error = null;
            _success = _scanView.CopyTrainedData(NSBundle.MainBundle.PathForResource(@"Modules/OCR/Alte", @"traineddata"),
                @"f52e3822cdd5423758ba19ed75b0cc32", out _error);
            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            _error = null;
            _success = _scanView.CopyTrainedData(NSBundle.MainBundle.PathForResource(@"Modules/OCR/Arial", @"traineddata"),
                @"9a5555eb6ac51c83cbb76d238028c485", out _error);
            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            _error = null;
            _success = _scanView.CopyTrainedData(NSBundle.MainBundle.PathForResource(@"Modules/OCR/GL-Nummernschild-Mtl7_uml", @"traineddata"),
                @"8ea050e8f22ba7471df7e18c310430d8", out _error);
            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            
            // We stop scanning manually
            _scanView.CancelOnResult = false;

            // We load the UI config for our VoucherCode view from a .json file.
            string configFile = NSBundle.MainBundle.PathForResource(@"Modules/OCR/license_plate_view_config", @"json");
            _scanView.CurrentConfiguration = ALUIConfiguration.CutoutConfigurationFromJsonFile(configFile);
            _scanView.TranslatesAutoresizingMaskIntoConstraints = false;

            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_scanView);

            /*
             The following view will present the scanned values. Here we start listening for taps
             to later dismiss the view.
             */
            _resultView = new ResultOverlayView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height), UIImage.FromBundle(@"drawable/license_plate_background.png"));
            _resultView.AddGestureRecognizer(new UITapGestureRecognizer(this, new ObjCRuntime.Selector("ViewTapSelector:")));

            _resultView.Center = View.Center;
            _resultView.Alpha = 0;

            _resultView.Result.Center = new CGPoint(View.Center.X, View.Center.Y);
            _resultView.Result.Font = UIFont.BoldSystemFontOfSize(27);
            _resultView.Result.TextColor = UIColor.Black;

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

            //remove result view
            _resultView?.RemoveFromSuperview();
            _resultView?.Dispose();
            
            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();

            Dispose();
        }


        /*
        This is the main delegate method Anyline uses to report its results
        */
        void IAnylineOCRModuleDelegate.DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result)
        {
            
            StopAnyline();
            View.BringSubviewToFront(_resultView);

            var text = result.Text.Split('-');
            if (text.Length > 1 && text[0] != "")
                _resultView.UpdateResult(result.Text);
            else
                _resultView.UpdateResult(result.Text.Split('-')[1]);            
            
            // Present the information to the user
            _resultView.AnimateFadeIn(View);
        }

        void IAnylineOCRModuleDelegate.ReportsRunFailure(AnylineOCRModuleView anylineOCRModuleView, ALOCRError error)
        {
            switch (error)
            {
                case ALOCRError.ConfidenceNotReached:
                    Console.WriteLine("Confidence not reached.");
                    break;
                case ALOCRError.NoLinesFound:
                    Console.WriteLine("No lines found.");
                    break;
                case ALOCRError.NoTextFound:
                    Console.WriteLine("No text found.");
                    break;
                case ALOCRError.ResultNotValid:
                    Console.WriteLine("Result is not valid.");
                    break;
                case ALOCRError.SharpnessNotReached:
                    Console.WriteLine("Sharpness is not reached.");
                    break;
                case ALOCRError.Unkown:
                    Console.WriteLine("Unknown run error.");
                    break;
            }
        }

        void IAnylineOCRModuleDelegate.ReportsVariable(AnylineOCRModuleView anylineOCRModuleView, string variableName, NSObject value) { }

        bool IAnylineOCRModuleDelegate.TextOutlineDetected(AnylineOCRModuleView anylineOCRModuleView, ALSquare outline) { return false; }
    }
}
