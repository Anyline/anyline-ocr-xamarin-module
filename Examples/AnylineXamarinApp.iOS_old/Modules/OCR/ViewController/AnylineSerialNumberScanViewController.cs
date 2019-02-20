using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.OCR.ViewController
{    
    public sealed class AnylineSerialNumberScanViewController : UIViewController, IAnylineOCRModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineOCRModuleView _scanView;
        ALOCRConfig _ocrConfig;

        UIAlertView _resultAlert;

        NSError _error;
        bool _success;
        bool _isScanning;
        public UIAlertView Alert { get; private set; }

        public AnylineSerialNumberScanViewController(string name)
        {
            Title = name;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the OCR module.
            CGRect frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _scanView = new AnylineOCRModuleView(frame);            

            if (_error != null)
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();

            // We'll define the OCR Config here:
            _ocrConfig = new ALOCRConfig();

            _ocrConfig.ScanMode = ALOCRScanMode.Auto;
            string anyFile = NSBundle.MainBundle.PathForResource(@"Modules/OCR/USNr", @"any");
            _error = null;
            _ocrConfig.SetLanguages(new[] { anyFile }, out _error);
            if (_error != null)
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();

            _ocrConfig.ValidationRegex = "[A-Z0-9]{4,}";

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
            
            // We load the UI config for our serial number view from a .json file.
            string configFile = NSBundle.MainBundle.PathForResource(@"Modules/OCR/serial_number_config", @"json");
            _scanView.CurrentConfiguration = ALUIConfiguration.CutoutConfigurationFromJsonFile(configFile);            

            // We stop scanning manually
            _scanView.CancelOnResult = false;

            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_scanView);           
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

            if (_resultAlert != null)
                _resultAlert.Dismissed -= _resultAlert_Dismissed;
            _resultAlert?.Dispose();
            _resultAlert = null;
            
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
            if (!_scanView.CancelScanningAndReturnError(out _error))
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
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

            _resultAlert?.Dispose();
            _resultAlert = null;

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

            _resultAlert = new UIAlertView() { Title = "Result", Message = result.Text };
            _resultAlert.AddButton("OK");
            _resultAlert.Show();

            _resultAlert.Dismissed += _resultAlert_Dismissed;
        }

        private void _resultAlert_Dismissed(object sender, UIButtonEventArgs e)
        {
            StartAnyline();
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
