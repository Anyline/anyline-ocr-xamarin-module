using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using Anyline;
using Anyline.Droid;
using IO.Anyline2;
using IO.Anyline2.View;
using IO.Anyline2.Viewplugin;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScanExamplePage), typeof(ScanPageRenderer))]

namespace Anyline.Droid
{
    public class ScanPageRenderer : PageRenderer, IEvent
    {

        private Android.Views.View view;
        private ScanView scanView;

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
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            InitializeAnyline();
        }

        void InitializeAnyline()
        {
            string configurationFile = (Element as ScanExamplePage).ConfigurationFile.Replace(".json", "") + ".json";

            try
            {
                if (view == null)
                {
                    var activity = Context as Activity;
                    view = activity.LayoutInflater.Inflate(Resource.Layout.ScanLayout, this, false);

                    AddView(view);

                    scanView = view.FindViewById<ScanView>(Resource.Id.scan_view);

                    scanView.Init(configurationFile);

                    scanView.ScanViewPlugin.ResultReceived = this;
                    scanView.ScanViewPlugin.ResultsReceived = this;

                    scanView.CameraView.CameraOpened += ScanView_CameraOpened;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Toast.MakeText(Context, "Anyline Init Failed: " + e.Message, ToastLength.Long).Show();
            }
        }

        public void EventReceived(Java.Lang.Object data)
        {
            (Element as ScanExamplePage).ShowResultsAction?.Invoke(data.CreatePropertyDictionary());
        }

        private void ScanView_CameraOpened(object sender, IO.Anyline.Camera.CameraOpenedEventArgs e)
        {
            if (scanView != null)
                scanView.Start();
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
        }

        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            DisposeAnyline();
            InitializeAnyline();
        }

        protected override void Dispose(bool disposing)
        {
            DisposeAnyline();
            base.Dispose(disposing);
        }

        private void DisposeAnyline()
        {
            if (scanView != null)
            {
                scanView.Stop();
                scanView.CameraView.ReleaseCameraInBackground();
                scanView.Dispose();
                scanView = null;
            }
            view = null;
            RemoveAllViews();
        }
    }
}