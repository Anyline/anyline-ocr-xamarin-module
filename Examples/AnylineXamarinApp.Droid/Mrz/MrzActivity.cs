using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using AT.Nineyards.Anyline.Modules.Mrz;
using AT.Nineyards.Anylinexamarin.Support.Modules.Mrz;
using Android.Widget;
using static AT.Nineyards.Anyline.Camera.CameraController;
using AT.Nineyards.Anyline.Camera;

namespace AnylineXamarinApp.Mrz
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        HardwareAccelerated = true)]
    public class MrzActivity : Activity, IMrzResultListener, View.IOnClickListener
    {
        public static string TAG = typeof(MrzActivity).Name;
        
        private MrzResultView _resultView;
        private MrzScanView _scanView;
        private Switch _strictModeSwitch;
        private Switch _cropResultSwitch;
        private ImageView _mrzResultImageView;

        protected override void OnCreate(Bundle bundle)
        {
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.MrzActivity);

            SetTitle(Resource.String.scan_mrz);
            
            _scanView = FindViewById<MrzScanView>(Resource.Id.mrz_scan_view);
            _resultView = FindViewById<MrzResultView>(Resource.Id.mrz_result);

            _strictModeSwitch = FindViewById<Switch>(Resource.Id.toggle_strict_mode_switch);
            _cropResultSwitch = FindViewById<Switch>(Resource.Id.toggle_crop_switch);

            _mrzResultImageView = FindViewById<ImageView>(Resource.Id.mrz_result_image_view);

            _resultView.SetOnClickListener(this);
            
            _scanView.SetConfigFromAsset("MrzConfig.json");
            
            _scanView.InitAnyline(MainActivity.LicenseKey, this);
                        
            _scanView.SetCancelOnResult(true);
            
            _scanView.CameraOpened += (s, e) => 
            {
                Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height);

                StartScanning();
            };

            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };
            
            _strictModeSwitch.CheckedChange += (sender, args) =>
            {
                // make sure scanning is stopped before setting this property
                _scanView.CancelScanning();
                // set this to true after InitAnyline if only a result should be found, when all check digits are valid
                _scanView.StrictMode = ((Switch)sender).Checked;

                StartScanning();
            };

            _cropResultSwitch.CheckedChange += (sender, args) =>
            {
                // make sure scanning is stopped before setting this property
                _scanView.CancelScanning();
                // set this to true after InitAnyline to receive a cropped image of the ID instead of the whole scanning area
                _scanView.CropAndTransformID = ((Switch)sender).Checked;

                StartScanning();
            };
        }

        private void StartScanning()
        {
            _mrzResultImageView?.SetImageBitmap(null);
            if(_resultView != null) _resultView.Visibility = ViewStates.Invisible;
            _scanView?.StartScanning();
        }

        void IMrzResultListener.OnResult(MrzResult scanResult)
        {
            _resultView.SetIdentification(scanResult.Result as Identification);
            _resultView.Visibility = ViewStates.Visible;
            
            _mrzResultImageView.SetImageBitmap(scanResult.CutoutImage.Bitmap);
        }

        void View.IOnClickListener.OnClick(View v)
        {
            StartScanning();
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

            _resultView?.Dispose();
            _resultView = null;

            _mrzResultImageView?.Dispose();
            _mrzResultImageView = null;

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }
    }
}