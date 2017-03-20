using Android.Content;
using Android.Widget;
using AT.Nineyards.Anyline.Modules.Mrz;

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
            //_issueCodeText = FindViewById<TextView>(Resource.Id.text_country_code_national);
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
            _dayOfBirthText.SetText(identification.DayOfBirth, TextView.BufferType.Normal);
            _expirationDateText.SetText(identification.ExpirationDate, TextView.BufferType.Normal);
            _sexText.SetText(identification.Sex, TextView.BufferType.Normal);

            string mrzString;
            if ("P".Equals(identification.DocumentType))
            {
                mrzString = string.Format("{0,-44}\n\n", string.Format("P<{0}{1}<<{2}", identification.NationalityCountryCode,
                        identification.SurNames, identification.GivenNames));
                
                mrzString += string.Format("{0,-42}{1,1}{2,1}", string.Format("{0,-9}{1}{2}{3}{4}{5}{6}{7}{8}",
                                identification.DocumentNumber, identification.CheckDigitNumber,
                                identification.IssuingCountryCode,
                                identification.DayOfBirth, identification.CheckDigitDayOfBirth,
                                identification.Sex,
                                identification.ExpirationDate, identification.CheckDigitExpirationDate,
                                identification.PersonalNumber),
                        identification.CheckDigitPersonalNumber, identification.CheckDigitFinal);
            }
            else
            {

                mrzString = string.Format("{0,-30}\n", string.Format("{0}{1,-3}{2,-9}{3}",
                        identification.DocumentType, identification.NationalityCountryCode,
                        identification.DocumentNumber, identification.CheckDigitNumber));


                mrzString += string.Format("{0,-29}{1,1}\n", string.Format("{0}{1}{2}{3}{4}{5}",
                                identification.DayOfBirth, identification.CheckDigitDayOfBirth,
                                identification.Sex, identification.ExpirationDate,
                                identification.CheckDigitExpirationDate, identification.IssuingCountryCode),
                        identification.CheckDigitFinal);

                mrzString += string.Format("{0,-30}", string.Format("{0}<<{1}",
                        identification.SurNames, identification.GivenNames));
            }
            mrzString = mrzString.Replace(" ", "<");
            _mrzText.SetText(mrzString, TextView.BufferType.Normal);
        }
    }
}