using AnylineXamarinApp.iOS.Modules.Energy.View;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using UIKit;

namespace AnylineXamarinApp.iOS.Modules.Energy.ViewController
{
    public class AnylineEnergyScanViewResultController : UIViewController
    {
        public ALScanMode ScanMode {get; set;}
        public UIImage MeterImage {get; set;}
        public string Result {get; set;}
        public string BarcodeResult { get; set; }

        EnergyMeterReadingView _meterReadingView;
        UIImageView _meterImageView;
        UILabel _barcodeResultLabel;

        public AnylineEnergyScanViewResultController(string result, ALScanMode scanMode, string barcodeResult)
        {
            Result = result;
            ScanMode = scanMode;
            BarcodeResult = barcodeResult;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitViews();
            SetupMeterReadingView();
        }

        private void InitViews()
        {
            Title = "";
            View.BackgroundColor = new UIColor(88.5f / 255f, 144f / 255f, 163f / 255f, 1f);

            _meterReadingView = new EnergyMeterReadingView(new CGRect(0, 100, View.Frame.Size.Width, 150));
            View.AddSubview(_meterReadingView);

            _meterImageView = new UIImageView(MeterImage);
            _meterImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            _meterImageView.Frame = new CGRect((View.Frame.Size.Width - 272)/2,280,272, 70);
            View.AddSubview(_meterImageView);

            _barcodeResultLabel = new UILabel();
            _barcodeResultLabel.Center = new CGPoint(View.Frame.Size.Width / 2, _meterImageView.Center.Y + _meterImageView.Frame.Size.Height);
            _barcodeResultLabel.TextColor = UIColor.White;
            _barcodeResultLabel.Font = UIFont.SystemFontOfSize(18);
            _barcodeResultLabel.LineBreakMode = UILineBreakMode.WordWrap;
            View.AddSubview(_barcodeResultLabel);

        }

        private void SetupMeterReadingView()
        {
            _meterReadingView.SetText(Result);

            _barcodeResultLabel.Text = "";

            if (BarcodeResult != "")
                _barcodeResultLabel.Text = "Barcode: " + BarcodeResult;

            _barcodeResultLabel.SizeToFit();
            _barcodeResultLabel.Center = new CGPoint(_barcodeResultLabel.Center.X - _barcodeResultLabel.Frame.Size.Width / 2, _barcodeResultLabel.Center.Y);
            Title = "Result";
        }
    }
}
