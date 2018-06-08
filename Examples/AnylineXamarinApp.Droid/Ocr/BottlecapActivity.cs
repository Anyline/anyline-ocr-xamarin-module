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

namespace AnylineXamarinApp.Ocr
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class BottlecapActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(BottlecapActivity).Name;

        private AnylineOcrScanView _scanView;
        private OcrResultView _bottlecapResultView;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetTitle(Resource.String.scan_bottlecaps);

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            SetContentView(Resource.Layout.OCRActivity);

            InitBottlecapResultView();

            _scanView = FindViewById<AnylineOcrScanView>(Resource.Id.ocr_scan_view);

            _scanView.SetConfigFromAsset("BottlecapViewConfig.json");
            
            // as of 3.20, use AnylineOcrConfig.SetLanguages(...) instead of CopyTraineddata and SetTesseractLanguages
            //_scanView.CopyTrainedData("tessdata/bottlecap.traineddata", "a8224bfaf4d2085f5b0de7018dee29eb");
            
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
            
            _scanView.InitAnyline(MainActivity.LicenseKey, this);

            _scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }

        private static void SetOcrConfig(AnylineOcrScanView scanView)
        {            
            //Configure the OCR for IBANs
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            anylineOcrConfig.SetScanMode(AnylineOcrConfig.ScanMode.Grid);

            // SetTesseractLanguages is obsolete as of 3.20. Use SetLanguages instead
            //anylineOcrConfig.SetTesseractLanguages("bottlecap");
            anylineOcrConfig.SetLanguages("tessdata/bottlecap.traineddata");

            anylineOcrConfig.CharWhitelist = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            anylineOcrConfig.MinCharHeight = 14;
            anylineOcrConfig.MaxCharHeight = 65;
            anylineOcrConfig.MinConfidence = 75;
            anylineOcrConfig.ValidationRegex = "^[0-9A-Z]{3}\n[0-9A-Z]{3}\n[0-9A-Z]{3}";            
            anylineOcrConfig.CharCountX = 3;
            anylineOcrConfig.CharCountY = 3;
            anylineOcrConfig.CharPaddingXFactor = .3;
            anylineOcrConfig.CharPaddingYFactor = .5;
            anylineOcrConfig.IsBrightTextOnDark = true;
            
            scanView.SetAnylineOcrConfig(anylineOcrConfig);
        }

        private void InitBottlecapResultView()
        {
            RelativeLayout mainLayout = (RelativeLayout)FindViewById(Resource.Id.main_layout);

            _bottlecapResultView = new OcrResultView(this)
            {
                Visibility = ViewStates.Invisible
            };


            _bottlecapResultView.Bg.SetImageResource(Resource.Drawable.bottle_background);

            //register click event
            _bottlecapResultView.Click += (sender, args) =>
            {
                _bottlecapResultView.Visibility = ViewStates.Invisible;
                _scanView.StartScanning();                
            };
            
            //set text properties
            _bottlecapResultView.ResultText.TextAlignment = TextAlignment.Center;
            _bottlecapResultView.ResultText.TextSize = 18;
            _bottlecapResultView.ResultText.Typeface = Android.Graphics.Typeface.DefaultBold;
            _bottlecapResultView.ResultText.SetTextColor(Android.Graphics.Color.Black);

            var textParams = (RelativeLayout.LayoutParams)_bottlecapResultView.ResultText.LayoutParameters;
                        
            //center text
            textParams.AddRule(LayoutRules.CenterHorizontal, (int)LayoutRules.True);
            textParams.AddRule(LayoutRules.CenterVertical, (int)LayoutRules.True);

            _bottlecapResultView.ResultText.LayoutParameters = textParams;

            //center the result in the parent
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);

            layoutParams.AddRule(LayoutRules.CenterInParent, (int)LayoutRules.True);

            mainLayout.AddView(_bottlecapResultView, layoutParams);

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
            _bottlecapResultView.Visibility = ViewStates.Invisible;
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

            _bottlecapResultView?.Bg?.Dispose();
            _bottlecapResultView?.Dispose();
            _scanView?.Dispose();
            _scanView = null;

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }

        void IAnylineOcrResultListener.OnResult(AnylineOcrResult scanResult)
        {
            _bottlecapResultView.Visibility = ViewStates.Visible;
            _bottlecapResultView.ResultText.Text = scanResult.Result.ToString().Trim();
        }        
    }
}