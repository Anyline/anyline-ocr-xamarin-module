using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UIKit;

namespace AnylineExamples.iOS
{
    public sealed class ScanViewController : UIViewController
    {
        string jsonPath;
        bool initialized = false;

        ALScanView scanView;
        ScanResultDelegate resultDelegate;
        string configPath = null;

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
                // Use the JSON file name that you want to load here
                configPath = NSBundle.MainBundle.PathForResource(@"" + jsonPath.Replace(".json", ""), @"json");

                // This is the main intialization method that will create our use case depending on the JSON configuration.
                scanView = ALScanView.ScanViewForFrame(View.Bounds, configPath, resultDelegate, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                ConnectDelegateToScanPlugin();

                // Activates PDF 417 parsing
                // (you can activate this when scanning the barcode on US Driver's Licenses)
                if (scanView.ScanViewPlugin is ALBarcodeScanViewPlugin barcodeSVP)
                {
                    barcodeSVP.BarcodeScanPlugin.ParsePDF417 = true;
                }

                View.AddSubview(scanView);

                // Pin the leading edge of the scan view to the parent view

                scanView.TranslatesAutoresizingMaskIntoConstraints = false;

                scanView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
                scanView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
                scanView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
                scanView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor).Active = true;

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

            // add listener to the composite as a whole (to get the information once all the results are available)
            (scanView.ScanViewPlugin as ALAbstractScanViewPluginComposite)?.AddDelegate(resultDelegate);

            // OR 

            //// add individual listeners (in case you need to listen to partial results and interrupt the workflow)
            //// -> in this case, remember to call "scanView.ScanViewPlugin.StopAndReturnError(out error)" after the result to stop scanning.

            //var parallelComposite = (scanView.ScanViewPlugin as ALParallelScanViewPluginComposite);
            //if (parallelComposite != null)
            //{
            //    foreach (ALAbstractScanViewPlugin item in parallelComposite.ChildPlugins.Values)
            //    {
            //        if (item is ALMeterScanViewPlugin meterScanViewPlugin)
            //        {
            //            meterScanViewPlugin.MeterScanPlugin.AddDelegate(resultDelegate);
            //        }
            //        else if (item is ALBarcodeScanViewPlugin barcodeScanViewPlugin)
            //        {
            //            barcodeScanViewPlugin.BarcodeScanPlugin.AddDelegate(resultDelegate);
            //        }
            //    }
            //}
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