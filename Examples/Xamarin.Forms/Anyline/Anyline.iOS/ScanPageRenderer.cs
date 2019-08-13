using System;
using System.Collections.Generic;
using System.Diagnostics;
using Anyline;
using Anyline.iOS;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScanPage), typeof(ScanPageRenderer))]
namespace Anyline.iOS
{
    public class ScanPageRenderer : PageRenderer, IALOCRScanPluginDelegate
    {
        // use the licenseKey for the bundle identifier of your app (in Info.plist)
        private readonly string licenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        private CGRect frame;
        private bool initialized;

        private ALScanView scanView;
        private UILabel resultLabel;
        
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // initialize anyline if not already initialized
            InitializeAnyline();

            if (!initialized) return;
            
            resultLabel = new UILabel(new CGRect(0, View.Frame.Size.Height - 220, View.Frame.Size.Width, 40));
            resultLabel.TextColor = UIColor.White;
            resultLabel.TextAlignment = UITextAlignment.Center;
            resultLabel.Font = resultLabel.Font.WithSize(35);
            resultLabel.Text = "";

            View.AddSubview(resultLabel);
            StartAnyline();
        }

        private void StartAnyline()
        {
            NSError error = null;
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
        }
        
        private void InitializeAnyline()
        {
            NSError error = null;

            if (initialized)
                return;

            try
            {
                frame = View.Bounds;

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(@"mro_config_shipping_container", @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                scanView = ALScanView.ScanViewForFrame(frame, configPath, licenseKey, this, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }
                
                // KNOWN ISSUE: the result delegate has to be added specifically to the scan plugin.
                // this should be automatically done already with the ScanViewForFrame call.
                (scanView.ScanViewPlugin as ALLicensePlateScanViewPlugin)?.LicensePlateScanPlugin.AddDelegate(this);
                
                View.AddSubview(scanView);
                scanView.StartCamera();

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

        // this will be triggered every time a result is found. here, we simply display it in a textView
        public void DidFindResult(ALOCRScanPlugin anylineOCRScanPlugin, ALOCRResult result)
        {
            var resultText = result.Result.ToString();

            Debug.WriteLine(resultText);
            resultLabel.Text = resultText;
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
    }
}