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
        private readonly List<ExampleModel> _items;
        private readonly Context _context;

        public int GetBuildNumber()
        {
            var context = global::Android.App.Application.Context;
            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            return info.VersionCode;
        }

        public ActivityListAdapter(Context context)
        {
            _context = context;
            Resources res = context.Resources;

            _items = ExampleList.Items;
            
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(x => x.FullName.StartsWith("AnylineXamarinSDK")).FirstOrDefault();
            if (assembly != null)
            {
                Version ver = assembly.GetName().Version;
                _items.Where(x => x.Category.Equals(Category.Version)).FirstOrDefault().Name = $"Version: {ver} - Build: {GetBuildNumber()}";
            }
        }

        public override int GetItemViewType(int position)
        {
            var elem = _items.ElementAt(position);
            return (int) elem.Type;
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
            var txt = ((ExampleModel)GetItem(position)).Name;
            ((TextView)convertView).SetText(txt, TextView.BufferType.Normal);

            return convertView;
        }
    }
}