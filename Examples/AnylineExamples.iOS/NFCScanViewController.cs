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
    public class NFCScanViewController : UIViewController
        , IALNFCDetectorDelegate
        //, IALIDPluginDelegate
    {

        //ALIDScanViewPlugin mrzScanViewPlugin;
        //ALIDScanPlugin mrzScanPlugin;
        ALScanView scanView;
        ALNFCDetector nfcDetector;
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

            //ALMRZConfig mrzConfig = new ALMRZConfig();
            ////we want to be quite confident of these fields to ensure we can read the NFC with them
            //ALMRZFieldConfidences fieldConfidences = new ALMRZFieldConfidences();
            //fieldConfidences.DocumentNumber = 90;
            //fieldConfidences.DateOfBirth = 90;
            //fieldConfidences.DateOfExpiry = 90;
            //mrzConfig.IdFieldConfidences = fieldConfidences;

            ////Create fieldScanOptions to configure individual scannable fields
            //ALMRZFieldScanOptions scanOptions = new ALMRZFieldScanOptions();
            //scanOptions.VizAddress = ALFieldScanOption.Default;
            //scanOptions.VizDateOfIssue = ALFieldScanOption.Default;
            //scanOptions.VizSurname = ALFieldScanOption.Default;
            //scanOptions.VizGivenNames = ALFieldScanOption.Default;
            //scanOptions.VizDateOfBirth = ALFieldScanOption.Default;
            //scanOptions.VizDateOfExpiry = ALFieldScanOption.Default;

            ////Set scanOptions for MRZConfig
            //mrzConfig.IdFieldScanOptions = scanOptions;

            //NSError error = null;
            //// Init the anyline ID ScanPlugin with an ID, Licensekey, the delegate,
            //// the MRZConfig (which will configure the scan Plugin for MRZ scanning), and an error
            //this.mrzScanPlugin = new ALIDScanPlugin(@"ModuleID", this, mrzConfig, out error);

            //nfcDetector = new ALNFCDetector(this);

            //mrzScanViewPlugin = new ALIDScanViewPlugin(mrzScanPlugin);

            //var frame = UIScreen.MainScreen.ApplicationFrame;
            //frame = new CGRect(frame.X,
            //    frame.Y + NavigationController.NavigationBar.Frame.Size.Height,
            //    frame.Width,
            //    frame.Height - NavigationController.NavigationBar.Frame.Size.Height);

            //// This is the main intialization method that will create our use case depending on the JSON configuration.
            //scanView = new ALScanView(frame, mrzScanViewPlugin);
            //scanView.ScanViewPlugin.AddScanViewPluginDelegate(new CutoutListener(updateHintPosition, scanView));
            //scanView.FlashButtonConfig.FlashAlignment = ALFlashAlignment.TopLeft;

            //// After setup is complete we add the scanView to the view of this view controller
            //View.AddSubview(scanView);
            //View.SendSubviewToBack(scanView);

            var topGuide = TopLayoutGuide;

            var viewNames = NSDictionary.FromObjectsAndKeys(new object[] {
            scanView,
            topGuide,
            }, new NSObject[] {
                new NSString("scanView"),
                new NSString("topGuide"),
            });
            var emptyDict = new NSDictionary();


            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|[scanView]|", 0, emptyDict, viewNames));
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[topGuide]-0-[scanView]|", 0, emptyDict, viewNames));

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
            //mrzScanViewPlugin.StartAndReturnError(out error);
            hintView.Hidden = false;
        }

        private void stopMRZScanning()
        {
            NSError error = null;
            //mrzScanViewPlugin.StopAndReturnError(out error);
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

        //public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        //{
        //    ALMRZIdentification identification = (ALMRZIdentification)scanResult.Result;
        //    string passportNumber = identification.DocumentNumber.Trim();
        //    NSDate dateOfBirth = identification.DateOfBirthObject;
        //    NSDate dateOfExpiry = identification.DateOfExpiryObject;
        //    //The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
        //    string mrzString = identification.MrzString;
        //    string passportNumberForNFC = String.Copy(passportNumber);

        //    while (passportNumberForNFC.Length < 9)
        //    {
        //        passportNumberForNFC += "<";
        //    }

        //    stopMRZScanning();
        //    this.passportNumberForNFC = passportNumberForNFC;
        //    this.dateOfBirth = dateOfBirth;
        //    this.dateOfExpiry = dateOfExpiry;
        //    readNFCChip();
        //}

        public void NfcSucceededWithResult(ALNFCResult nfcResult)
        {
            BeginInvokeOnMainThread(() => { 
                var resultViewController = new ResultViewController(nfcResult);
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
                    this.nfcDetector.Dispose();
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