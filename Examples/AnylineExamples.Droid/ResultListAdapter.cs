using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.Linq;

namespace AnylineExamples.Droid
{
    public class ResultListAdapter : BaseAdapter
    {
        public const int TypeHeader = 0;
        public const int TypeItem = 1;
        public const int TypeImage = 2;
        public const int TypeSerial = 3;
        private readonly List<Java.Lang.Object> _items;
        private readonly Context _context;

        public ResultListAdapter(Context context, Dictionary<string, Java.Lang.Object> items)
        {
            _context = context;
            Resources res = context.Resources;

            _items = new List<Java.Lang.Object>();
            items.ToList().ForEach(x => { _items.Add(x.Key); _items.Add(x.Value); });

        }

        public override int GetItemViewType(int position)
        {
            if (position % 2 == 0)
                return TypeHeader;
            if (GetItem(position).GetType() == typeof(Bitmap))
                return TypeImage;
            if (GetItem(position).GetType() == typeof(Java.Util.LinkedHashMap))
                return TypeSerial;

            return TypeItem;
        }

        public int GetViewTypeCount()
        {
            return 3;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return _items.ElementAt(position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            int rowType = GetItemViewType(position);

            if (convertView == null)
            {
                int padding = 16;
                int padding4 = 4;
                string txt = "";

#pragma warning disable 0618
                switch (rowType)
                {
                    case TypeHeader:
                        convertView = new TextView(_context);

                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceSmall);
                        convertView.SetPadding(padding, padding4, padding, padding4);

                        txt = GetItem(position).ToString();
                        ((TextView)convertView).SetText(txt, TextView.BufferType.Normal);

                        break;
                    case TypeItem:
                        convertView = new TextView(_context);

                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceMedium);
                        convertView.SetPadding(32, padding, padding, padding);

                        txt = GetItem(position).ToString();
                        ((TextView)convertView).SetText(txt, TextView.BufferType.Normal);

                        break;
                    case TypeImage:
                        convertView = new ImageView(_context);
                        ((ImageView)convertView).SetImageBitmap(GetItem(position) as Bitmap);
                        break;
                    case TypeSerial:
                        convertView = new LinearLayout(_context);
                        (convertView as LinearLayout).Orientation = Android.Widget.Orientation.Vertical;

                        var serialScanningResults = (GetItem(position) as Java.Util.LinkedHashMap);

                        int indexResult = 0;
                        foreach (Java.Lang.Object scanningResult in serialScanningResults.KeySet())
                        {
                            LinearLayout llPluginContent = new LinearLayout(_context);
                            llPluginContent.Orientation = Android.Widget.Orientation.Vertical;
                            llPluginContent.SetPadding(15, 30, 15, 30);
                            LinearLayout.LayoutParams parameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.FillParent);
                            parameters.SetMargins(32, 0, 32, 0);
                            llPluginContent.LayoutParameters = parameters;

                            if (indexResult % 2 == 0) { llPluginContent.SetBackgroundColor(Color.LightSkyBlue); }
                            else { llPluginContent.SetBackgroundColor(Color.LightSeaGreen); }
                            indexResult++;

                            string keyPluginResult = scanningResult.ToString();
                            Java.Util.LinkedHashMap pluginResults = serialScanningResults.Get(scanningResult) as Java.Util.LinkedHashMap;

                            TextView tvPluginTitle = CreateTextView(pluginResults.Get("PluginId").ToString(), padding, padding4, padding, padding4, Android.Resource.Style.TextAppearanceLarge, TextAlignment.Center);
                            llPluginContent.AddView(tvPluginTitle);

                            foreach (var result in pluginResults.KeySet())
                            {
                                string resultKey = result.ToString();
                                if (resultKey.Equals("PluginId")) { continue; }
                                Java.Lang.Object resultValue = pluginResults.Get(resultKey);

                                TextView tvTitle = CreateTextView(resultKey, padding, padding4, padding, padding4, Android.Resource.Style.TextAppearanceSmall);
                                llPluginContent.AddView(tvTitle);

                                if (resultValue.GetType() == typeof(Bitmap))
                                {
                                    ImageView ivContent = new ImageView(_context);
                                    ivContent.SetPadding(20, 20, 20, 20);
                                    ivContent.SetImageBitmap(resultValue as Bitmap);
                                    llPluginContent.AddView(ivContent);
                                }
                                else
                                {
                                    TextView tvValue = CreateTextView(resultValue.ToString(), 32, padding, padding, padding, Android.Resource.Style.TextAppearanceMedium);
                                    llPluginContent.AddView(tvValue);
                                }
                            }

                            (convertView as LinearLayout).AddView(llPluginContent);
                        }


                        break;
                }
            }
#pragma warning restore 0618

            return convertView;
        }

        private TextView CreateTextView(string text, int paddingL, int paddingT, int paddingR, int paddingB, int textAppearance, TextAlignment alignment = TextAlignment.ViewStart)
        {
            TextView textView = new TextView(_context);
#pragma warning disable 0618
            textView.SetTextAppearance(_context, textAppearance);
#pragma warning restore 0618
            textView.TextAlignment = alignment;
            textView.SetPadding(paddingL, paddingT, paddingR, paddingB);
            textView.SetText(text.ToString(), TextView.BufferType.Normal);
            return textView;
        }

        private View CreateLayoutDivider()
        {
            var divider = new View(_context);
            divider.SetBackgroundColor(Color.DarkGray);
            divider.SetPadding(0, 10, 0, 10);
            divider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 2);
            return divider;
        }
    }
}