using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using System;
using System.IO;
using UIKit;

namespace AnylineExamples.iOS
{
    public sealed class ScanViewController : UIViewController
    {
        readonly string LicenseKey = AnylineViewController.LicenseKey;

        string jsonPath;
        CGRect frame;
        bool initialized = false;

        ALScanView scanView;
        ScanResultDelegate resultDelegate;
        public ScanViewController(string name, string jsonPath)
        {
            Title = name;
            this.jsonPath = jsonPath;

            resultDelegate = new ScanResultDelegate(this);
        }


        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                frame = UIScreen.MainScreen.ApplicationFrame;
                frame = new CGRect(frame.X,
                    frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                    frame.Width,
                    frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(@"" + jsonPath.Replace(".json", ""), @"json");

                // This is the main intialization method that will create our use case depending on the JSON configuration.
                scanView = ALScanView.ScanViewForFrame(frame, configPath, LicenseKey, resultDelegate, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                // KNOWN ISSUE (OCRScanPlugin only): the customCmdFile is not loading the file correctly. therefore, it has to be added via code:
                if (scanView.ScanViewPlugin is ALOCRScanViewPlugin)
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
                            var config = (scanView.ScanViewPlugin as ALOCRScanViewPlugin).OcrScanPlugin.OcrConfig;
                            config.CustomCmdFilePath = NSBundle.MainBundle.PathForResource(name[0], name[1]);

                            // explicitly call this method so everything is updated internally
                            (scanView.ScanViewPlugin as ALOCRScanViewPlugin).OcrScanPlugin.SetOCRConfig(config, out error);

                            if (error != null)
                                ShowAlert("OCR Config Error", error.DebugDescription);
                        }
                    }
                }

                // KNOWN ISSUE: the result delegate has to be added specifically to the scan plugin.
                // this should be automatically done already with the ScanViewForFrame call.
                ConnectDelegateToScanPlugin();

                View.AddSubview(scanView);
                scanView.StartCamera();

                initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
        }

        private void ConnectDelegateToScanPlugin()
        {
            (scanView.ScanViewPlugin as ALIDScanViewPlugin)?.IdScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALBarcodeScanViewPlugin)?.BarcodeScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALOCRScanViewPlugin)?.OcrScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALMeterScanViewPlugin)?.MeterScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALDocumentScanViewPlugin)?.DocumentScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALLicensePlateScanViewPlugin)?.LicensePlateScanPlugin.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALSerialScanViewPluginComposite)?.AddDelegate(resultDelegate);
            (scanView.ScanViewPlugin as ALParallelScanViewPluginComposite)?.AddDelegate(resultDelegate);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // initialize anyline if not already initialized
            InitializeAnyline();

            if (!initialized) return;

            NSError error = null;

            BeginInvokeOnMainThread(() =>
            {
                var success = scanView.ScanViewPlugin.StartAndReturnError(out error);

                if (!success)
                {
                    if (error != null)
                    {
                        ShowAlert("Start Scanning Error", error.DebugDescription);

                    }
                    else
                    {
                        ShowAlert("Start Scanning Error", "error is null");
                    }
                }
            });
        }
        #region teardown
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            initialized = false;

            if (scanView?.ScanViewPlugin == null)
                return;

            NSError error;
            scanView.ScanViewPlugin.StopAndReturnError(out error);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }

        new void Dispose()
        {
            scanView?.RemoveFromSuperview();
            scanView?.Dispose();
            scanView = null;
            base.Dispose();
        }
        #endregion

        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
        }
    }
}