using Anyline;
using Anyline.iOS;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScanExamplePage), typeof(ScanPageRenderer))]
namespace Anyline.iOS
{
    public class ScanPageRenderer : PageRenderer
    {
        private CGRect frame;
        private bool initialized;

        private ALScanView _scanView;
        ScanResultDelegate _resultDelegate;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // initialize anyline if not already initialized
            InitializeAnyline();

            if (!initialized) return;

            StartAnyline();
        }

        private void StartAnyline()
        {
            NSError error = null;
            var success = _scanView.ScanViewPlugin.StartAndReturnError(out error);
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
        }

        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                frame = View.Bounds;

                string configurationFile = (Element as ScanExamplePage).ConfigurationFile.Replace(".json", "");

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(configurationFile, @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _resultDelegate = new ScanResultDelegate((Element as ScanExamplePage).ShowResultsAction);
                _scanView = ALScanView.ScanViewForFrame(frame, configPath, _resultDelegate, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }


                // KNOWN ISSUE: the result delegate has to be added specifically to the scan plugin.
                // this should be automatically done already with the ScanViewForFrame call.
                ConnectDelegateToScanPlugin();

                View.AddSubview(_scanView);
                _scanView.StartCamera();

                initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
        }

        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
        }

        private void ConnectDelegateToScanPlugin()
        {
            (_scanView.ScanViewPlugin as ALIDScanViewPlugin)?.IdScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALBarcodeScanViewPlugin)?.BarcodeScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALOCRScanViewPlugin)?.OcrScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALMeterScanViewPlugin)?.MeterScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALDocumentScanViewPlugin)?.DocumentScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALLicensePlateScanViewPlugin)?.LicensePlateScanPlugin.AddDelegate(_resultDelegate);
            (_scanView.ScanViewPlugin as ALSerialScanViewPluginComposite)?.AddDelegate(_resultDelegate);
        }

        #region teardown
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            initialized = false;

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

        new void Dispose()
        {
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            base.Dispose();
        }
        #endregion
    }
}