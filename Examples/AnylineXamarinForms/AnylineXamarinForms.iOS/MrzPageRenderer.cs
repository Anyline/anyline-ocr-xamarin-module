using System;
using AnylineXamarinForms;
using Xamarin.Forms.Platform.iOS;
using AnylineXamarinForms.iOS;
using Xamarin.Forms;
using AnylineXamarinSDK.iOS;
using UIKit;
using CoreGraphics;
using System.Diagnostics;
using Foundation;

[assembly: ExportRenderer(typeof(MrzPage), typeof(MrzPageRenderer))]
namespace AnylineXamarinForms.iOS
{
    class MrzPageRenderer : PageRenderer, IAnylineMRZModuleDelegate
    {
        private const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        private AnylineMRZModuleView _scanView;
        private CGRect _frame;
        private NSError _error;
        private UIAlertView _alert;

        // Store the imageView as member
        private UIImageView imageView;

        // Update the frame of the image to be aligned to the scanview cutout.
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            imageView.Frame = _scanView.CutoutRect;
        }

        // Load the image and add it to the view. Make sure that the imageView is added after the scanView.
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {

                // Initializing the energy module.
                _frame = UIScreen.MainScreen.ApplicationFrame;

                // Search for the navigation controller
                UINavigationController nav = null;
                foreach (var vc in
                  UIApplication.SharedApplication.Windows[0].RootViewController.ChildViewControllers)
                {
                    if (vc is UINavigationController)
                        nav = (UINavigationController)vc;
                }
                
                /*_frame = new CGRect(_frame.X,
                        _frame.Y + nav.NavigationBar.Frame.Size.Height,
                        _frame.Width,
                        _frame.Height - nav.NavigationBar.Frame.Size.Height);*/

                _scanView = new AnylineMRZModuleView(NativeView.Frame);
                
                _error = null;
                var success = _scanView.SetupWithLicenseKey(LicenseKey, Self, out _error);
                if (!success)
                {
                    (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
                }
                
                string configurationPath = NSBundle.MainBundle.PathForResource(@"mrz_config", @"json");
                var configuration = ALUIConfiguration.CutoutConfigurationFromJsonFile(configurationPath);
                configuration.FlashAlignment = ALFlashAlignment.TopRight;
                configuration.StrokeColor = new UIColor(0f, 1f, 1f, .2f);
                configuration.FeedbackStrokeColor = new UIColor(0f, 1f, 1f, .2f);
                _scanView.CurrentConfiguration = configuration;

                _scanView.CancelOnResult = true;
                
                // After setup, add the scanView to the view
                View.AddSubview(_scanView);
                
                UIImage cutoutImage = UIImage.FromBundle(@"cutoutImage.jpg");
                imageView = new UIImageView(_scanView.CutoutRect);
                imageView.Image = cutoutImage;
                //View.AddSubview(imageView);

                // Start scanning
                StartScanning();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR: ", ex.Message);
            }
        }

        public void DidFindResult(AnylineMRZModuleView anylineMRZModuleView, ALIDResult scanResult)
        {
            Debug.WriteLine(scanResult.Result.ToString(), @"Result: ");

            var res = scanResult.Result as ALMRZIdentification;
            var str = "";
            if (res.IssuingDate != null)
                str = res.IssuingDate + "\n" + res.IssuingDateObject.ToString();
            _alert = new UIAlertView("Result", str, (IUIAlertViewDelegate)null, "OK", null);
            _alert.Clicked += (e, a) => {
                StartScanning();
            };

            _alert.Show();
        }
        
        void StartScanning()
        {            
            var success = _scanView.StartScanningAndReturnError(out _error);
            if (!success)
                (_alert = new UIAlertView("Error", _error.DebugDescription, (IUIAlertViewDelegate)null, "OK", null)).Show();
        }        
    }
}