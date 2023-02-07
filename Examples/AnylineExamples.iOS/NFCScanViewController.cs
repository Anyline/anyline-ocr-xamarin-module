using System;
using AnylineExamples.iOS;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinAppiOS
{
    public class NFCScanViewController : UIViewController, IALScanPluginDelegate, IALNFCDetectorDelegate
    {

        ALScanView _scanView;
        ALNFCDetector _nfcDetector;
        UIView hintView;

        // keep the last values we read from the MRZ so we can retry reading NFC if NFC failed for reasons other than getting these details wrong
        string passportNumberForNFC;
        NSDate dateOfBirth;
        NSDate dateOfExpiry;

        public NFCScanViewController(string name)
        {
            Title = name;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            float hintMargin = 2;
            // Set the background color to black to have a nicer transition
            View.BackgroundColor = UIColor.Black;

            UILabel hintViewLabel = new UILabel(CGRect.Empty);
            hintView = new UIView(CGRect.Empty);

            hintViewLabel.Text = @"Scan MRZ";
            hintViewLabel.SizeToFit();

            hintView.AddSubview(hintViewLabel);

            hintView.Frame = new UIEdgeInsets(hintViewLabel.Frame.Top, hintViewLabel.Frame.Left, hintViewLabel.Frame.Bottom, hintViewLabel.Frame.Right)
                                            .InsetRect(new CGRect(-hintMargin, -hintMargin, -hintMargin, -hintMargin));
            hintView.Center = new CGPoint(View.Center.X, 0);
            hintViewLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            hintViewLabel.CenterYAnchor.ConstraintEqualToSystemSpacingBelowAnchor(hintView.CenterYAnchor, 0);
            hintViewLabel.CenterXAnchor.ConstraintEqualToSystemSpacingAfterAnchor(hintView.CenterXAnchor, 0);
            hintView.Layer.CornerRadius = 8;
            hintView.Layer.MasksToBounds = true;
            hintView.BackgroundColor = UIColor.Black.ColorWithAlpha(0.5f);
            hintViewLabel.TextColor = UIColor.White;
            View.AddSubview(hintView);

            _nfcDetector = new ALNFCDetector(this, out NSError nfcDetectorError);

            // Use the JSON file name that you want to load here
            var configPath = NSBundle.MainBundle.PathForResource("mrz_config", @"json");
            // This is the main intialization method that will create our use case depending on the JSON configuration.
            _scanView = ALScanViewFactory.WithConfigFilePath(configPath, this, out NSError scanViewError);

            if (scanViewError != null)
            {
                System.Diagnostics.Debug.WriteLine(scanViewError.ToString());
            }

            // After setup is complete we add the scanView to the view of this view controller
            View.AddSubview(_scanView);
            View.SendSubviewToBack(_scanView);

            var topGuide = TopLayoutGuide;

            var viewNames = NSDictionary.FromObjectsAndKeys(new object[] {
            _scanView,
            topGuide,
            }, new NSObject[] {
                new NSString("scanView"),
                new NSString("topGuide"),
            });
            var emptyDict = new NSDictionary();


            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[scanView]|", 0, emptyDict, viewNames));
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[topGuide]-0-[scanView]|", 0, emptyDict, viewNames));

            // Pin the leading edge of the scan view to the parent view

            _scanView.TranslatesAutoresizingMaskIntoConstraints = false;

            _scanView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
            _scanView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
            _scanView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
            _scanView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor).Active = true;


            _scanView.StartCamera();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            startMRZScanning();
        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            stopMRZScanning();
        }

        /*
           This method is used to tell Anyline to start scanning. It gets called in
           viewDidAppear to start scanning the moment the view appears. Once a result
           is found scanning will stop automatically (you can change this behaviour
           with cancelOnResult:). When the user dismisses self.identificationView this
           method will get called again.
         */
        private void startMRZScanning()
        {
            _scanView.ScanViewPlugin.StartWithError(out NSError scanViewStartError);
            hintView.Hidden = false;
        }

        private void stopMRZScanning()
        {
            _scanView.ScanViewPlugin.Stop();
            hintView.Hidden = true;
        }

        private void readNFCChip()
        {
            /*
             This is where we start reading the NFC chip of the passport. We use data from the MRZ to authenticate with the chip.
             */
            BeginInvokeOnMainThread(() =>
            {
                _nfcDetector.StartNfcDetectionWithPassportNumber(this.passportNumberForNFC, this.dateOfBirth, this.dateOfExpiry);
            });
        }

        [Export("scanPlugin:resultReceived:")]
        public void ResultReceived(ALScanPlugin scanPlugin, ALScanResult scanResult)
        {
            ALMrzResult mrzResult = scanResult.PluginResult.MrzResult;

            string passportNumber = mrzResult.DocumentNumber.Trim();
            string dateOfBirth = mrzResult.DateOfBirth;
            string dateOfExpiry = mrzResult.DateOfExpiry;
            //The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
            string mrzString = mrzResult.MrzString;
            string passportNumberForNFC = String.Copy(passportNumber);

            while (passportNumberForNFC.Length < 9)
            {
                passportNumberForNFC += "<";
            }

            stopMRZScanning();
            this.passportNumberForNFC = passportNumberForNFC;
            this.dateOfBirth = ConvertToNSDate(mrzResult.DateOfBirthObject);
            this.dateOfExpiry = ConvertToNSDate(mrzResult.DateOfExpiryObject);
            readNFCChip();
        }

        /// <summary>
        /// Converts date strings from this: "Sun Apr 12 00:00:00 UTC 1977" to this: "04/12/1977"
        /// </summary>
        /// <param name="dateString">Date string to be converted</param>
        /// <returns>NSDate of the informed date</returns>
        private NSDate ConvertToNSDate(string dateString)
        {
            NSDateFormatter dateFormatter = new NSDateFormatter();
            dateFormatter.TimeZone = NSTimeZone.FromAbbreviation("GMT+0:00");
            dateFormatter.DateFormat = @"E MMM d HH:mm:ss zzz yyyy";
            dateFormatter.Locale = NSLocale.FromLocaleIdentifier("en_US_POSIX");
            NSDate nsDate = dateFormatter.Parse(dateString);
            return nsDate;
        }

        public void NfcSucceededWithResult(ALNFCResult nfcResult)
        {
            BeginInvokeOnMainThread(() => { 
                var resultViewController = new ResultViewController(nfcResult, Title);
                NavigationController?.PushViewController(resultViewController, false);
            });
        }

        public void NfcFailedWithError(NSError error)
        {
            System.Diagnostics.Debug.WriteLine(error.DebugDescription);
            BeginInvokeOnMainThread(() =>
            {
                if (error.Code == (int)ALErrorCode.NFCTagErrorNFCNotSupported)
                {
                    this._nfcDetector.Dispose();
                    var okAlertController = UIAlertController.Create("NFC Not Supported", "NFC passport reading is not supported on this device", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    PresentViewController(okAlertController, true, null);
                }
                if (error.Code == (int)ALErrorCode.NFCTagErrorResponseError || //error ALNFCTagErrorResponseError can mean the MRZ key was wrong
                    error.Code == (int)ALErrorCode.NFCTagErrorUnexpectedError) //error ALNFCTagErrorUnexpectedError can mean the user pressed the 'Cancel' button while scanning. It could also mean the phone lost the connection with the NFC chip because it was moved.
                {
                    startMRZScanning(); //run the MRZ scanner so we can try again.
                }
                else
                {
                    //the MRZ details are correct, but something else went wrong. We can try reading the NFC chip again without rescanning the MRZ.
                    readNFCChip();
                }
            });
        }

        void updateHintPosition(nfloat newPosition)
        {
            hintView.Center = new CGPoint(hintView.Center.X, newPosition);
        }


        //private class CutoutListener : ALScanViewPluginDelegate
        //{
        //    private Action<nfloat> updateHintPosition;
        //    private ALScanView scanView;

        //    public CutoutListener(Action<nfloat> updateHintPosition, ALScanView scanView)
        //    {
        //        this.updateHintPosition = updateHintPosition;
        //        this.scanView = scanView;
        //    }

        //    public override void UpdatedCutout(ALAbstractScanViewPlugin anylineScanViewPlugin, CGRect cutoutRect)
        //    {
        //        updateHintPosition.Invoke(cutoutRect.Y + scanView.Frame.Y - 50);
        //    }
        //}
    }
}