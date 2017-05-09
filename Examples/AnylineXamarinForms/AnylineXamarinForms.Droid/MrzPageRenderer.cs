using Android.App;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using AT.Nineyards.Anyline.Modules.Mrz;
using Android.Util;
using AnylineXamarinForms.Droid;
using AnylineXamarinForms;
using AT.Nineyards.Anyline.Camera;
using AT.Nineyards.Anylinexamarin.Support.Modules.Mrz;
using System;

// This ExportRenderer command tells Xamarin.Forms to use this renderer
// instead of the built-in one for this page
[assembly: ExportRenderer(typeof(MrzPage), typeof(MrzPageRenderer))]

namespace AnylineXamarinForms
{
    /// <summary>
    /// Render this page using platform-specific Android.Views controls
    /// </summary>
    public class MrzPageRenderer : PageRenderer, IMrzResultListener
    {
        private Android.Views.View _view;
        private MrzScanView _scanView;
        
        //when generating a license key, make sure you have the right package name! see code below to get your package name        
        private const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            Log.Debug("", "Element changed");

            if (_view == null)
            {

                var activity = Context as Activity;
                _view = activity.LayoutInflater.Inflate(Resource.Layout.MrzLayout, this, false);

                AddView(_view);

                _scanView = _view.FindViewById<MrzScanView>(Resource.Id.mrz_scan_view);
                _scanView.InitAnyline(LicenseKey, this);

                _scanView.SetConfigFromAsset("MrzConfig.json");
                
                // The config can be changed via code directly through the Config property, for example:
                var config = _scanView.Config;
                config.SetFlashMode(AnylineViewConfig.FlashMode.Auto);
                _scanView.Config.SetFlashAlignment(AnylineViewConfig.FlashAlignment.TopRight);

                // Important: Once the config is changed, it has to be set again explicitly:
                _scanView.Config = config;

                _scanView.SetCancelOnResult(false);

                _scanView.StartScanning();
                
                _scanView.CameraOpened += _scanView_CameraOpened;                
            }
        }

        private void _scanView_CameraOpened(object sender, CameraOpenedEventArgs e)
        {
            //_scanView.StartScanning();
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            Log.Debug("", $"On Size change {w} {h} {oldw} {oldh}");
            base.OnSizeChanged(w, h, oldw, oldh);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            Log.Debug("", $"On Layout {l} {t} {r} {b}");
            
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            _view.Measure(msw, msh);
            _view.Layout(0, 0, r - l, b - t);            
        }

        //this method is called when a result is found
        void IMrzResultListener.OnResult(MrzResult scanResult)
        {
            Log.Debug(typeof(EnergyPageRenderer).Name, "Result: " + scanResult.Result.ToString());
            Toast.MakeText(Context, scanResult.Result.ToString(), ToastLength.Long).Show();

            _scanView.StartScanning();
        }
    }
}
