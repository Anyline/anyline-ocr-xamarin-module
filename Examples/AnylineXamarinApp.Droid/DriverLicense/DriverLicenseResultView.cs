using Android.Content;
using Android.Widget;
using AT.Nineyards.Anyline.Util;
using Java.Text;

namespace AnylineXamarinApp.DriverLicense
{
    public class DriverLicenseResultView : RelativeLayout
    {
        public TextView TextNumber { get; set; }
        public TextView TextNumber2 { get; set; }
        public TextView TextGivenNames { get; set; }
        public TextView TextDayOfBirth { get; set; }

        public ImageView Bg { get; set; }

        public DriverLicenseResultView(Context context) : base(context) { Init(); }

        public DriverLicenseResultView(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs) { Init(); }

        public DriverLicenseResultView(Context context, Android.Util.IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { Init(); }

        private void Init()
        {
            SetPadding(DimensUtil.GetPixFromDp(Context, 4), DimensUtil.GetPixFromDp(Context, 16),
                DimensUtil.GetPixFromDp(Context, 4), DimensUtil.GetPixFromDp(Context, 16));

            Inflate(Context, Resource.Layout.DriverLicenseResult, this);

            TextNumber = (TextView)FindViewById(Resource.Id.text_number);
            TextNumber2 = (TextView)FindViewById(Resource.Id.text_number_two);
            TextGivenNames = (TextView)FindViewById(Resource.Id.text_given_names);
            TextDayOfBirth = (TextView)FindViewById(Resource.Id.text_day_of_birth);

            Bg = (ImageView)FindViewById(Resource.Id.result_background);
            Bg.SetImageResource(Resource.Drawable.driving_license_background);
        }

        public void SetDocumentNumber(string documentNumber)
        {
            TextNumber2.Text = documentNumber;
        }

        public void SetName(string name)
        {
            TextGivenNames.Text = name.Replace(' ', '\n');            
        }

        public void SetDayOfBirth(string dayOfBirth)
        {
            string dateString = dayOfBirth;
            string inputFormat = "ddMMyyyy";
            string outputFormat = "yyyy-MM-dd";

            if (int.Parse(dayOfBirth.Substring(2, 4))  > 12 || int.Parse(dayOfBirth.Substring(4, 6)) <= 12)
            {
                inputFormat = "yyyyMMdd";
            }
            SimpleDateFormat inputDateFormat = new SimpleDateFormat(inputFormat);
            SimpleDateFormat outputDateFormat = new SimpleDateFormat(outputFormat);
            try
            {
                dateString = outputDateFormat.Format(inputDateFormat.Parse(dayOfBirth));
            }
            catch (ParseException e)
            {
                e.PrintStackTrace();
            }

            TextDayOfBirth.Text = dateString;
        }
    }
}