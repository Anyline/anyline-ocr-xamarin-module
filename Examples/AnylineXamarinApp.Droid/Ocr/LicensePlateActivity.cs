using System;
using Android.App;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
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
    public class LicensePlateActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(LicensePlateActivity).Name;

        protected AnylineOcrScanView scanView;
        private OcrResultView _licensePlateResultView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetTitle(Resource.String.scan_license_plates);

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            SetContentView(Resource.Layout.OCRActivity);

            InitLicensePlateResultView();

            scanView = FindViewById<AnylineOcrScanView>(Resource.Id.ocr_scan_view);

            scanView.SetConfigFromAsset("LicensePlateConfig.json");
            
            scanView.CopyTrainedData("tessdata/GL-Nummernschild-Mtl7_uml.traineddata",
                "8ea050e8f22ba7471df7e18c310430d8");
            scanView.CopyTrainedData("tessdata/Arial.traineddata", "9a5555eb6ac51c83cbb76d238028c485");
            scanView.CopyTrainedData("tessdata/Alte.traineddata", "f52e3822cdd5423758ba19ed75b0cc32");
            scanView.CopyTrainedData("tessdata/deu.traineddata", "2d5190b9b62e28fa6d17b728ca195776");

            SetOcrConfig(scanView);

            scanView.InitAnyline(MainActivity.LicenseKey, this);

            scanView.CameraOpened += (s, e) => { Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height); };
            scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }

        private static void SetOcrConfig(AnylineOcrScanView scanView)
        {
            //Configure the OCR for License Plates
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            anylineOcrConfig.CustomCmdFile = "license_plates.ale";
            
            scanView.SetAnylineOcrConfig(anylineOcrConfig);
        }

        private void InitLicensePlateResultView()
        {
            RelativeLayout mainLayout = (RelativeLayout)FindViewById(Resource.Id.main_layout);

            _licensePlateResultView = new OcrResultView(this)
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

        void IAnylineOcrResultListener.OnResult(AnylineOcrResult scanResult)
        {
            var textResult = scanResult.Result.ToString();

            _licensePlateResultView.Visibility = ViewStates.Visible;
            var text = textResult.Split('-');
            if (text.Length > 1 && text[0] != "")
                _licensePlateResultView.ResultText.Text = textResult;
            else
                _licensePlateResultView.ResultText.Text = textResult.Split('-')[1];
        }        
    }
}