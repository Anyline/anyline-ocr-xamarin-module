using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Modules.LicensePlate;
using AT.Nineyards.Anylinexamarin.Support.Modules.LicensePlate;
#pragma warning disable 618

namespace AnylineXamarinApp.LicensePlate
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class LicensePlateActivity : Activity, ILicensePlateResultListener
    {
        public static string TAG = typeof(LicensePlateActivity).Name;
        
        protected LicensePlateScanView scanView;
        private LicensePlateResultView _licensePlateResultView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetTitle(Resource.String.scan_license_plates);

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            SetContentView(Resource.Layout.LicensePlateActivity);

            InitLicensePlateResultView();

            scanView = FindViewById<LicensePlateScanView>(Resource.Id.license_plate_scan_view);

            scanView.SetConfigFromAsset("LicensePlateConfig.json");
            
            scanView.InitAnyline(MainActivity.LicenseKey, this);

            scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }
        
        private void InitLicensePlateResultView()
        {
            RelativeLayout mainLayout = (RelativeLayout)FindViewById(Resource.Id.main_layout);

            _licensePlateResultView = new LicensePlateResultView(this)
            {
                Visibility = ViewStates.Invisible
            };

            _licensePlateResultView.Bg.SetImageResource(Resource.Drawable.license_plate_background);

            //register click event
            _licensePlateResultView.Click += (sender, args) =>
            {
                _licensePlateResultView.Visibility = ViewStates.Invisible;
                scanView.StartScanning();
            };

            //set text properties
            _licensePlateResultView.ResultText.TextAlignment = TextAlignment.Center;
            _licensePlateResultView.ResultText.TextSize = 36;
            _licensePlateResultView.ResultText.Typeface = Android.Graphics.Typeface.DefaultBold;
            _licensePlateResultView.ResultText.SetTextColor(Android.Graphics.Color.Black);

            var textParams = (RelativeLayout.LayoutParams)_licensePlateResultView.ResultText.LayoutParameters;

            //center text
            textParams.AddRule(LayoutRules.CenterHorizontal, (int)LayoutRules.True);
            textParams.AddRule(LayoutRules.CenterVertical, (int)LayoutRules.True);

            _licensePlateResultView.ResultText.LayoutParameters = textParams;

            //center the result in the parent
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);

            layoutParams.AddRule(LayoutRules.CenterInParent, (int)LayoutRules.True);

            mainLayout.AddView(_licensePlateResultView, layoutParams);
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
            scanView.StartScanning();
        }

        protected override void OnPause()
        {
            base.OnPause();
            scanView.CancelScanning();
            scanView.ReleaseCameraInBackground();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _licensePlateResultView?.Bg?.Dispose();
            _licensePlateResultView?.Dispose();
            _licensePlateResultView?.Dispose();

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }

        public void OnResult(LicensePlateResult scanResult)
        {
            var country = scanResult.Country;
            var textResult = scanResult.Result.ToString();

            _licensePlateResultView.Visibility = ViewStates.Visible;

            if (country != "")
                textResult = $"{country} - {textResult}";

            _licensePlateResultView.ResultText.Text = textResult;
        }
    }
}