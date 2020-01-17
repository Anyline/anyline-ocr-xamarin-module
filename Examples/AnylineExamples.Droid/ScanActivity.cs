using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AT.Nineyards.Anyline.Camera;
using IO.Anyline.View;

using Android.Support.V7.App;
using Android.Util;
using IO.Anyline.Plugin.ID;
using IO.Anyline.Plugin.Barcode;
using System.Collections;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ScanActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ScanActivity).Name;

        //INSERT YOUR LICENSE KEY HERE
        public static readonly string LICENSE_KEY = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpbWFnZVJlcG9ydENhY2hpbmciOiB0cnVlLCAiaW9zSWRlbnRpZmllciI6IFsgIkFULkFueWxpbmUuWGFtYXJpbi5BcHAuaU9TIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuaU9TIiBdLCAibGljZW5zZUtleVZlcnNpb24iOiAyLCAibWFqb3JWZXJzaW9uIjogIjE4IiwgIm1heERheXNOb3RSZXBvcnRlZCI6IDAsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMS0wMS0wMSIgfQpnS0YvdDJpS05FTFR5dzZYQnMzclhlb0dxSkk0K0hsZzNLcnRnZ3I3eVpNdHZNQ1I3cE5QK1M0YUp1VG8wVGU0CnJtY3hwZHFYNWF6Ly9nM0pNNHB4VjdlUjNvVVQ0MVY0cnAyV0ZsNGJnK25yV0JCRSt3OHlCTmZobE5memFkVDcKeXExZWNHcGdic0lzMW5EUEV6SkFkcWQ3b3Z0emRpY254S0VTTithQVR4NDBhNkgyYzQ1cVExTVZmTWNRTTBJeApPdTB1THBiTEFnTGRjVXFFK1k3LzJhaEdyRFFkemNwZXQ1TUpjbWM5ZGdNdHFBQWFrNUphNFQ1a2VUYnN5OGdNCkxSdWhQcExlMlcxQVJLVzRzaEVZTk9wanR2ZkszbkpuaHN4czJYeHZMK1Z5TTd6N2EyRW9yVXN2bk5jcGhsOUMKbkRBbml3bVR4WTJmdmVmQ2lRdFlwdz09Cg==";

        private ScanView _scanView;
        private bool _isInitialized = false;

        private ScanResultListener _scanResultListener;

        public ScanActivity()
        {
            // the document result listener is inheriting from ScanResultListener and additionally implementing the callbacks for document scanning
            // therefore, we're using it here for all the use-cases.
            _scanResultListener = new DocumentScanResultListener(this);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                // we pass the json path from the previous activity
                var jsonPath = Intent.GetStringExtra("jsonPath");

                // we pass the title from the previous activity
                Title = Intent.GetStringExtra("title");

                Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
                SetContentView(Resource.Layout.scan_activity);

                _scanView = FindViewById<ScanView>(Resource.Id.scan_view);

                // the initialization parses the json configuration and builds the whole use-case
                _scanView.Init(jsonPath, LICENSE_KEY);

                /*
                 * Depending on your config/use-case, the ScanViewPlugin is of a different type.
                 * You need to add your implementation of IO.Anyline.Plugin.IScanResultListener to retrieve scan results.
                 */
                _scanView.ScanViewPlugin.AddScanResultListener(_scanResultListener);

                // handle camera open events
                _scanView.CameraOpened += ScanView_CameraOpened;

                // handle camera error events
                _scanView.CameraError += ScanView_CameraError;

                _isInitialized = true;
            }
            catch (Exception e)
            {
                Util.ShowError(e.ToString(), this);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            try
            {
                if (_isInitialized)
                    _scanView.Start();
            }
            catch (Exception e)
            {
                Log.Debug(TAG, e.ToString());
            }
        }
        
        protected override void OnPause()
        {
            base.OnPause();
            StopScanning();
        }

        private void ScanView_CameraError(object sender, CameraErrorEventArgs e)
        {
            Log.Debug(TAG, e.ToString());
        }

        private void ScanView_CameraOpened(object sender, CameraOpenedEventArgs args)
        {
            Log.Debug(TAG, $"Camera opened with resolution {args.Width} x {args.Height}.");
        }

        #region going back & cleanup
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    StopScanning();
                    Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void StopScanning()
        {
            if (_scanView != null)
            {
                _scanView.Stop();
                _scanView.CameraView.ReleaseCamera();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                _isInitialized = false;

                if (_scanView != null)
                {
                    _scanView.Dispose();
                    _scanView.CameraOpened -= ScanView_CameraOpened;
                    _scanView.CameraError -= ScanView_CameraError;
                    _scanView = null;

                    GC.Collect();
                }
            }
            catch (Exception) { }
            Finish();
        }
        #endregion
    }
}