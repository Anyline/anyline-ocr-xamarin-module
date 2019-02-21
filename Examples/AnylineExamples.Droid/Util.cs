using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AnylineExamples.Droid
{
    public static class Util
    {
        /// <summary>
        /// Rescales button icons.
        /// </summary>
        /// <param name="button">Button</param>
        /// <param name="scale">Icon</param>
        public static void ScaleButtonDrawable(Button button, float scale)
        {
            Drawable d = button.GetCompoundDrawables()[0];
            d.SetBounds(0, 0, (int)(d.IntrinsicWidth * scale), (int)(d.IntrinsicHeight * scale));
            ScaleDrawable sd = new ScaleDrawable(d, GravityFlags.Center, d.IntrinsicWidth * scale, d.IntrinsicWidth * scale);
            button.SetCompoundDrawables(sd.Drawable, null, null, null);
        }

        /// <summary>
        /// Sets the Height of a ListView based on its children. See http://forums.xamarin.com/discussion/2857/listview-inside-scrollview/p1
        /// </summary>
        /// <param name="listView"></param>
        public static void SetListViewHeightBasedOnChildren(ListView listView, Context context)
        {
            if (listView.Adapter == null)
            {
                // pre-condition
                return;
            }

            int totalHeight = listView.PaddingTop + listView.PaddingBottom;
            for (int i = 0; i < listView.Count; i++)
            {
                View listItem = listView.Adapter.GetView(i, null, listView);
                if (listItem.GetType() == typeof(TextView))
                {
                    var t = listItem as TextView;

                    IWindowManager wm = context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
                    Display display = wm.DefaultDisplay;

                    int screenWidth = display.Width;
                    float textWidth = t.Paint.MeasureText(t.Text);
                    int numberOfLines = Math.Max(1, ((int)textWidth/screenWidth) + 1);

                    // fixes a glitch with long result strings
                    if (numberOfLines > 2)
                    {
                        numberOfLines++;
                    }
                    t.SetLines(numberOfLines);
                    
                }
                if (listItem.GetType() == typeof(ViewGroup))
                {
                    listItem.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
                }
                listItem.Measure(0, 0);
                totalHeight += listItem.MeasuredHeight;
            }

            listView.LayoutParameters.Height = totalHeight + (listView.DividerHeight * (listView.Count - 1));
        }

        class DialogInterfaceOnClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
        {
            public void OnClick(IDialogInterface dialog, int which)
            {
                dialog.Dismiss();
            }
        }

        public static void ShowError(string message, Context context)
        {
            Log.Debug("", message);

            AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(context);
            alertDialogBuilder.SetMessage(message);
            alertDialogBuilder.SetCancelable(false);
            alertDialogBuilder.SetPositiveButton("OK", new DialogInterfaceOnClickListener());

            var alert = alertDialogBuilder.Create();
            alert.Show();
        }
    }
}