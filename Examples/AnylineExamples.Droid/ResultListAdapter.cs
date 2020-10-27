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
        public const int TypeComposite = 3;
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
                return TypeComposite;

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
                        ((ImageView)convertView).SetPadding(padding, padding, padding, padding);
                        ((ImageView)convertView).SetImageBitmap(GetItem(position) as Bitmap);
                        break;
                    case TypeComposite:
                        convertView = new LinearLayout(_context);
                        (convertView as LinearLayout).Orientation = Android.Widget.Orientation.Vertical;

                        var serialScanningResults = (GetItem(position) as Java.Util.LinkedHashMap);

                        foreach (Java.Lang.Object scanningResult in serialScanningResults.KeySet())
                        {
                            LinearLayout llPluginContent = new LinearLayout(_context);
                            llPluginContent.Orientation = Android.Widget.Orientation.Vertical;
                            llPluginContent.SetPadding(15, 30, 15, 30);
                            LinearLayout.LayoutParams parameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.FillParent, LinearLayout.LayoutParams.FillParent);
                            parameters.SetMargins(32, 5, 32, 5);
                            llPluginContent.LayoutParameters = parameters;

                            string keyPluginResult = scanningResult.ToString();
                            Java.Util.LinkedHashMap pluginResults = serialScanningResults.Get(scanningResult) as Java.Util.LinkedHashMap;

                            if (pluginResults.ContainsKey("PluginId"))
                            {
                                TextView tvPluginTitle = CreateTextView(pluginResults.Get("PluginId").ToString(), padding, padding4, padding, padding4, Android.Resource.Style.TextAppearanceLarge, Color.ParseColor("#007aff"), TypefaceStyle.Bold, TextAlignment.Center);
                                llPluginContent.AddView(tvPluginTitle);
                            }

                            foreach (var result in pluginResults.KeySet())
                            {
                                string resultKey = result.ToString();
                                if (resultKey.Equals("PluginId")) { continue; }
                                Java.Lang.Object resultValue = pluginResults.Get(resultKey);

                                TextView tvTitle = CreateTextView(resultKey, padding, padding4, padding, padding4, Android.Resource.Style.TextAppearanceSmall, Color.Black, TypefaceStyle.Normal);
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
                                    TextView tvValue = CreateTextView(resultValue.ToString(), 32, padding, padding, padding, Android.Resource.Style.TextAppearanceMedium, Color.Black, TypefaceStyle.Bold);
                                    llPluginContent.AddView(tvValue);
                                }
                            }
                            (convertView as LinearLayout).AddView(llPluginContent);
                            (convertView as LinearLayout).AddView(CreateLayoutDivider());
                        }


                        break;
                }
            }
#pragma warning restore 0618

            return convertView;
        }

        private TextView CreateTextView(string text, int paddingL, int paddingT, int paddingR, int paddingB, int textAppearance, Color color, TypefaceStyle typefaceStyle, TextAlignment alignment = TextAlignment.ViewStart)
        {
            TextView textView = new TextView(_context);
#pragma warning disable 0618
            textView.SetTextAppearance(_context, textAppearance);
#pragma warning restore 0618
            textView.SetTypeface(null, typefaceStyle);
            textView.TextAlignment = alignment;
            textView.SetPadding(paddingL, paddingT, paddingR, paddingB);
            textView.SetText(text.ToString(), TextView.BufferType.Normal);
            textView.SetTextColor(color);
            return textView;
        }

        private View CreateLayoutDivider()
        {
            var divider = new View(_context);
            divider.SetBackgroundColor(Color.Black);
            divider.SetPadding(0, 30, 0, 30);
            divider.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 30);
            return divider;
        }
    }
}