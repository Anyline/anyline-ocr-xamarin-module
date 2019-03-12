using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Text;

using AT.Nineyards.Anyline.Models;

namespace AnylineXamarinApp
{
    class ResultDialogBuilder : AlertDialog.Builder
    {
        private ImageView _imageView;
        private TextView _textView;

        public ResultDialogBuilder(Context context) : base(context)
        {
            Init();
        }

        public ResultDialogBuilder(Context context, int theme) : base(context, theme)
        {
            Init();
        }

        private void Init()
        {
            View view = LayoutInflater.From(Context).Inflate(Resource.Layout.DialogResult, null);

            _imageView = view.FindViewById<ImageView>(Resource.Id.image);
            _textView = view.FindViewById<TextView>(Resource.Id.text);

            SetView(view);
        }

        public ResultDialogBuilder SetResultImage(AnylineImage resultImage)
        {
            _imageView.SetImageBitmap(resultImage.Bitmap);
            return this;
        }

        public ResultDialogBuilder SetText(ISpannable resultText)
        {
            _textView.SetText(resultText,TextView.BufferType.Normal);
            return this;
        }

        public ResultDialogBuilder SetTextSize(ComplexUnitType unit, float size)
        {
            _textView.SetTextSize(unit, size);
            return this;
        }

        public ResultDialogBuilder SetTextGravity(GravityFlags gravity)
        {
            _textView.Gravity = gravity;
            return this;
        }
    }
}