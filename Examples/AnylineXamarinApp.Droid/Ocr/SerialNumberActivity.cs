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
    [Activity(Label = "Unversal Serial Number", MainLauncher = false, Icon = "@drawable/ic_launcher", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public class SerialNumberActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(SerialNumberActivity).Name;
        
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
            
            _scanView.SetConfigFromAsset("SerialNumberViewConfig.json");
            
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
            //Configure the OCR for Serial Numbers
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            anylineOcrConfig.SetScanMode(AnylineOcrConfig.ScanMode.Auto);
            anylineOcrConfig.SetLanguages("USN_A-Z0-9.any");
            anylineOcrConfig.ValidationRegex = "[A-Z0-9]{4,}";
            
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
            resultDialogBuilder.SetMessage(scanResult.Result.ToString().Trim());

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
 