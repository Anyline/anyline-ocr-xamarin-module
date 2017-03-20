using Android.Content;
using Android.Widget;
using AT.Nineyards.Anyline.Util;

namespace AnylineXamarinApp.Ocr
{
    public class OcrResultView : RelativeLayout
    {
        public TextView ResultText { get; set; }
        public ImageView Bg { get; set; }

        public OcrResultView(Context context) : base(context) { Init(); }

        public OcrResultView(Context context, Android.Util.IAttributeSet attrs) : base(context, attrs) { Init(); }

        public OcrResultView(Context context, Android.Util.IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { Init(); }

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