using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Graphics;
using Android.Nfc;
using IO.Anyline.Nfc;
using Android.Nfc.Tech;
using System.Linq;
using IO.Anyline.Nfc.NFC;
using AnylineExamples.Droid;
using Android.Widget;

namespace Anyline.Droid.NFC
{
    [Activity(Label = "NFCScanActivity")]
    public class NFCScanActivity : Activity, NfcDetector.INfcDetectionHandler
    {
        protected NfcAdapter mNfcAdapter;

        private string passportNumber;
        private string dateOfExpiry;
        private string dateOfBirth;

        ProgressBar nfcReadProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Title = "Scan NFC";

            // You can customize this Activity so it best fits your App's visual identity and requirements
            SetContentView(Resource.Layout.activity_nfc);
            nfcReadProgressBar = (ProgressBar)FindViewById(Resource.Id.readProgressBar);

            // Obtains the system's NFC Service
            NfcManager NfcManager = (NfcManager)GetSystemService(NfcService);
            mNfcAdapter = NfcManager.DefaultAdapter;

            // Retrieves the passport information from the previous activity
            if (Intent != null)
            {
                try
                {
                    passportNumber = Intent.GetStringExtra("pn");
                    dateOfBirth = Intent.GetStringExtra("db");
                    dateOfExpiry = Intent.GetStringExtra("de");
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                }
            }
        }

        /// <summary>
        /// OnResume, we start listening for the NFC Tag.
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            try
            {
                if (mNfcAdapter != null)
                {
                    var intent = new Intent(this, GetType()).AddFlags(ActivityFlags.SingleTop);

                    mNfcAdapter.EnableForegroundDispatch(
                        this,
                        PendingIntent.GetActivity(this, 0, intent, 0),
                        new[] { new IntentFilter(NfcAdapter.ActionTechDiscovered) },
                        new string[][] {
                            new string[] {
                                "android.nfc.tech.IsoDep",
                            },
                        }
                    );
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("onResume error: " + e.Message);
            }
        }

        /// <summary>
        /// OnPause, we stop listening for the NFC Tag.
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            if (mNfcAdapter != null)
            {
                mNfcAdapter.DisableForegroundDispatch(this);
            }
        }

        /// <summary>
        /// OnNewIntent we check if the NFC Tag was recognized, and start the detection.
        /// </summary>
        /// <param name="intent"></param>
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            Tag tag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;
            TagProvider.Tag = IsoDep.Get(tag);

            if (NfcAdapter.ActionTechDiscovered == intent.Action)
            {
                if (tag.GetTechList().ToList().Contains("android.nfc.tech.IsoDep"))
                {
                    try
                    {
                        // Begins to read the NFC chip
                        NfcDetector nfcDetector = new NfcDetector(this, this);
                        nfcDetector.StartNfcDetection(passportNumber, dateOfBirth, dateOfExpiry);
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.ToString());
                    }
                }
            }
        }

        /* As the NFC reading may take a few seconds, we show a progress bar to the user, increasing it's value after each DataGroup read */
        public void OnDg1Success(DataGroup1 dataGroup1)
        {
            nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true);
        }

        public void OnSODSuccess(SOD sod)
        {
            nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true);
        }

        public void OnDg2Success(Bitmap faceImage)
        {
            nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true);
        }

        /// <summary>
        /// Once the NFC reading is done, we send the results back to the Xamarin.Forms layer
        /// </summary>
        /// <param name="result">The NFC results</param>
        public void OnNfcSuccess(NFCResult result)
        {
            // because we can't simply pass the object through the intent, we'll pass the JNI handle & retrieve the object in the other activity
            var intent = new Intent(this, typeof(ResultActivity));
            intent.PutExtra("handle", result.Handle.ToInt32());
            intent.PutExtra("Is_NFC_Result", true);
            intent.PutExtra("title", "NFC Scan Result");

            StartActivity(intent);
            Finish();
        }

        public void OnNfcFailure(string error)
        {
            RunOnUiThread(() =>
            {
                Toast.MakeText(this, error, ToastLength.Long).Show();
                Finish();
            });
        }

    }
}
