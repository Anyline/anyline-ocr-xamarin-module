using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using IO.Anyline.Camera;

using Android.Util;
using Anyline.Droid.NFC;
using IO.Anyline2;
using IO.Anyline2.View;
using IO.Anyline.Plugin.Result;
using AndroidX.AppCompat.App;

namespace AnylineExamples.Droid.NFC
{
    [Activity(Label = "", MainLauncher = false, //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class MRZScanActivity : AppCompatActivity, IEvent
    {
        public static readonly string TAG = typeof(ScanActivity).Name;

        private ScanView _scanView;
        private bool _isInitialized = false;

        public MRZScanActivity()
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                // we pass the title from the previous activity
                Title = Intent.GetStringExtra("title");

                Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
                SetContentView(Resource.Layout.scan_activity);

                _scanView = FindViewById<ScanView>(Resource.Id.scan_view);

                // the initialization parses the json configuration and builds the whole use-case
                _scanView.Init("mrz_config.json");

                // Activates Face Detection if the MRZ Scanner was initialized
                //(((_scanView.ScanViewPlugin as IdScanViewPlugin)?.ScanPlugin as IdScanPlugin)?.IdConfig as MrzConfig)?.EnableFaceDetection(true);

                _scanView.ScanViewPlugin.ResultReceived = this;

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

        public void EventReceived(Java.Lang.Object result)
        {
            var scanResult = result as IO.Anyline2.ScanResult;
            PluginResult pluginResult = scanResult.PluginResult;
            var mrzResult = pluginResult.MrzResult;

            // Gets the data necessary for the NFC reading
            string passportNumber = mrzResult.DocumentNumber.Trim();

            // The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
            string passportNumberForNFC = string.Copy(passportNumber);

            while (passportNumberForNFC.Length < 9)
            {
                passportNumberForNFC += "<";
            }

            // Open the Activity responsible for listening to the NFC calls and reading the chip.
            // We use data from the MRZ to authenticate with the chip.

            var nfcActivity = new Intent(this, typeof(NFCScanActivity));
            nfcActivity.PutExtra("pn", passportNumberForNFC);
            nfcActivity.PutExtra("db", mrzResult.DateOfBirth);
            nfcActivity.PutExtra("de", mrzResult.DateOfExpiry);
            StartActivity(nfcActivity);
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
                    _scanView.CameraView.CameraOpened -= ScanView_CameraOpened;
                    _scanView.CameraView.CameraError -= ScanView_CameraError;
                    _scanView = null;

                    _isInitialized = false;
                }
            }
            catch (Exception) { }
            Finish();
        }
        #endregion
    }
}