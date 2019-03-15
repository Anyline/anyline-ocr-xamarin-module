using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using System;
using System.Reflection;
using System.Linq;
using Android.Content.PM;
using System.Collections.Generic;

using AnylineExamples.Shared;
using Android.Graphics;

namespace AnylineExamples.Droid
{
    public class ResultListAdapter : BaseAdapter
    {
        public const int TypeHeader = 0;
        public const int TypeItem = 1;
        public const int TypeImage = 2;
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
            if(GetItem(position).GetType() == typeof(Bitmap))
                return TypeImage;

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
                }
            }
#pragma warning restore 0618
            
            return convertView;
        }
    }
}