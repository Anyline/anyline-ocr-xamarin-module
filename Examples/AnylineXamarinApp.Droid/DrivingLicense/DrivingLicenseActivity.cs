using System;
using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Camera;
using IO.Anyline.Xamarin.Plugins.ID;
using IO.Anyline.Plugin;
using IO.Anyline.View;
using Java.Lang;
#pragma warning disable 618

namespace AnylineXamarinApp.DrivingLicense
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class DrivingLicenseActivity : Activity, IIdResultListener
    {
        public static string TAG = typeof(DrivingLicenseActivity).Name;
        
        private ScanView _scanView;
        private DrivingLicenseResultView _driverLicenseResultView;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetTitle(Resource.String.scan_driving_licenses);

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            SetContentView(Resource.Layout.DrivingLicenseActivity);

            InitDriverLicenseResultView();

            _scanView = FindViewById<ScanView>(Resource.Id.scan_view);

            _scanView.SetScanConfig("driving_license_view_config.json");
            
            // set an individual focus configuration for this example
            FocusConfig focusConfig = new FocusConfig.Builder()
                .SetDefaultMode(Camera.Parameters.FocusModeAuto) // set default focus mode to be auto focus
                .SetAutoFocusInterval(8000) // set an interval of 8 seconds for auto focus
                .SetEnableFocusOnTouch(true) // enable focus on touch functionality
                .SetEnablePhaseAutoFocus(true)  // enable phase focus for faster focusing on new devices
                .SetEnableFocusAreas(true)  // enable focus areas to coincide with the cutout
                .Build();

            _scanView.CameraView.SetFocusConfig(focusConfig);
            
            IdScanViewPlugin scanViewPlugin = new IdScanViewPlugin(ApplicationContext, 
                MainActivity.LicenseKey, _scanView.ScanViewPluginConfig, new IO.Anyline.Plugin.ID.DrivingLicenseConfig());

            scanViewPlugin.AddResultListener(this);
            _scanView.ScanViewPlugin = scanViewPlugin;

            _scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }
        
        private void InitDriverLicenseResultView()
        {
            RelativeLayout mainLayout = (RelativeLayout)FindViewById(Resource.Id.main_layout);

            _driverLicenseResultView = new DrivingLicenseResultView(this)
            {
                Visibility = ViewStates.Invisible
            };
                        
            //register click event
            _driverLicenseResultView.Click += (sender, args) =>
            {
                _driverLicenseResultView.Visibility = ViewStates.Invisible;
                _scanView.Start();                
            };
            
            //center the result in the parent
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);

            layoutParams.AddRule(LayoutRules.CenterInParent, (int)LayoutRules.True);
            mainLayout.AddView(_driverLicenseResultView, layoutParams);

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
            _driverLicenseResultView.Visibility = ViewStates.Invisible;
            _scanView.Start();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _scanView.Stop();
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

            _driverLicenseResultView?.Bg?.Dispose();
            _driverLicenseResultView?.Dispose();
            _scanView?.Dispose();
            _scanView = null;

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }
        
        public void OnResult(IdScanResult scanResult)
        {
            _driverLicenseResultView.Visibility = ViewStates.Visible;

            var result = scanResult.Result as IO.Anyline.Plugin.ID.DrivingLicenseResult;
            
            _driverLicenseResultView.SetDocumentNumber(result.LicenseNumber);
            _driverLicenseResultView.SetDayOfBirth(result.DateOfBirth);

            _driverLicenseResultView.SetName(result.SurName + " " + result.GivenName);
        }
    }
}