using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using IO.Anyline.Camera;
using IO.Anyline.View;

using Android.Support.V7.App;
using Android.Util;
using IO.Anyline.Plugin.ID;
using IO.Anyline.Plugin;
using Anyline.Droid.NFC;

namespace AnylineExamples.Droid.NFC
{
    [Activity(Label = "", MainLauncher = false, //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class MRZScanActivity : AppCompatActivity, IScanResultListener
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
                _scanView.Init("id_config_mrz.json");

                // Activates Face Detection if the MRZ Scanner was initialized
                //(((_scanView.ScanViewPlugin as IdScanViewPlugin)?.ScanPlugin as IdScanPlugin)?.IdConfig as MrzConfig)?.EnableFaceDetection(true);

                //_scanView.ScanViewPlugin.AddScanResultListener(this);

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

        public void OnResult(Java.Lang.Object result)
        {
            var scanResult = result as ScanResult;

            var mrzIdentification = scanResult.Result as MrzIdentification;


            // Gets the data necessary for the NFC reading
            string passportNumber = mrzIdentification.DocumentNumber.Trim();
            Java.Util.Date dateOfBirth = mrzIdentification.DateOfBirthObject;
            Java.Util.Date expirationDate = mrzIdentification.DateOfExpiryObject;
            var dateFormat = new Android.Icu.Text.SimpleDateFormat("yyMMdd");

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
            nfcActivity.PutExtra("db", dateFormat.Format(dateOfBirth));
            nfcActivity.PutExtra("de", dateFormat.Format(expirationDate));
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