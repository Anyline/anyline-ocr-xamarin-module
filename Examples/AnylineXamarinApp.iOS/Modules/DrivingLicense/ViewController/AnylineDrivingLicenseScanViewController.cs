using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.DrivingLicense.ViewController
{
    public sealed class AnylineDrivingLicenseScanViewController : UIViewController, IAnylineOCRModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineOCRModuleView _scanView;
        DrivingLicenseResultOverlayView _drivingLicenseResultView;

        ALOCRConfig _ocrConfig;
        
        NSError _error;
        bool _success;
        bool _isScanning;
        public UIAlertView Alert { get; private set; }

        public AnylineDrivingLicenseScanViewController(string name)
        {
            Title = name;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            // Initializing the Driving License module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _scanView = new AnylineOCRModuleView(frame);

            // We'll define the OCR Config here:
            _ocrConfig = new ALOCRConfig();
            
            string engTraineddata = NSBundle.MainBundle.PathForResource(@"Modules/OCR/eng_no_dict", @"traineddata");
            string deuTraineddata = NSBundle.MainBundle.PathForResource(@"Modules/OCR/deu", @"traineddata");
            _ocrConfig.Languages = new[] { engTraineddata, deuTraineddata };

            _ocrConfig.CustomCmdFilePath = NSBundle.MainBundle.PathForResource(@"Modules/DrivingLicense/anyline_austrian_driving_license", @"ale");

            // We tell the module to bootstrap itself with the license key and delegate. The delegate will later get called
            // by the module once we start receiving results.
            _error = null;
            _success = _scanView.SetupWithLicenseKey(_licenseKey, Self, _ocrConfig, out _error);
            // SetupWithLicenseKey:delegate:error returns true if everything went fine. In the case something wrong
            // we have to check the error object for the error message.
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            // We stop scanning manually
            _scanView.CancelOnResult = false;

            // We load the UI config for our DrivingLicense view from a .json file.
            string configFile = NSBundle.MainBundle.PathForResource(@"Modules/DrivingLicense/drivinglicense_capture_config", @"json");
            _scanView.CurrentConfiguration = ALUIConfiguration.CutoutConfigurationFromJsonFile(configFile);
            
            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_scanView);

            /*
             The following view will present the scanned values. Here we start listening for taps
             to later dismiss the view.
             */             
            _drivingLicenseResultView = new DrivingLicenseResultOverlayView(new CGRect(0, 0, View.Frame.Width, View.Frame.Height));
            //new CGRect(0, 0, View.Frame.Width, View.Frame.Width / 1.4));

            _drivingLicenseResultView.AddGestureRecognizer(new UITapGestureRecognizer(this, new ObjCRuntime.Selector("ViewTapSelector:")));

            _drivingLicenseResultView.Center = View.Center;
            _drivingLicenseResultView.Alpha = 0;
            
            View.AddSubview(_drivingLicenseResultView);
        }

        /*
         Dismiss the view if the user taps the screen
         */
        [Export("ViewTapSelector:")]
        private void AnimateFadeOut(UIGestureRecognizer sender)
        {
            _drivingLicenseResultView?.AnimateFadeOut(View, StartAnyline);
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
            View.SendSubviewToBack(_drivingLicenseResultView);

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

            if (_drivingLicenseResultView == null || _scanView == null) return;

            _error = null;
            if (!_scanView.CancelScanningAndReturnError(out _error))
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            View.BringSubviewToFront(_drivingLicenseResultView);
            
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

            //remove result view
            _drivingLicenseResultView?.RemoveFromSuperview();
            _drivingLicenseResultView?.Dispose();
            _drivingLicenseResultView = null;

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            
            base.Dispose();
            
        }

        /*
        This is the main delegate method Anyline uses to report its results
        */
        void IAnylineOCRModuleDelegate.DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result)
        {
            StopAnyline();
            if (_drivingLicenseResultView != null)
                View.BringSubviewToFront(_drivingLicenseResultView);

            string[] comps = result.Result.ToString().Split('|');

            string name = comps[0];
            string birthdateID = comps[1];

            string[] nameComps = name.Split(' ');

            switch(nameComps.Length)
            {
                case 0:
                    break;
                case 1:
                    _drivingLicenseResultView.Surname.Text = nameComps[0];
                    _drivingLicenseResultView.Surname2.Text = "";
                    _drivingLicenseResultView.GivenNames.Text = "";
                    break;
                case 2:
                    _drivingLicenseResultView.Surname.Text = nameComps[0];
                    _drivingLicenseResultView.Surname2.Text = "";
                    _drivingLicenseResultView.GivenNames.Text = nameComps[1];
                    break;
                case 3:
                    _drivingLicenseResultView.Surname.Text = nameComps[0];
                    _drivingLicenseResultView.Surname2.Text = nameComps[1];
                    _drivingLicenseResultView.GivenNames.Text = nameComps[2];
                    break;
                default:
                    break;
            }

            string[] birthdateIDComps = birthdateID.Split(' ');

            string birthday = birthdateIDComps[0];

            NSDateFormatter formatter = new NSDateFormatter();
            formatter.DateFormat = @"ddMMyyyy";

            NSDate date = formatter.Parse(birthday);

            if (date == null)
            {
                formatter.DateFormat = @"yyyyMMdd";
                date = formatter.Parse(birthday);
            }

            formatter.DateFormat = @"yyyy-MM-dd";
            _drivingLicenseResultView.Birthdate.Text = formatter.StringFor(date);
            _drivingLicenseResultView.IDNumber.Text = birthdateIDComps[1];

            // Present the information to the user
            _drivingLicenseResultView?.AnimateFadeIn(View);            
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
