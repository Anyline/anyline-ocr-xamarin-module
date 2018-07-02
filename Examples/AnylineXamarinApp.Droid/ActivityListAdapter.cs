using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Util;
using System;
using System.Reflection;
using System.Linq;
using Android.Content.PM;

namespace AnylineXamarinApp
{
    public class ActivityListAdapter : BaseAdapter
    {
        public const int TypeItem = 0;
        public const int TypeHeader = 1;
        private readonly string[] _names;
        private readonly string[] _classes;
        private readonly Context _context;

        private string GetBuildNumber()
        {
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            return ver.ToString();
        }

        public ActivityListAdapter(Context context)
        {
            _context = context;
            Resources res = context.Resources;

            _names = res.GetStringArray(Resource.Array.example_activity_names);
            _classes = res.GetStringArray(Resource.Array.example_activity_classes);

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = assemblies.Where(x => x.FullName.StartsWith("AnylineXamarinSDK")).FirstOrDefault();
            if (assembly != null)
            {
                Version ver = assembly.GetName().Version;
                _names[_names.Length - 1] = $"Version: {ver}, Build: {GetBuildNumber()}";
            }
        }

        public override int GetItemViewType(int position)
        {            
            return "HEADER".Equals(_classes[position]) ? TypeHeader : TypeItem;
        }

        public int GetViewTypeCount()
        {
            return 2;
        }

        public override int Count
        {
            get { return _names.Length; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return _names[position];
        }

        public string ClassName(int position)
        {
            return _classes[position];
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
                
                int padding = DimensUtil.GetPixFromDp(_context, 16);
                int padding4 = DimensUtil.GetPixFromDp(_context, 4);

#pragma warning disable 0618
                switch (rowType)
                {
                    case TypeItem:
                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceMedium);
                        convertView.SetPadding(DimensUtil.GetPixFromDp(_context,32), padding, padding, padding);
                        break;
                    case TypeHeader:
                        ((TextView)convertView).SetTextAppearance(_context, Android.Resource.Style.TextAppearanceSmall);
                        convertView.SetPadding(padding, padding4, padding, padding4);
                        break;
                }
            }
#pragma warning restore 0618
            ((TextView)convertView).SetText(GetItem(position).ToString(), TextView.BufferType.Normal);

            return convertView;
        }
    }
}