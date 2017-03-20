using Android.App;
using Android.OS;
using AT.Nineyards.Anyline.Modules.Ocr;
using AT.Nineyards.Anylinexamarin.Support.Modules.Ocr;
#pragma warning disable 618

namespace AnylineXamarinApp.Ocr
{
    [Activity(Label = "", MainLauncher = false, Icon = "@drawable/ic_launcher", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, HardwareAccelerated = true)]
    public class LicensePlateActivityGermany : LicensePlateActivity, IAnylineOcrResultListener
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetTitle(Resource.String.scan_license_plates_germany);

            //Configure the OCR for License Plates
            AnylineOcrConfig anylineOcrConfig = new AnylineOcrConfig();

            anylineOcrConfig.CustomCmdFile = "license_plates_d.ale";

            scanView.SetAnylineOcrConfig(anylineOcrConfig);
        }
    }
}