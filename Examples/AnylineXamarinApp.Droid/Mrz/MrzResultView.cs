using Android.Content;
using Android.Text.Format;
using Android.Widget;
using AT.Nineyards.Anyline.Modules.Mrz;
using Java.Lang;
using Java.Util;

namespace AnylineXamarinApp.Mrz
{
    public class MrzResultView : RelativeLayout
    {
        private TextView _typeText;
        private TextView _nationalCodeText;
        //private TextView _issueCodeText;
        private TextView _numberText;
        private TextView _surNamesText;
        private TextView _givenNamesText;
        private TextView _dayOfBirthText;
        private TextView _expirationDateText;
        private TextView _sexText;
        private TextView _mrzText;        

        public MrzResultView(Context context) : base(context) { Init(); }

        public MrzResultView(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs) { Init(); }
        
        public MrzResultView(Context context, Android.Util.IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { Init(); }

        private void Init()
        {
                        
            Inflate(Context, Resource.Layout.MrzResult, this);

            _typeText = FindViewById<TextView>(Resource.Id.text_type);
            _nationalCodeText = FindViewById<TextView>(Resource.Id.text_country_code_national);            
            _numberText = FindViewById<TextView>(Resource.Id.text_number);
            _surNamesText = FindViewById<TextView>(Resource.Id.text_surnames);
            _givenNamesText = FindViewById<TextView>(Resource.Id.text_given_names);
            _dayOfBirthText = FindViewById<TextView>(Resource.Id.text_day_of_birth);
            _expirationDateText = FindViewById<TextView>(Resource.Id.text_expiration_date);
            _sexText = FindViewById<TextView>(Resource.Id.text_sex);
            _mrzText = FindViewById<TextView>(Resource.Id.text_mrz);            
        }

        public void SetIdentification(Identification identification)
        {
            _typeText.SetText(identification.DocumentType, TextView.BufferType.Normal);
            _nationalCodeText.SetText(identification.NationalityCountryCode, TextView.BufferType.Normal);
            _numberText.SetText(identification.DocumentNumber, TextView.BufferType.Normal);
            _surNamesText.SetText(identification.SurNames, TextView.BufferType.Normal);
            _givenNamesText.SetText(identification.GivenNames, TextView.BufferType.Normal);
            _dayOfBirthText.SetText(GetStringFromDateObject(identification.DayOfBirthObject, identification.DayOfBirth), TextView.BufferType.Normal);
            _expirationDateText.SetText(GetStringFromDateObject(identification.ExpirationDateObject, identification.ExpirationDate), TextView.BufferType.Normal);
            _sexText.SetText(identification.Sex, TextView.BufferType.Normal);

            string mrzString = identification.MrzString.Replace("\\n", "\n");            
            _mrzText.SetText(mrzString, TextView.BufferType.Normal);
        }

        string GetStringFromDateObject(Date dateObject, string fallbackString)
        {
            var format = DateFormat.GetDateFormat(Context);
            var str = "";
            try
            {
                if (dateObject != null)
                    str = format.Format(dateObject);
                else
                    str = fallbackString;                
            }
            catch (Exception)
            {
                return fallbackString;
            }
            return str;
        }
    }
}