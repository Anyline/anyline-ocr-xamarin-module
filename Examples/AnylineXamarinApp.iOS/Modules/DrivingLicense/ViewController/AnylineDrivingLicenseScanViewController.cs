using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.DrivingLicense.ViewController
{
    public sealed class AnylineDrivingLicenseScanViewController : UIViewController, IALIDPluginDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        ALScanView _scanView;
        DrivingLicenseResultOverlayView _drivingLicenseResultView;
        ALIDScanViewPlugin _scanViewPlugin;
        ALIDScanPlugin _scanPlugin;
        
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
            
            _error = null;
            _scanPlugin = new ALIDScanPlugin("ModuleID", _licenseKey, Self, new ALDrivingLicenseConfig(), out _error);
            _scanViewPlugin = new ALIDScanViewPlugin(_scanPlugin);

            if (_error != null)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            _scanView = new ALScanView(frame, _scanViewPlugin);

            _scanView.FlashButtonConfig.FlashAlignment = ALFlashAlignment.TopLeft;
            
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

            _scanView.StartCamera();
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
            if (_scanView == null) return;
            if (_isScanning) return;

            //send the result view to the back before we start scanning
            View.SendSubviewToBack(_drivingLicenseResultView);

            _error = null;
            _success = _scanViewPlugin.StartAndReturnError(out _error);
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
            if (!_scanViewPlugin.StopAndReturnError(out _error))
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
        void IAnylineOCRModuleDelegate.DidFindResult(AnylineOCRModuleView anylineOCRModuleView, ALOCRResult result)
        {
            StopAnyline();
            if (_drivingLicenseResultView != null)
                View.BringSubviewToFront(_drivingLicenseResultView);

            string[] comps = result.Result.ToString().Split('|');

            string surNames = comps[0];
            string givenNames = comps[1];
            string birthdateID = comps[2];
            string idNumber = comps[3];

            string[] surNamesComps = surNames.Split(' ');

            if (surNamesComps.Length == 2)
            {
                _drivingLicenseResultView.Surname.Text = surNamesComps[0];
                _drivingLicenseResultView.Surname2.Text = surNamesComps[1];
                _drivingLicenseResultView.GivenNames.Text = givenNames;
            }
            else
            {
                _drivingLicenseResultView.Surname.Text = surNamesComps[0];
                _drivingLicenseResultView.GivenNames.Text = givenNames;
                _drivingLicenseResultView.Surname2.Text = "";
            }
            
            string[] birthdateIDComps = birthdateID.Split(' ');

            string birthday = birthdateIDComps[0];
            
            _drivingLicenseResultView.Birthdate.Text = birthday;
            _drivingLicenseResultView.IDNumber.Text = idNumber;

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
        */

        /*
        This is the main delegate method Anyline uses to report its results
        */
        public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        {
            StopAnyline();
            if (_drivingLicenseResultView != null)
                View.BringSubviewToFront(_drivingLicenseResultView);

            var result = scanResult.Result as ALDrivingLicenseIdentification;
            
            string[] surNamesComps = result.SurNames.Split(' ');

            if (surNamesComps.Length == 2)
            {
                _drivingLicenseResultView.Surname.Text = surNamesComps[0];
                _drivingLicenseResultView.Surname2.Text = surNamesComps[1];
                _drivingLicenseResultView.GivenNames.Text = result.GivenNames;
            }
            else
            {
                _drivingLicenseResultView.Surname.Text = surNamesComps[0];
                _drivingLicenseResultView.GivenNames.Text = result.GivenNames;
                _drivingLicenseResultView.Surname2.Text = "";
            }

            string[] birthdateIDComps = result.DayOfBirth.Split(' ');

            string birthday = birthdateIDComps[0];

            _drivingLicenseResultView.Birthdate.Text = birthday;
            _drivingLicenseResultView.IDNumber.Text = result.DocumentNumber;

            // Present the information to the user
            _drivingLicenseResultView?.AnimateFadeIn(View);
        }
    }
}
