using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnylineExamples.iOS;
using AnylineXamarinSDK.iOS;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AnylineXamarinAppiOS
{
    public class NFCScanViewController : UIViewController, IALIDPluginDelegate, IALNFCDetectorDelegate
    {

        ALIDScanViewPlugin mrzScanViewPlugin;
        ALIDScanPlugin mrzScanPlugin;
        ALScanView scanView;
        ALNFCDetector nfcDetector;
        UIView hintView;

        //keep the last values we read from the MRZ so we can retry reading NFC if NFC failed for reasons other than getting these details wrong
        string passportNumberForNFC;
        NSDate dateOfBirth;
        NSDate dateOfExpiry;




        public NFCScanViewController(string name, string v)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Passport NFC";
            float hintMargin = 7;
            // Set the background color to black to have a nicer transition
            View.BackgroundColor = UIColor.Black;

            UILabel hintViewLabel = new UILabel(CGRect.Empty);
            hintViewLabel.Text = @"Scan MRZ";
            hintViewLabel.SizeToFit();

            UIView hintView = new UIView(CGRect.Empty);
            hintView.AddSubview(hintViewLabel);

            hintView.Frame = new UIEdgeInsets(hintViewLabel.Frame.Top, hintViewLabel.Frame.Left, hintViewLabel.Frame.Bottom, hintViewLabel.Frame.Right)
                .InsetRect(new CGRect(-hintMargin, -hintMargin, -hintMargin, -hintMargin));
            hintView.Center = new CGPoint(View.Center);
            hintViewLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            hintViewLabel.CenterYAnchor.ConstraintEqualToSystemSpacingBelowAnchor(hintView.CenterYAnchor, 0);
            hintViewLabel.CenterXAnchor.ConstraintEqualToSystemSpacingAfterAnchor(hintView.CenterXAnchor, 0);
            hintView.Layer.CornerRadius = 8;
            hintView.Layer.MasksToBounds = true;
            hintView.BackgroundColor = UIColor.Black.ColorWithAlpha(0.5f);
            hintViewLabel.TextColor = UIColor.White;
            this.hintView = hintView;
            View.AddSubview(hintView);


            ALMRZConfig mrzConfig = new ALMRZConfig();
            //we want to be quite confident of these fields to ensure we can read the NFC with them
            ALMRZFieldConfidences fieldConfidences = new ALMRZFieldConfidences();
            fieldConfidences.DocumentNumber = 90;
            fieldConfidences.DateOfBirth = 90;
            fieldConfidences.DateOfExpiry = 90;
            mrzConfig.IdFieldConfidences = fieldConfidences;

            //Create fieldScanOptions to configure individual scannable fields
            ALMRZFieldScanOptions scanOptions = new ALMRZFieldScanOptions();
            scanOptions.VizAddress = ALFieldScanOption.Default;
            scanOptions.VizDateOfIssue = ALFieldScanOption.Default;
            scanOptions.VizSurname = ALFieldScanOption.Default;
            scanOptions.VizGivenNames = ALFieldScanOption.Default;
            scanOptions.VizDateOfBirth = ALFieldScanOption.Default;
            scanOptions.VizDateOfExpiry = ALFieldScanOption.Default;

            //Set scanOptions for MRZConfig
            mrzConfig.IdFieldScanOptions = scanOptions;

            NSError error = null;

            //Init the anyline ID ScanPlugin with an ID, Licensekey, the delegate,
            //  the MRZConfig (which will configure the scan Plugin for MRZ scanning), and an error
            this.mrzScanPlugin = new ALIDScanPlugin(@"ModuleID", AnylineViewController.LicenseKey, this, mrzConfig, out error);


            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                nfcDetector = new ALNFCDetector(AnylineViewController.LicenseKey, this);
            }
            else
            {
                // Fallback on earlier versions
            }

            mrzScanViewPlugin = new ALIDScanViewPlugin(mrzScanPlugin);

            var frame = UIScreen.MainScreen.ApplicationFrame;
            frame = new CGRect(frame.X,
                frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
                frame.Width,
                frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            // Use the JSON file name that you want to load here
            var configPath = NSBundle.MainBundle.PathForResource(@"" + "id_config_mrz", @"json");

            // This is the main intialization method that will create our use case depending on the JSON configuration.
            scanView = new ALScanView(frame, mrzScanViewPlugin);

            scanView.FlashButtonConfig.FlashAlignment = ALFlashAlignment.TopLeft;

            //self.controllerType = ALScanHistoryNFC;

            // After setup is complete we add the scanView to the view of this view controller
            View.AddSubview(scanView);
            View.SendSubviewToBack(scanView);


            scanView.StartCamera();
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
            NSError error = null;
            mrzScanViewPlugin.StartAndReturnError(out error);
            hintView.Hidden = false;
        }

        private void stopMRZScanning()
        {
            NSError error = null;
            mrzScanViewPlugin.StopAndReturnError(out error);
            hintView.Hidden = true;
        }

        private void readNFCChip()
        {
            /*
             This is where we start reading the NFC chip of the passport. We use data from the MRZ to authenticate with the chip.
             */
            BeginInvokeOnMainThread(() =>
            {
                this.nfcDetector.StartNfcDetectionWithPassportNumber(this.passportNumberForNFC, this.dateOfBirth, this.dateOfExpiry);
            });
        }

        public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        {
            ALMRZIdentification identification = (ALMRZIdentification)scanResult.Result;
            string passportNumber = identification.DocumentNumber.Trim();
            NSDate dateOfBirth = identification.DateOfBirthObject;
            NSDate dateOfExpiry = identification.DateOfExpiryObject;
            //The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
            string mrzString = identification.MrzString;
            string passportNumberForNFC = String.Copy(passportNumber);

            NSRange passportNumberRange = new NSString(mrzString).LocalizedStandardRangeOfString(new NSString(passportNumber));
            if (passportNumberRange.Location != null)
            {
                if (mrzString[(int)passportNumberRange.Location + (int)passportNumberRange.Length] == '<')
                {
                    passportNumberForNFC += "<";
                }
            }

            stopMRZScanning();
            this.passportNumberForNFC = passportNumberForNFC;
            this.dateOfBirth = dateOfBirth;
            this.dateOfExpiry = dateOfExpiry;
            readNFCChip();
        }

        public void NfcSucceededWithResult(ALNFCResult nfcResult)
        {
            var resultViewController = new ResultViewController(nfcResult);
            BeginInvokeOnMainThread(() => NavigationController?.PushViewController(resultViewController, false));
        }

        public void NfcFailedWithError(NSError error)
        {
            System.Diagnostics.Debug.WriteLine(error.DebugDescription);
            BeginInvokeOnMainThread(() => startMRZScanning());
        }
    }
}