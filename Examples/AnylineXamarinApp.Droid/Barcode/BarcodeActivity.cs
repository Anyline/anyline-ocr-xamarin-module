using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Camera;
using AT.Nineyards.Anyline.Modules.Barcode;
using AT.Nineyards.Anylinexamarin.Support.Modules.Barcode;

namespace AnylineXamarinApp.Barcode
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class BarcodeActivity : Activity, IBarcodeResultListener
    {
        public static string TAG = typeof(BarcodeActivity).Name;

        private TextView _resultText;
        private BarcodeScanView _scanView;
        
        protected override void OnCreate(Bundle bundle)
        {
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.BarcodeActivity);

            SetTitle(Resource.String.scan_barcode);

            _scanView = FindViewById<BarcodeScanView>(Resource.Id.barcode_scan_view);
            _resultText = FindViewById<TextView>(Resource.Id.text_result);
            
            _scanView.SetConfigFromAsset("BarcodeConfig.json");

            _scanView.InitAnyline(MainActivity.LicenseKey, this);
            
            // limit the barcode scanner to QR codes or CODE_128 codes
            //scanView.SetBarcodeFormats(BarcodeScanView.BarcodeFormat.QR_CODE, BarcodeScanView.BarcodeFormat.CODE_128);
            
            _scanView.SetBeepOnResult(true);

            _scanView.SetCancelOnResult(false);

            _scanView.CameraOpened += Camera_Opened;
            _scanView.CameraError += Camera_Error;
            
        }

        private void Camera_Opened(object sender, CameraOpenedEventArgs a)
        {            
            Log.Debug(TAG, "Camera opened successfully. Frame resolution " + a.Width + " x " + a.Height);
        }

        private void Camera_Error(object sender, CameraErrorEventArgs a)
        {
            Log.Error(TAG, "OnCameraError: " + a.Event.Message);            
        }
        
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _scanView.StartScanning();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _scanView.CancelScanning();
            _scanView.ReleaseCameraInBackground();
        }
        
        public override void OnBackPressed()
        {
            base.OnBackPressed();            
            Finish();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _scanView?.Dispose();
            _scanView = null;
        }

        void IBarcodeResultListener.OnResult(BarcodeResult scanResult)
        {
            //string result, BarcodeScanView.BarcodeFormat barcodeFormat, AnylineImage anylineImage
            _resultText.SetText(scanResult.Result.ToString(), TextView.BufferType.Normal);
        }
    }    
}