using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
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
                    int numberOfLines = ((int)textWidth/screenWidth) + 1;
                    t.SetLines(numberOfLines);
                    /*WindowManager wm = (WindowManager) context.getSystemService(Context.WINDOW_SERVICE);
Display display = wm.getDefaultDisplay();
int screenWidth = display.getWidth(); // Get full screen width
int eightyPercent = (screenWidth * 80) / 100; // Calculate 80% of it
// as my adapter was having almost 80% of the whole screen width

float textWidth = textView.getPaint().measureText(fullString);
// this method will give you the total width required to display total String

int numberOfLines = ((int) textWidth/eightyPercent) + 1;
// calculate number of lines it might take

textView.setLines(numberOfLines);*/
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
    }
}