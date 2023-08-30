using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Text.Style;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using IO.Anyline.Nfc.NFC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ResultActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ResultActivity).Name;

        private LinearLayout _llResults;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.result_activity);
            _llResults = FindViewById<LinearLayout>(Resource.Id.llResults);

            bool isNFCResult = Intent.GetBooleanExtra("Is_NFC_Result", false);
            bool isCompositeResult = Intent.GetBooleanExtra("Is_Composite_Result", false);
            var handle = new IntPtr(Intent.GetIntExtra("handle", 0));

            Java.Lang.Object scanResult = null;
            if (isNFCResult)
            {
                scanResult = GetObject<NFCResult>(handle, JniHandleOwnership.DoNotTransfer);
            }
            else if (isCompositeResult)
            {
                scanResult = GetObject<Android.Runtime.JavaList>(handle, JniHandleOwnership.DoNotTransfer);
            }
            else
            {
                scanResult = GetObject<IO.Anyline2.ScanResult>(handle, JniHandleOwnership.DoNotTransfer);
            }

            Title = Intent.GetStringExtra("title");

            if (scanResult != null)
            {
                var results = scanResult.CreatePropertyDictionary();
                Task.Run(() => ShowResults(results));
            }
        }

        private void ShowResults(Dictionary<string, object> results)
        {
            View viewResults = CreateResultView(results);
            RunOnUiThread(() => _llResults.AddView(viewResults));
        }

        private View CreateResultView(Dictionary<string, object> dict)
        {
            LinearLayout llResult = new LinearLayout(this) { Orientation = Orientation.Vertical };
            var density = Resources.DisplayMetrics.Density;
            int padding = Convert.ToInt32((5 * density));
            llResult.SetPadding(padding, 0, 0, padding);

            foreach (var item in dict)
            {
                String[] name_type = item.Key.Split(" ");

                SpannableStringBuilder spannableString = new SpannableStringBuilder();
                SpannableString span1 = new SpannableString(name_type[0] + " ");
                span1.SetSpan(new AbsoluteSizeSpan(15, true), 0, name_type[0].Length, SpanTypes.InclusiveInclusive);
                SpannableString span2 = new SpannableString(name_type[1]);
                span2.SetSpan(new AbsoluteSizeSpan(9, true), 0, name_type[1].Length, SpanTypes.InclusiveInclusive);
                spannableString.Append(span1);
                spannableString.Append(span2);

                TextView tvKey = new TextView(this);
                tvKey.SetText(spannableString, TextView.BufferType.Normal);

                tvKey.SetTextColor(Android.Graphics.Color.Argb(255, 50, 173, 255));
                tvKey.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
                llResult.AddView(tvKey);


                if (item.Value is byte[] imageBytes)
                {
                    var iv = new ImageView(this);
                    iv.SetPadding(16, 16, 16, 16);
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        var bitmap = BitmapFactory.DecodeStream(ms);
                        iv.SetImageBitmap(bitmap);
                    }
                    llResult.AddView(iv);
                }
                else if (item.Value is Dictionary<string, object> subItems)
                {
                    llResult.AddView(CreateResultView(subItems));
                }
                else
                {
                    TextView tvValue = new TextView(this);
                    tvValue.SetText(item.Value.ToString(), TextView.BufferType.Normal);
                    tvValue.SetTextSize(ComplexUnitType.Dip, 17);
                    tvValue.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);

                    llResult.AddView(tvValue);
                }
            }

            return llResult;
        }

        #region going back & cleanup
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    GoBack();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            GoBack();
        }

        private void GoBack()
        {
            Finish();
        }
        #endregion


    }
}