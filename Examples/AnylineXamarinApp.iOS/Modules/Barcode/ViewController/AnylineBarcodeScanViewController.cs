using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Reflection;
using System.IO;

namespace AnylineXamarinApp.iOS.Modules.Barcode.ViewController
{
    public sealed class AnylineBarcodeScanViewController : UIViewController, IAnylineBarcodeModuleDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineBarcodeModuleView _anylineBarcodeView;
        UILabel _resultLabel;
        public UIAlertView Alert { get; private set; }
        NSError _error;
        bool _success;
        CGRect _frame;
        
        public AnylineBarcodeScanViewController(string name)
        {
            Title = name;
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the barcode module.
            _frame = UIScreen.MainScreen.ApplicationFrame;
            _frame = new CGRect(_frame.X,
                _frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                _frame.Width,
                _frame.Height - NavigationController.NavigationBar.Frame.Size.Height);
            
            _anylineBarcodeView = new AnylineBarcodeModuleView(_frame);

            _error = null;
            _success = _anylineBarcodeView.SetupWithLicenseKey(_licenseKey, Self, out _error);

            if (!_success)
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }

            // Anyline will stop searching for new results once it found a valid code. Here we tell it to continue scanning
            // after it found and reported the result.
            _anylineBarcodeView.CancelOnResult = false;

            _anylineBarcodeView.BeepOnResult = true;

            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_anylineBarcodeView);
    
            // The resultLabel is used as a debug view to see the scanned results. We set its text
            // in anylineBarcodeModuleView:didFindScanResult:atImage below
            _resultLabel = new UILabel(new CGRect(0,View.Frame.Size.Height-100,View.Frame.Size.Width, 50));

            _resultLabel.TextAlignment = UITextAlignment.Center;
            _resultLabel.TextColor = UIColor.White;
            _resultLabel.Font = UIFont.FromName(@"HelveticaNeue-UltraLight", 22);
            _resultLabel.AdjustsFontSizeToFitWidth = true;

            View.AddSubview(_resultLabel);

        }
        
        /*
         * This method will be called once the view controller and its subviews have appeared on screen
         */
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            /*
             This is the place where we tell Anyline to start receiving and displaying images from the camera.
             Success/error tells us if everything went fine.
             */
            _error = null;
            _success = _anylineBarcodeView.StartScanningAndReturnError(out _error);
            
            if (!_success)
            {
                // Something went wrong. The error object contains the error description
                (Alert = new UIAlertView(@"Start Scanning Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
        }

        /*
         * This is the main delegate method Anyline uses to report its scanned codes
         */
        void IAnylineBarcodeModuleDelegate.DidFindResult(AnylineBarcodeModuleView anylineBarcodeModuleView, ALBarcodeResult scanResult)
        {
            _resultLabel.Text = scanResult.Result.ToString();
        }
        
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            // We have to stop scanning before the view dissapears
            _error = null;
            if (!_anylineBarcodeView.CancelScanningAndReturnError(out _error))
            {
                (Alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
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

            _anylineBarcodeView?.RemoveFromSuperview();
            _anylineBarcodeView?.Dispose();
            _anylineBarcodeView = null;

            GC.Collect(GC.MaxGeneration);

            base.Dispose();
        }
    }
}