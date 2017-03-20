using AnylineXamarinSDK.iOS;
using Foundation;

namespace AnylineXamarinApp.iOS.Modules.OCR.ViewController
{
    public sealed class AnylineLicensePlateAtScanViewController : AnylineLicensePlateScanViewController
    {        
        public AnylineLicensePlateAtScanViewController(string name) : base(name)
        {
            Title = name;
        }

        public override void SetupLicensePlateConfig()
        {
            // We'll define the OCR Config here:
            OcrConfig = new ALOCRConfig
            {
                CustomCmdFilePath = NSBundle.MainBundle.PathForResource(@"Modules/OCR/license_plates_a", @"ale")
            };
        }        
    }
}
