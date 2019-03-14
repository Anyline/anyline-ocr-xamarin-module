using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Reflection;
using System.IO;
using AnylineExamples.iOS;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnylineExamples.iOS
{
    public sealed class ScanViewController : UIViewController
    {
        readonly string LicenseKey = AnylineViewController.LicenseKey;

        string _jsonPath;
        CGRect _frame;
        bool _initialized = false;

        ALScanView _scanView;
        ScanResultDelegate _resultDelegate;
        public ScanViewController(string name, string jsonPath)
        {
            Title = name;
            _jsonPath = jsonPath;

            _resultDelegate = new ScanResultDelegate(this);
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        private void ConnectDelegateToScanPlugin()
        {
            (_scanView.ScanViewPlugin as ALIDScanViewPlugin)?.IdScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALBarcodeScanViewPlugin)?.BarcodeScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALOCRScanViewPlugin)?.OcrScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALMeterScanViewPlugin)?.MeterScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALDocumentScanViewPlugin)?.DocumentScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALLicensePlateScanViewPlugin)?.LicensePlateScanPlugin.AddDelegate(_resultDelegate);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            NSError error = null;

            try
            {
                _frame = UIScreen.MainScreen.ApplicationFrame;
                _frame = new CGRect(_frame.X,
                    _frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                    _frame.Width,
                    _frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

                var config = NSBundle.MainBundle.PathForResource(@"" + _jsonPath.Replace(".json", ""), @"json");
                
                _scanView = ALScanView.ScanViewForFrame(_frame, config, LicenseKey, _resultDelegate, out error);
                
                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                // TODO: known issue that the result delegate has to be added specifically to the scan plugin
                ConnectDelegateToScanPlugin();
                
                View.AddSubview(_scanView);
                _scanView.StartCamera();

                _initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }

            if (!_initialized) return;

            error = null;
            var success = _scanView.ScanViewPlugin.StartAndReturnError(out error);
            if (!success)
            {
                if (error != null)
                {
                    ShowAlert("Start Scanning Error", error.DebugDescription);

                } else
                {
                    ShowAlert("Start Scanning Error", "error is null");
                }
            }
        }
        
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _initialized = false;

            if (_scanView?.ScanViewPlugin == null)
                return;

            NSError error;
            _scanView.ScanViewPlugin.StopAndReturnError(out error);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }
        
        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
        }

        new void Dispose()
        {
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            base.Dispose();
        }
    }
}