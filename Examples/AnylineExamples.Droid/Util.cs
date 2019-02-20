using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics.Drawables;
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
        public static void SetListViewHeightBasedOnChildren(ListView listView)
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