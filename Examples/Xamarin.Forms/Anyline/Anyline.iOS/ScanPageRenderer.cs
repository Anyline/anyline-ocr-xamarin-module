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

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            InitializeAnyline();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (!initialized) return;

            StartAnyline();
        }

        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                string configurationFile = (Element as ScanExamplePage).ConfigurationFile.Replace(".json", "");

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(configurationFile, @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _resultDelegate = new ScanResultDelegate((Element as ScanExamplePage).ShowResultsAction);
                _scanView = ALScanView.ScanViewForFrame(View.Bounds, configPath, _resultDelegate, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }


                ConnectDelegateToScanPlugin();

                View.AddSubview(_scanView);

                // Pin the leading edge of the scan view to the parent view

                _scanView.TranslatesAutoresizingMaskIntoConstraints = false;

                _scanView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
                _scanView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
                _scanView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
                _scanView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor).Active = true;

                _scanView.StartCamera();

                initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
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