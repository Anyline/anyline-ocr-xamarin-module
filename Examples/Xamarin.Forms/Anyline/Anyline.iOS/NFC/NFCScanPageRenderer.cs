using System;
using Anyline.NFC;
using Anyline.iOS.NFC;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NFCScanExamplePage), typeof(NFCScanPageRenderer))]
namespace Anyline.iOS.NFC
{
    public class NFCScanPageRenderer : PageRenderer, IALScanPluginDelegate, IALNFCDetectorDelegate
    {
        private CGRect frame;
        private bool initialized;

        private ALScanView _scanView;

        ALNFCDetector _nfcDetector;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null) return;

            InitializeAnyline();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _nfcDetector = new ALNFCDetector(this, out NSError error);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (!initialized) return;

            StartMRZScanner();
        }

        private void InitializeAnyline()
        {
            if (initialized) return;

            try
            {
                NSError error = null;

                string configurationFile = (Element as NFCScanExamplePage).ConfigurationFile.Replace(".json", "");

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(configurationFile, @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _scanView = ALScanViewFactory.WithConfigFilePath(configPath, this, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                View.AddSubview(_scanView);

                // Pin the leading edge of the scan view to the parent view

                _scanView.TranslatesAutoresizingMaskIntoConstraints = false;

                _scanView.LeadingAnchor.ConstraintEqualTo(View.LeadingAnchor).Active = true;
                _scanView.TrailingAnchor.ConstraintEqualTo(View.TrailingAnchor).Active = true;
                _scanView.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor).Active = true;
                _scanView.BottomAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.BottomAnchor).Active = true;

                _scanView.StartCamera();

                initialized = true;
            }
            catch (Exception e)
            {
                ShowAlert("Init Error", e.Message);
            }
        }

        private void StartMRZScanner()
        {
            NSError error = null;
            var success = _scanView.ScanViewPlugin.StartWithError(out error);
            if (!success)
            {
                if (error != null)
                    ShowAlert("Start Scanning Error", error.DebugDescription);
                else
                    ShowAlert("Start Scanning Error", "error is null");
            }
        }

        private void ShowAlert(string title, string text)
        {
            new UIAlertView(title, text, (IUIAlertViewDelegate)null, "OK", null).Show();
        }

        [Export("scanPlugin:resultReceived:")]
        public void ResultReceived(ALScanPlugin scanPlugin, ALScanResult scanResult)
        {
            ALMrzResult mrzResult = scanResult.PluginResult.MrzResult;

            // Sends the MRZ results back to the Xamarin Forms application
            MyMRZScanResults myMRZScanResults = new MyMRZScanResults
            {
                GivenNames = mrzResult.GivenNames,
                Surname = mrzResult.Surname,
                CroppedImage = scanResult.CroppedImage.AsJPEG().ToArray(),
                FullImage = scanResult.FullSizeImage.AsJPEG().ToArray(),
                FaceImage = scanResult.FaceImage.AsJPEG().ToArray(),
                PassportNumber = mrzResult.DocumentNumber.Trim(),
                DateOfBirth = mrzResult.DateOfBirth,
                DateOfExpiry = mrzResult.DateOfExpiry
            };
            MessagingCenter.Send(App.Current, "MRZ_READING_DONE", myMRZScanResults);

            // Gets the data necessary for the NFC reading
            string passportNumber = mrzResult.DocumentNumber.Trim();
            NSDate dateOfBirth = ConvertToNSDate(mrzResult.DateOfBirthObject);
            NSDate dateOfExpiry = ConvertToNSDate(mrzResult.DateOfExpiryObject);

            // The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
            string passportNumberForNFC = String.Copy(passportNumber);
            while (passportNumberForNFC.Length < 9)
            {
                passportNumberForNFC += "<";
            }

            // This is where we start reading the NFC chip of the passport.
            // We use data from the MRZ to authenticate with the chip.
            BeginInvokeOnMainThread(() =>
            {
                _nfcDetector.StartNfcDetectionWithPassportNumber(passportNumberForNFC, dateOfBirth, dateOfExpiry);
            });
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

        #region NFC Result
        public void NfcSucceededWithResult(ALNFCResult nfcResult)
        {
            MyNFCScanResults myNFCScanResults = new MyNFCScanResults
            {
                FirstName = nfcResult.DataGroup1.FirstName,
                LastName = nfcResult.DataGroup1.LastName, // The Last Name is returned without the spaces between the names (eg. SURNAME1SURNAME2)
                Gender = nfcResult.DataGroup1.Gender,
                DocumentNumber = nfcResult.DataGroup1.DocumentNumber,
                DateOfBirth = nfcResult.DataGroup1.DateOfBirth.ToString(),
                DateOfExpiry = nfcResult.DataGroup1.DateOfExpiry.ToString(),
                DocumentType = nfcResult.DataGroup1.DocumentType,
                IssuingStateCode = nfcResult.DataGroup1.IssuingStateCode,
                Nationality = nfcResult.DataGroup1.Nationality,
                FaceImage = nfcResult.DataGroup2.FaceImage.AsJPEG().ToArray()
            };

            // Sends the parsed results to the Message Listener (in this example, the NFCScanExamplePage)
            MessagingCenter.Send(App.Current, "NFC_SCAN_FINISHED_SUCCESS", myNFCScanResults);
        }

        public void NfcFailedWithError(NSError error)
        {
            MessagingCenter.Send(App.Current, "NFC_SCAN_FINISHED_ERROR", error.ToString());
            StartMRZScanner();
        }
        #endregion

        #region teardown
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            initialized = false;

            if (_scanView?.ScanViewPlugin == null)
                return;

            _scanView.ScanViewPlugin.Stop();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            Dispose();
        }

        new void Dispose()
        {
            _scanView?.RemoveFromSuperview();
            _scanView?.Dispose();
            _scanView = null;
            base.Dispose();
        }
        #endregion
    }
}
