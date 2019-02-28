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

namespace AnylineExamples.Droid
{
    public class ActivityListAdapter : BaseAdapter
    {
        public const int TypeItem = 0;
        public const int TypeHeader = 1;
        private readonly List<AndroidExampleModelWrapper> _items;
        private readonly Context _context;

        public string GetBuildNumber()
        {
            return typeof(ActivityListAdapter).Assembly.GetName().Version.ToString();
        }

        public ActivityListAdapter(Context context)
        {
            _context = context;
            Resources res = context.Resources;

            _items = ExampleList.Items.ConvertAll(x => new AndroidExampleModelWrapper(x));
            
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(x => x.FullName.StartsWith("AnylineXamarinSDK")).FirstOrDefault();
            if (assembly != null)
            {
                Version ver = assembly.GetName().Version;
                _items.Where(x => x.Model.Category.Equals(Category.Version)).FirstOrDefault().Model.Name = $"Version: {ver} - Build: {GetBuildNumber()}";
            }
        }

        public override int GetItemViewType(int position)
        {
            var elem = _items.ElementAt(position);
            return (int) elem.Model.Type;
        }

        public int GetViewTypeCount()
        {
            return 2;
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            var o = _items.ElementAt(position);
            return o;
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
                convertView = new TextView(_context);

                int padding = 16;
                int padding4 = 4;

#pragma warning disable 0618
                switch (rowType)
                {
                    case TypeItem:
                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceMedium);
                        convertView.SetPadding(32, padding, padding, padding);
                        break;
                    case TypeHeader:
                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceSmall);
                        convertView.SetPadding(padding, padding4, padding, padding4);
                        break;
                }
            }
#pragma warning restore 0618

            var o = (AndroidExampleModelWrapper)GetItem(position);
            var txt = o.Model.Name;
            ((TextView)convertView).SetText(txt, TextView.BufferType.Normal);

            return convertView;
        }
    }
}