using System;
using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Camera;
using AT.Nineyards.Anyline.Modules.Ocr;
using AT.Nineyards.Anyline.Util;
using AT.Nineyards.Anylinexamarin.Support.Modules.Ocr;
#pragma warning disable 618

namespace AnylineXamarinApp.Ocr
{
    [Activity(Label = "Scan Voucher Codes", MainLauncher = false, Icon = "@drawable/ic_launcher", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public class VoucherCodeActivity : Activity, IAnylineOcrResultListener
    {
        public static string TAG = typeof(VoucherCodeActivity).Name;

        private AnylineOcrScanView _scanView;
        private OcrResultView _voucherCodeResultView;
        
        protected override void OnCreate(Bundle bundle)
        {

            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            
            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.OCRActivity);
            
            _scanView = FindViewById<AnylineOcrScanView>(Resource.Id.ocr_scan_view);

            //set up the voucher code result view
            InitVoucherCodeResultView();
            
            _scanView.SetConfigFromAsset("VoucherCodeConfig.json");

            _scanView.CopyTrainedData("tessdata/anyline_capitals.traineddata", "cee65c74833eb85e3c31e213b25e72a2");

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

        private void InitVoucherCodeResultView()
        {
            RelativeLayout mainLayout = (RelativeLayout)FindViewById(Resource.Id.main_layout);

            _voucherCodeResultView = new OcrResultView(this)
            {
                Visibility = ViewStates.Invisible
            };

            _voucherCodeResultView.Bg.SetImageResource(Resource.Drawable.gift_card_background);

            //register click event
            _voucherCodeResultView.Click += (sender, args) =>
            {
                _voucherCodeResultView.Visibility = ViewStates.Invisible;
                _scanView.StartScanning();
            };

            //set text properties
            _voucherCodeResultView.ResultText.TextAlignment = TextAlignment.TextStart;
            _voucherCodeResultView.ResultText.TextSize = 18;
            _voucherCodeResultView.ResultText.Typeface = Android.Graphics.Typeface.Default;
            _voucherCodeResultView.ResultText.SetTextColor(Android.Graphics.Color.White);

            //set text position
            ((RelativeLayout.LayoutParams)_voucherCodeResultView.ResultText.LayoutParameters)
                .SetMargins(0, DimensUtil.GetPixFromDp(this, 35), 0, 0);
            
            //center text
            ((RelativeLayout.LayoutParams)_voucherCodeResultView.ResultText.LayoutParameters)
                .AddRule(LayoutRules.CenterHorizontal, (int)LayoutRules.True);

            //center the result in the parent
            RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent,
                ViewGroup.LayoutParams.WrapContent);

            layoutParams.AddRule(LayoutRules.CenterInParent, (int)LayoutRules.True);

            mainLayout.AddView(_voucherCodeResultView, layoutParams);

        }

        private void SetOcrConfig(AnylineOcrScanView scanView)
        {
            //Configure the OCR for IBANs
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            // use the line mode (line length and font may vary)
            anylineOcrConfig.SetScanMode(AnylineOcrConfig.ScanMode.Line);

            // set the languages used for OCR
            anylineOcrConfig.SetTesseractLanguages("anyline_capitals");

            // allow only capital letters and numbers
            anylineOcrConfig.CharWhitelist = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            // set the height range the text can have
            anylineOcrConfig.MinCharHeight = 45;
            anylineOcrConfig.MaxCharHeight = 85;

            // The minimum confidence required to return a result, a value between 0 and 100.
            // (higher confidence means less likely to get a wrong result, but may be slower to get a result)
            anylineOcrConfig.MinConfidence = 85;

            // a simple regex for a basic validation of the IBAN, results that don't match this, will not be returned
            // (full validation is more complex, as different countries have different formats)
            anylineOcrConfig.ValidationRegex = "[A-Z0-9]{8}$";

            // removes small contours (helpful in this case as no letters with small artifacts are allowed, like iöäü)
            anylineOcrConfig.RemoveSmallContours = true;

            // Experimental parameter to set the minimum sharpness (value between 0-100; 0 to turn sharpness detection off)
            // The goal of the minimum sharpness is to avoid a time consuming ocr step,
            // if the image is blurry and good results are therefore not likely.
            anylineOcrConfig.MinSharpness = 60;

            // scan white text on black backgroundd
            anylineOcrConfig.IsBrightTextOnDark = true;
            
            // set the ocr config
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

            _voucherCodeResultView?.Bg?.Dispose();
            _voucherCodeResultView?.Dispose();
            _scanView?.Dispose();

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }

        void IAnylineOcrResultListener.OnResult(AnylineOcrResult scanResult)
        {
            _voucherCodeResultView.Visibility = ViewStates.Visible;
            _voucherCodeResultView.ResultText.Text = scanResult.Result.ToString().Trim();
        }
    }
}