using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Anyline;
using Anyline.Droid;
using IO.Anyline.Plugin;
using IO.Anyline.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScanPage), typeof(ScanPageRenderer))]

namespace Anyline.Droid
{
    public class ScanPageRenderer : PageRenderer, IScanResultListener
    {

        private Android.Views.View view;
        private ScanView scanView;

        private bool cameraOpened;

        private readonly string licenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        public ScanPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> args)
        {
            base.OnElementChanged(args);

            if (args.OldElement != null || Element == null)
            {
                return;
            }
            
            try
            {
                if (view == null)
                {

                    var activity = Context as Activity;
                    view = activity.LayoutInflater.Inflate(Resource.Layout.ScanLayout, this, false);

                    AddView(view);

                    scanView = view.FindViewById<ScanView>(Resource.Id.scan_view);

                    scanView.Init("mro_config_shipping_container.json", licenseKey);

                    scanView.ScanViewPlugin.AddScanResultListener(this);

                    scanView.CameraOpened += ScanView_CameraOpened;

                }
                
            } catch(Exception e)
            {
                // show error
            }
        }

        private void ScanView_CameraOpened(object sender, AT.Nineyards.Anyline.Camera.CameraOpenedEventArgs e)
        {
            scanView.ScanViewPlugin.Start();
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var w = r - l;
            var h = b - t;

            var msw = MeasureSpec.MakeMeasureSpec(w, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(h, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, w, h);

            Log.Debug("OnLayout", $"{w} x {h}");
        }

        public void OnResult(Java.Lang.Object result)
        {

            Log.Debug("Result", (result as ScanResult).Result.ToString());
        }
    }
}