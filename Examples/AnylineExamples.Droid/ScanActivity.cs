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
using IO.Anyline;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ScanActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ScanActivity).Name;

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
                _scanView.Init(jsonPath);

                /*
                 * Depending on your config/use-case, the ScanViewPlugin is of a different type.
                 * You need to add your implementation of IO.Anyline.Plugin.IScanResultListener to retrieve scan results.
                 */
                _scanView.ScanViewPlugin.AddScanResultListener(_scanResultListener);
                //((_scanView.ScanViewPlugin as IdScanViewPlugin).ScanPlugin as IdScanPlugin).IdConfig
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
                if (_scanView != null)
                {
                    _scanView.Dispose();
                    _scanView.CameraOpened -= ScanView_CameraOpened;
                    _scanView.CameraError -= ScanView_CameraError;
                    _scanView = null;



                    GC.Collect();

                    _isInitialized = false;
                }
            }
            catch (Exception) { }
            Finish();
        }
        #endregion
    }
}