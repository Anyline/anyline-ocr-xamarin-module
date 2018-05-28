using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using AT.Nineyards.Anyline.Modules.Mrz;
using AT.Nineyards.Anylinexamarin.Support.Modules.Mrz;

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

            _resultView.SetOnClickListener(this);
            
            _scanView.SetConfigFromAsset("MrzConfig.json");

            _scanView.InitAnyline(MainActivity.LicenseKey, this);
                        
            _scanView.SetCancelOnResult(true);
            
            _scanView.CameraOpened += (s, e) => 
            {
                Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height);
                _resultView.Visibility = ViewStates.Invisible;
                _scanView.StartScanning();
            };

            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

            // set this to true after InitAnyline if only a result should be found, when all check digits are valid
            _scanView.StrictMode = false;
        }

        void IMrzResultListener.OnResult(MrzResult scanResult)
        {
            _resultView.SetIdentification(scanResult.Result as Identification);
            _resultView.Visibility = ViewStates.Visible;
        }

        void View.IOnClickListener.OnClick(View v)
        {
            _resultView.Visibility = ViewStates.Invisible;
            _scanView.StartScanning();
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

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }
    }
}