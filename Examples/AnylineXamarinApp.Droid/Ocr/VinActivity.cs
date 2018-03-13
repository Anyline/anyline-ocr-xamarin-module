using System;
using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Camera;
using AT.Nineyards.Anyline.Modules.Ocr;
using AT.Nineyards.Anylinexamarin.Support.Modules.Ocr;
using AT.Nineyards.Anyline.Util;

#pragma warning disable 618

namespace AnylineXamarinApp.Ocr
{
    [Activity(Label = "Vehicle Identification Number", MainLauncher = false, Icon = "@drawable/ic_launcher", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public class VinActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(VoucherCodeActivity).Name;
        
        private AnylineOcrScanView _scanView;
        private Dialog _resultDialog;
        
        protected override void OnCreate(Bundle bundle)
        {            
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.OCRActivity);
            
            _scanView = FindViewById<AnylineOcrScanView>(Resource.Id.ocr_scan_view);
            
            _scanView.SetConfigFromAsset("VinViewConfig.json");
            
            SetOcrConfig(_scanView);
            
            // set the focus config
            FocusConfig focusConfig = new FocusConfig.Builder()
               .SetDefaultMode(Camera.Parameters.FocusModeContinuousVideo)
               .SetEnableFocusOnTouch(true) // enable focus on touch functionality
               .Build();

            _scanView.SetFocusConfig(focusConfig);

            _scanView.InitAnyline(MainActivity.LicenseKey, this);
                        
            _scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };
            
        }
        
        private void SetOcrConfig(AnylineOcrScanView scanView)
        {
            //Configure the OCR for IBANs
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            // use the line mode (line length and font may vary)
            anylineOcrConfig.SetScanMode(AnylineOcrConfig.ScanMode.Auto);

            anylineOcrConfig.SetLanguages("VIN.any");
            
            // set command file to config
            anylineOcrConfig.CustomCmdFile = "vin.ale";

            // set scan mode to config
            anylineOcrConfig.SetScanMode(AnylineOcrConfig.ScanMode.Auto);

            scanView.SetAnylineOcrConfig(anylineOcrConfig);
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
            _resultDialog?.Dismiss();
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

            _resultDialog?.Dispose();
            _scanView?.Dispose();
            
            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }

        void IAnylineOcrResultListener.OnResult(AnylineOcrResult scanResult)
        {
            AlertDialog.Builder resultDialogBuilder = new AlertDialog.Builder(this);
            resultDialogBuilder.SetTitle("Result");
            resultDialogBuilder.SetMessage(scanResult.ToString().Trim());

            resultDialogBuilder.SetPositiveButton("OK", 
                (sender, args) => 
                {
                    _scanView.StartScanning();
                }
            );

            _resultDialog?.Dispose();
            _resultDialog = resultDialogBuilder.Create();
            _resultDialog.Show();
        }
    }
}
 