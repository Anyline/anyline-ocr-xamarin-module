using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;

using Android.Util;
using IO.Anyline.Camera;
using AndroidX.AppCompat.App;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ScanActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ScanActivity).Name;

        private IO.Anyline2.View.ScanView _scanView;
        private bool _isInitialized = false;

        private MyAnylineResultEventHandler _scanResultListener;

        public ScanActivity()
        {
            _scanResultListener = new MyAnylineResultEventHandler(this);
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
                _scanResultListener.Title = Title;

                Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
                SetContentView(Resource.Layout.scan_activity);
                
                _scanView = FindViewById<IO.Anyline2.View.ScanView>(Resource.Id.scan_view);

                // the initialization parses the json configuration and builds the whole use-case
                _scanView.Init(jsonPath);
                
                //_scanView.ScanViewPlugin.RunSkippedReceived = _scanResultListener;
                //_scanView.ScanViewPlugin.ErrorReceived = _scanResultListener;
                //_scanView.ScanViewPlugin.VisualFeedbackReceived = _scanResultListener;
                _scanView.ScanViewPlugin.ResultReceived = _scanResultListener;
                _scanView.ScanViewPlugin.ResultsReceived = _scanResultListener;

                // handle camera open events
                _scanView.CameraView.CameraOpened += ScanView_CameraOpened;

                // handle camera error events
                _scanView.CameraView.CameraError += ScanView_CameraError;

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

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            StopScanning();
        }

        private void StopScanning()
        {
            if (_scanView != null)
            {
                _scanView.Stop();
                _scanView.CameraView.ReleaseCameraInBackground();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            try
            {
                if (_scanView != null)
                {
                    _scanView.Dispose();
                    _scanView.CameraView.CameraOpened -= ScanView_CameraOpened;
                    _scanView.CameraView.CameraError -= ScanView_CameraError;
                    _scanView = null;

                    _isInitialized = false;
                }
            }
            catch (Exception) { }
        }

        #endregion
    }
}