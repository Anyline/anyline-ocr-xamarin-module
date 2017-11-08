using System;
using System.Collections.Generic;
using System.Linq;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Energy.ViewController
{

    public sealed class AnylineEnergyScanViewController : UIViewController, IAnylineEnergyModuleDelegate, IAnylineNativeBarcodeDelegate
    {
        readonly string _licenseKey = AnylineViewController.LicenseKey;

        AnylineEnergyModuleView _anylineEnergyView;
        UISegmentedControl _meterTypeSegment;
        UIAlertView _alert;
        CGRect _frame;
        NSError _error;
        bool _success;
        bool _isScanning;
        bool _keepScanViewControllerAlive;

        UILabel _selectionLabel;
        UILabel _infoLabel;
        readonly string _labelText;
        readonly int _defaultIndex;

        Dictionary<string, ALScanMode> _segmentItems;

        UISwitch _toggleBarcodeSwitch;
        UILabel _toggleBarcodeLabel;
        UIView _toggleBarcodeView;
        string _barcodeResult = "";

        public AnylineEnergyScanViewController(string name, Dictionary<string,ALScanMode> segmentItems, string labelText, int defaultIndex)
        {
            Title = name;
            _segmentItems = segmentItems;
            _labelText = labelText;
            _defaultIndex = defaultIndex;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            
            _toggleBarcodeLabel.Center = new CGPoint(_toggleBarcodeLabel.Frame.Size.Width / 2, _toggleBarcodeView.Frame.Size.Height / 2);
            _toggleBarcodeSwitch.Center = new CGPoint(_toggleBarcodeLabel.Frame.Size.Width + _toggleBarcodeSwitch.Frame.Size.Width  / 2 + 7, _toggleBarcodeView.Frame.Size.Height / 2);

            var width = _toggleBarcodeSwitch.Frame.Size.Width + 7 + _toggleBarcodeLabel.Frame.Size.Width;
            _toggleBarcodeView.Frame = new CGRect(_frame.Size.Width - width - 15, _frame.Size.Height - _toggleBarcodeView.Frame.Size.Height - 5, width, 50);            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Initializing the energy module.
            _frame = UIScreen.MainScreen.ApplicationFrame;
            _frame = new CGRect(_frame.X,
                _frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                _frame.Width,
                _frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            _anylineEnergyView = new AnylineEnergyModuleView(_frame);
            
            _error = null;
            _success = _anylineEnergyView.SetupWithLicenseKey(_licenseKey, Self, out _error);
            if (!_success)
            {
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            
            // We'll stop scanning manually
            _anylineEnergyView.CancelOnResult = false;
            
            // After setup is complete we add the module to the view of this view controller
            View.AddSubview(_anylineEnergyView);

            _error = null;
            _anylineEnergyView.SetScanMode(_segmentItems.ElementAt(_defaultIndex).Value, out _error);
            if (_error != null)
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();

            // Create a subview for toggling native barcode scanning:

            _toggleBarcodeView = new UIView(new CGRect(0, 0, 150, 50));
            _toggleBarcodeLabel = new UILabel(new CGRect(0, 0, 100, 30));
            _toggleBarcodeLabel.Text = "Detect Barcodes";
            _toggleBarcodeLabel.TextColor = UIColor.White;
            _toggleBarcodeLabel.SizeToFit();

            _toggleBarcodeSwitch = new UISwitch();
            _toggleBarcodeSwitch.On = false;    
            _toggleBarcodeSwitch.TintColor = UIColor.White;
            _toggleBarcodeSwitch.OnTintColor = new UIColor(0, 153 / 255, 1, 1);
            _toggleBarcodeSwitch.ValueChanged += OnValueChanged;

            _toggleBarcodeView.AddSubview(_toggleBarcodeLabel);
            _toggleBarcodeView.AddSubview(_toggleBarcodeSwitch);

            View.AddSubview(_toggleBarcodeView);

            // We don't need a segment control for only one option:
            if (_segmentItems.Count > 1)
            {
                List<string> list = new List<string>();
                foreach (var key in _segmentItems.Keys)
                    list.Add(key);

                var obj = list.ToArray<object>();
                _meterTypeSegment = new UISegmentedControl(obj);

                //adjust the segmentcontrol size so all elements fit to the view
                if (_meterTypeSegment.NumberOfSegments > 3)
                {
                    for (int i = 0; i < _meterTypeSegment.NumberOfSegments; i++)
                        _meterTypeSegment.SetWidth(View.Frame.Width / (_meterTypeSegment.NumberOfSegments + 1), i);
                    
                    _meterTypeSegment.ApportionsSegmentWidthsByContent = true;
                }
                _meterTypeSegment.Center = new CGPoint(View.Center.X, View.Frame.Size.Height - 40);

                _meterTypeSegment.SelectedSegment = _defaultIndex;
                _meterTypeSegment.ValueChanged += HandleSegmentChange;
                View.AddSubview(_meterTypeSegment);

                _selectionLabel = new UILabel(new CGRect(_meterTypeSegment.Frame.X, _meterTypeSegment.Frame.Y - 35, _meterTypeSegment.Frame.Width, 35));
                _selectionLabel.TextColor = UIColor.White;
                _selectionLabel.Text = _labelText;
                View.AddSubview(_selectionLabel);
                
                _infoLabel = new UILabel(new CGRect(0, View.Frame.Y + NavigationController.NavigationBar.Frame.Size.Height + 13, View.Frame.Width, 35));
                _infoLabel.TextColor = UIColor.White;
                _infoLabel.Text = "";
                _infoLabel.TextAlignment = UITextAlignment.Center;
                View.AddSubview(_infoLabel);

                UpdateInfoLabel(_anylineEnergyView.ScanMode);
            
            }
        }

        // Toggle native barcode scanning
        void OnValueChanged(object sender, EventArgs args)
        {
            var isOn = ((UISwitch)sender).On;

            if (isOn)
            {
                // We set this instance to as the barcode delegate so we get native barcode result callbacks
                _anylineEnergyView.CaptureDeviceManager.BarcodeDelegate = Self;
            }
            else
            {
                _barcodeResult = "";
                _anylineEnergyView.CaptureDeviceManager.BarcodeDelegate = null;
            }
        }

        private void HandleSegmentChange(object sender, EventArgs e)
        {
            var uiSegmentedControl = sender as UISegmentedControl;
            if (uiSegmentedControl != null)
            {
                var selectedSegmentId = uiSegmentedControl.SelectedSegment;
                
                var scanMode = _segmentItems.ElementAt((int)selectedSegmentId).Value;
                Console.WriteLine("Scanmode: {0}", scanMode);

                UpdateInfoLabel(scanMode);
                _error = null;
                _anylineEnergyView.SetScanMode(scanMode, out _error);

                if (_error != null)
                    (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
        }
        
        //update the info text for certain energy scan modes
        private void UpdateInfoLabel(ALScanMode scanMode)
        {
            var desc = "";
            switch (scanMode)
            {
                case ALScanMode.AnalogMeter:
                    desc = "";
                    break;                
            }
            _infoLabel.Text = desc;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            StartAnyline();
            
            //we want to kill the controller if we navigate back to the previous viewcontroller
            _keepScanViewControllerAlive = false;
        }

        /*
         * This is the place where we tell Anyline to start receiving and displaying images from the camera.
         * Success/error tells us if everything went fine.
         */
        public void StartAnyline()
        {
            _barcodeResult = "";

            if (_isScanning) return;
            
            _error = null;
            _success = _anylineEnergyView.StartScanningAndReturnError(out _error);

            if (!_success)
            {
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            else
                _isScanning = true;
        }

        /*
         * We'll stop scanning and if something goes wrong, we display it as an alert.
         */
        public void StopAnyline()
        {
            if (!_isScanning) return;

            _error = null;
            _success = _anylineEnergyView.CancelScanningAndReturnError(out _error);

            if (!_success)
            {
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
            }
            else
                _isScanning = false;
        }

        /*
         * This is the main delegate method Anyline uses to report its scanned codes
         */
        void IAnylineEnergyModuleDelegate.DidFindResult(AnylineEnergyModuleView anylineEnergyModuleView, ALEnergyResult scanResult)
        {
            StopAnyline();

            //we'll go to a temporary new view controller, so we keep this one alive
            _keepScanViewControllerAlive = true;

            var x = scanResult.ScanMode;

            try
            {
                AnylineEnergyScanViewResultController vc = new AnylineEnergyScanViewResultController(scanResult.Result.ToString(), scanResult.ScanMode, _barcodeResult);
                vc.MeterImage = scanResult.Image;

                NavigationController.PushViewController(vc, true);
            }
            catch (Exception)
            {
                // ignored
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

            //don't clean up objects, if we want the controller to be kept alive
            if (_keepScanViewControllerAlive) return;

            //we have to un-register the event handlers because else the whole viewcontroller will be kept in the garbage collector.
            if (_meterTypeSegment != null) _meterTypeSegment.ValueChanged -= HandleSegmentChange;

            _meterTypeSegment?.Dispose();

            _selectionLabel?.Dispose();

            _toggleBarcodeLabel.RemoveFromSuperview();
            _toggleBarcodeLabel?.Dispose();

            _toggleBarcodeSwitch.ValueChanged -= OnValueChanged;
            _toggleBarcodeSwitch.RemoveFromSuperview();
            _toggleBarcodeSwitch?.Dispose();

            _toggleBarcodeView.RemoveFromSuperview();
            _toggleBarcodeView?.Dispose();

            _infoLabel?.Dispose();

            _segmentItems = null;
            
            _alert?.Dispose();
            _error?.Dispose();

            //we have to erase the scan view so that there are no dependencies for the viewcontroller left.
            _anylineEnergyView?.RemoveFromSuperview();
            _anylineEnergyView?.Dispose();

            Dispose();
        }

        void IAnylineNativeBarcodeDelegate.DidFindBarcodeResult(ALCaptureDeviceManager captureDeviceManager, string scanResult, string barcodeType)
        {
            Console.WriteLine("Barcode Result: " + scanResult);
            _barcodeResult = scanResult;
        }
    }
}
