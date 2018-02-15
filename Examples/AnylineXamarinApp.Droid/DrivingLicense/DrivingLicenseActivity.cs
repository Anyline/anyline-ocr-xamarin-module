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
#pragma warning disable 618

namespace AnylineXamarinApp.DrivingLicense
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class DrivingLicenseActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(DrivingLicenseActivity).Name;

        private AnylineOcrScanView _scanView;
        private DrivingLicenseResultView _driverLicenseResultView;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetTitle(Resource.String.scan_driving_licenses);

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            SetContentView(Resource.Layout.OCRActivity);

            InitDriverLicenseResultView();

            _scanView = FindViewById<AnylineOcrScanView>(Resource.Id.ocr_scan_view);

            _scanView.SetConfigFromAsset("DriverLicenseConfig.json");
            
            SetOcrConfig(_scanView);
            
            // set an individual focus configuration for this example
            FocusConfig focusConfig = new FocusConfig.Builder()
                .SetDefaultMode(Camera.Parameters.FocusModeAuto) // set default focus mode to be auto focus
                .SetAutoFocusInterval(8000) // set an interval of 8 seconds for auto focus
                .SetEnableFocusOnTouch(true) // enable focus on touch functionality
                .SetEnablePhaseAutoFocus(true)  // enable phase focus for faster focusing on new devices
                .SetEnableFocusAreas(true)  // enable focus areas to coincide with the cutout
                .Build();

            _scanView.SetFocusConfig(focusConfig);

            _scanView.SetUseMaxFpsRange(true);

            // set sports scene mode to try and bump up the fps count even more
            _scanView.SetSceneMode(Camera.Parameters.SceneModeSports);

            _scanView.InitAnyline(MainActivity.LicenseKey, this);

            _scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }

        private static void SetOcrConfig(AnylineOcrScanView scanView)
        {
            //Configure the OCR for Driver Licenses
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            anylineOcrConfig.CustomCmdFile = "anyline_austrian_driver_license.ale";
            anylineOcrConfig.SetLanguages("tessdata/eng_no_dict.traineddata", "tessdata/deu.traineddata");
            
            scanView.SetAnylineOcrConfig(anylineOcrConfig);
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
                _scanView.StartScanning();                
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

            _driverLicenseResultView?.Bg?.Dispose();
            _driverLicenseResultView?.Dispose();
            _scanView?.Dispose();

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }

        void IAnylineOcrResultListener.OnResult(AnylineOcrResult scanResult)
        {
            _driverLicenseResultView.Visibility = ViewStates.Visible;
            
            // This is called when a result is found.
            // The Identification includes all the data read from the driving license
            // as scanned and the given image shows the scanned driving license
            string resultString = scanResult.Result.ToString();
            string[] results = resultString.Split('|');

            string[] birthdateDocNumber = results[1].Split(' ');
            
            _driverLicenseResultView.SetDocumentNumber(birthdateDocNumber[1]);
            _driverLicenseResultView.SetDayOfBirth(birthdateDocNumber[0]);
            _driverLicenseResultView.SetName(results[0]);

        }
    }
}