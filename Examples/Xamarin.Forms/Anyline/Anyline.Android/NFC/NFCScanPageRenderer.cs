using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Anyline.NFC;
using Anyline.Droid.NFC;
using IO.Anyline.Plugin;
using IO.Anyline.Plugin.ID;
using IO.Anyline.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using IO.Anyline.Models;
using System.IO;

[assembly: ExportRenderer(typeof(NFCScanExamplePage), typeof(NFCScanPageRenderer))]

namespace Anyline.Droid.NFC
{
    public class NFCScanPageRenderer : PageRenderer, IScanResultListener
    {
        private Context context;
        private Android.Views.View view;
        private ScanView scanView;

        public NFCScanPageRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> args)
        {
            base.OnElementChanged(args);

            if (args.OldElement != null || Element == null) return;

            InitializeAnyline();
        }

        private void InitializeAnyline()
        {
            string configurationFile = (Element as NFCScanExamplePage).ConfigurationFile.Replace(".json", "") + ".json"; ;

            try
            {
                if (view == null)
                {
                    var activity = Context as Activity;
                    view = activity.LayoutInflater.Inflate(Resource.Layout.ScanLayout, this, false);

                    AddView(view);

                    scanView = view.FindViewById<ScanView>(Resource.Id.scan_view);

                    scanView.Init(configurationFile);

                    // Activates Face Detection if the MRZ Scanner was initialized
                    //(((scanView.ScanViewPlugin as IdScanViewPlugin)?.ScanPlugin as IdScanPlugin)?.IdConfig as MrzConfig)?.EnableFaceDetection(true);

                    //scanView.ScanViewPlugin.AddScanResultListener(this);

                    scanView.CameraOpened += ScanView_CameraOpened;
                }

            }
            catch (Exception e)
            {
                Toast.MakeText(context, "Init Error - " + e.Message, ToastLength.Long).Show();
            }
        }

        private void ScanView_CameraOpened(object sender, IO.Anyline.Camera.CameraOpenedEventArgs e)
        {
            if (scanView != null)
                scanView.Start();
        }

        public void OnResult(Java.Lang.Object result)
        {
            // when using Universal ID

            //resultData = ((result as ScanResult).Result as Identification).ResultData;
            //string documentNumber = resultData["documentNumber"].Trim();
            //string dateOfBirth = resultData["dateOfBirth"];
            //string expirationDate = resultData["dateOfExpiry"];

            // when using MRZ Scanner
            var scanResult = result as ScanResult;
            var mrzIdentification = scanResult.Result as MrzIdentification;

            // Sends the MRZ results back to the Xamarin Forms application
            MyMRZScanResults myMRZScanResults = new MyMRZScanResults
            {
                GivenNames = mrzIdentification.GivenNames,
                Surname = mrzIdentification.Surname,
                CutoutImage = ConvertAnylineImageToByteArray(scanResult.CutoutImage),
                FullImage = ConvertAnylineImageToByteArray(scanResult.FullImage),
                FaceImage = ConvertBitmapToByteArray(mrzIdentification.FaceImage),
                PassportNumber = mrzIdentification.DocumentNumber.Trim(),
                DateOfBirth = mrzIdentification.DateOfBirth,
                DateOfExpiry = mrzIdentification.DateOfExpiry
            };
            MessagingCenter.Send(App.Current, "MRZ_READING_DONE", myMRZScanResults);

            StartReadingNFCChip(mrzIdentification.DocumentNumber, mrzIdentification.DateOfBirthObject, mrzIdentification.DateOfExpiryObject);
        }

        private void StartReadingNFCChip(string documentNumber, Java.Util.Date dateOfBirthObject, Java.Util.Date dateOfExpiryObject)
        {
            // Gets the data necessary for the NFC reading
            string passportNumber = documentNumber.Trim();
            Java.Util.Date dateOfBirth = dateOfBirthObject;
            Java.Util.Date expirationDate = dateOfExpiryObject;
            var dateFormat = new Android.Icu.Text.SimpleDateFormat("yyMMdd");

            // The passport number passed to the NFC chip must have a trailing < if there is one in the MRZ string.
            string passportNumberForNFC = string.Copy(passportNumber);

            while (passportNumberForNFC.Length < 9)
            {
                passportNumberForNFC += "<";
            }

            // Open the Activity responsible for listening to the NFC calls and reading the chip.
            // We use data from the MRZ to authenticate with the chip.

            var activity = this.Context as Activity;
            var nfcActivity = new Intent(activity, typeof(NFCScanActivity));
            nfcActivity.PutExtra("pn", passportNumberForNFC);
            nfcActivity.PutExtra("db", dateFormat.Format(dateOfBirth));
            nfcActivity.PutExtra("de", dateFormat.Format(expirationDate));
            activity.StartActivity(nfcActivity);
        }

        private byte[] ConvertAnylineImageToByteArray(AnylineImage anylineImage)
        {
            if (anylineImage == null) return null;

            var bitmap = anylineImage.Clone().Bitmap;

            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            return stream.ToArray();
        }

        private byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            if (bitmap == null) return null;

            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            return stream.ToArray();
        }

        #region Xamarin Renderer config
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var w = r - l;
            var h = b - t;

            var msw = MeasureSpec.MakeMeasureSpec(w, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(h, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, w, h);
        }
        #endregion

        #region Teardown
        protected override void Dispose(bool disposing)
        {
            DisposeResources();
            base.Dispose(disposing);
        }

        protected override void OnDetachedFromWindow()
        {
            scanView.Stop();
            scanView.CameraView.ReleaseCameraInBackground();
            base.OnDetachedFromWindow();
        }

        private void DisposeResources()
        {
            if (scanView != null)
            {
                scanView.Dispose();
                scanView = null;
            }
            view = null;
            RemoveAllViews();
            GC.Collect();
        }
        #endregion
    }
}