using System;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using System.IO;

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

            InitializeAnyline();

        }

        private void InitializeAnyline()
        {
            NSError error = null;

            if (_initialized)
                return;

            try
            {
                _frame = UIScreen.MainScreen.ApplicationFrame;
                _frame = new CGRect(_frame.X,
                    _frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                    _frame.Width,
                    _frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(@"" + _jsonPath.Replace(".json", ""), @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _scanView = ALScanView.ScanViewForFrame(_frame, configPath, LicenseKey, _resultDelegate, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }
                
                // KNOWN ISSUE (OCRScanPlugin only): the customCmdFile is not loading the file correctly. therefore, it has to be added via code:
                if (_scanView.ScanViewPlugin is ALOCRScanViewPlugin)
                {

                    var file = File.ReadAllText(configPath);
                    NSData data = NSData.FromString(file);
                    NSDictionary dict = NSJsonSerialization.Deserialize(data, 0, out error) as NSDictionary;

                    var customCmdFileName = dict.ValueForKeyPath(new NSString(@"viewPlugin.plugin.ocrPlugin.customCmdFile"));

                    if (customCmdFileName != null)
                    {
                        var name = customCmdFileName.ToString().Split('.');
                        if (name.Length == 2)
                        {
                            var config = (_scanView.ScanViewPlugin as ALOCRScanViewPlugin).OcrScanPlugin.OcrConfig;
                            config.CustomCmdFilePath = NSBundle.MainBundle.PathForResource(name[0], name[1]);

                            // explicitly call this method so everything is updated internally
                            (_scanView.ScanViewPlugin as ALOCRScanViewPlugin).OcrScanPlugin.SetOCRConfig(config, out error);

                            if (error != null)
                                ShowAlert("OCR Config Error", error.DebugDescription);
                        }
                    }
                }

                // KNOWN ISSUE: the result delegate has to be added specifically to the scan plugin.
                // this should be automatically done already with the ScanViewForFrame call.
                ConnectDelegateToScanPlugin();

                View.AddSubview(_scanView);
                _scanView.StartCamera();

                _initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
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

            // initialize anyline if not already initialized
            InitializeAnyline();

            if (!_initialized) return;

            NSError error = null;
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