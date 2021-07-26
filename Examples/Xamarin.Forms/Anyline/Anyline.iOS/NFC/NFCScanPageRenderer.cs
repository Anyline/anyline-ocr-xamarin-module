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
    public class NFCScanPageRenderer : PageRenderer, IALIDPluginDelegate, IALNFCDetectorDelegate
    {
        private CGRect frame;
        private bool initialized;

        private ALScanView _scanView;

        ALNFCDetector nfcDetector;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null) return;

            InitializeAnyline();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            nfcDetector = new ALNFCDetector(this);
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

                frame = View.Bounds;

                string configurationFile = (Element as NFCScanExamplePage).ConfigurationFile.Replace(".json", "");

                // Use the JSON file name that you want to load here
                var configPath = NSBundle.MainBundle.PathForResource(configurationFile, @"json");
                // This is the main intialization method that will create our use case depending on the JSON configuration.
                _scanView = ALScanView.ScanViewForFrame(frame, configPath, this, out error);

                if (error != null)
                {
                    throw new Exception(error.LocalizedDescription);
                }

                (_scanView.ScanViewPlugin as ALIDScanViewPlugin)?.IdScanPlugin.AddDelegate(this);

                View.AddSubview(_scanView);
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
            var success = _scanView.ScanViewPlugin.StartAndReturnError(out error);
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

        public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        {
            ALMRZIdentification mrzIdentification = (ALMRZIdentification)scanResult.Result;

            // Sends the MRZ results back to the Xamarin Forms application
            MyMRZScanResults myMRZScanResults = new MyMRZScanResults
            {
                GivenNames = mrzIdentification.GivenNames,
                Surname = mrzIdentification.Surname,
                CutoutImage = scanResult.Image.AsJPEG().ToArray(),
                FullImage = scanResult.FullImage.AsJPEG().ToArray(),
                FaceImage = mrzIdentification.FaceImage.AsJPEG().ToArray(),
                PassportNumber = mrzIdentification.DocumentNumber.Trim(),
                DateOfBirth = mrzIdentification.DateOfBirth,
                DateOfExpiry = mrzIdentification.DateOfExpiry
            };
            MessagingCenter.Send(App.Current, "MRZ_READING_DONE", myMRZScanResults);

            // Gets the data necessary for the NFC reading
            string passportNumber = mrzIdentification.DocumentNumber.Trim();
            NSDate dateOfBirth = mrzIdentification.DateOfBirthObject;
            NSDate dateOfExpiry = mrzIdentification.DateOfExpiryObject;

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
                nfcDetector.StartNfcDetectionWithPassportNumber(passportNumberForNFC, dateOfBirth, dateOfExpiry);
            });
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

            NSError error;
            _scanView.ScanViewPlugin.StopAndReturnError(out error);
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