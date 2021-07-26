﻿using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.OS;

using Android.Nfc;
using IO.Anyline.Nfc;
using Android.Nfc.Tech;
using IO.Anyline.Nfc.NFC;
using Android.Graphics;
using Xamarin.Forms;
using System.IO;
using Anyline.NFC;

namespace Anyline.Droid.NFC
{
    [Activity(Label = "NFCScanActivity")]
    public class NFCScanActivity : Activity, NfcDetector.INfcDetectionHandler
    {
        protected NfcAdapter mNfcAdapter;

        private string passportNumber;
        private string dateOfExpiry;
        private string dateOfBirth;

        Android.Widget.ProgressBar nfcReadProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Title = "Scan NFC";

            // You can customize this Activity so it best fits your App's visual identity and requirements
            SetContentView(Resource.Layout.ActivityNFC);
            nfcReadProgressBar = (Android.Widget.ProgressBar)FindViewById(Resource.Id.readProgressBar);

            // Obtains the system's NFC Service
            NfcManager NfcManager = (NfcManager)Android.App.Application.Context.GetSystemService(NfcService);
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
                        NfcDetector nfcDetector = new NfcDetector(ApplicationContext, this);
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
            Device.BeginInvokeOnMainThread(() => nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true));
        }

        public void OnSODSuccess(SOD sod)
        {
            Device.BeginInvokeOnMainThread(() => nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true));
        }

        public void OnDg2Success(Bitmap faceImage)
        {
            Device.BeginInvokeOnMainThread(() => nfcReadProgressBar.SetProgress(nfcReadProgressBar.Progress + 33, true));
        }

        /// <summary>
        /// Once the NFC reading is done, we send the results back to the Xamarin.Forms layer
        /// </summary>
        /// <param name="result">The NFC results</param>
        public void OnNfcSuccess(NFCResult result)
        {
            // Once we have the results, we don't need to react to the NFC Tag anymore.
            mNfcAdapter.DisableForegroundDispatch(this);

            Device.BeginInvokeOnMainThread(() => nfcReadProgressBar.SetProgress(100, true));

            MyNFCScanResults myNFCScanResults = new MyNFCScanResults
            {
                FirstName = result.DataGroup1.FirstName,
                LastName = result.DataGroup1.LastName,
                Gender= result.DataGroup1.Gender,
                DocumentNumber = result.DataGroup1.DocumentNumber,
                DateOfBirth = result.DataGroup1.DateOfBirth,
                DateOfExpiry = result.DataGroup1.DateOfExpiry,
                DocumentType = result.DataGroup1.DocumentType,
                IssuingStateCode = result.DataGroup1.IssuingStateCode,
                Nationality = result.DataGroup1.Nationality,
                FaceImage = ConvertBitmapToByteArray(result.DataGroup2.FaceImage)
            };

            // Sends the parsed results to the Message Listener (in this example, the NFCScanExamplePage)
            MessagingCenter.Send(App.Current, "NFC_SCAN_FINISHED_SUCCESS", myNFCScanResults);

            // Finishes this native NFC scanning activity
            Finish();
        }

        public void OnNfcFailure(string e)
        {
            MessagingCenter.Send(App.Current, "NFC_SCAN_FINISHED_ERROR", e);

            // Finishes this native NFC scanning activity
            Finish();
        }

        public byte[] ConvertBitmapToByteArray(Bitmap bitmap)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            return stream.ToArray();
        }
    }
}
