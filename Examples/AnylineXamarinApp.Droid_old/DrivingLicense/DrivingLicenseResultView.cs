using Android.Content;
using Android.Widget;
using AT.Nineyards.Anyline.Util;
using Java.Text;

namespace AnylineXamarinApp.DrivingLicense
{
    public class DrivingLicenseResultView : RelativeLayout
    {
        public TextView TextNumber { get; set; }
        public TextView TextNumber2 { get; set; }
        public TextView TextGivenNames { get; set; }
        public TextView TextDayOfBirth { get; set; }

        public ImageView Bg { get; set; }

        public DrivingLicenseResultView(Context context) : base(context) { Init(); }

        public DrivingLicenseResultView(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs) { Init(); }

        public DrivingLicenseResultView(Context context, Android.Util.IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { Init(); }

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
            TextDayOfBirth.Text = dayOfBirth;
        }
    }
}