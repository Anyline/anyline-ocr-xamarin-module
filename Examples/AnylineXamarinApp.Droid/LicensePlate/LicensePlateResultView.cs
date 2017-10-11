using Android.Content;
using Android.Widget;
using AT.Nineyards.Anyline.Util;

namespace AnylineXamarinApp.LicensePlate
{
    public class LicensePlateResultView : RelativeLayout
    {
        public TextView ResultText { get; set; }
        public ImageView Bg { get; set; }

        public LicensePlateResultView(Context context) : base(context) { Init(); }

        public LicensePlateResultView(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs) { Init(); }

        public LicensePlateResultView(Context context, Android.Util.IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { Init(); }

        private void Init()
        {
            SetPadding(DimensUtil.GetPixFromDp(Context, 4), DimensUtil.GetPixFromDp(Context, 16),
                DimensUtil.GetPixFromDp(Context, 4), DimensUtil.GetPixFromDp(Context, 16));

            Inflate(Context, Resource.Layout.OCRResult, this);

            ResultText = (TextView)FindViewById(Resource.Id.text_result);
            Bg = (ImageView)FindViewById(Resource.Id.result_background);
                        
        }
    }
}