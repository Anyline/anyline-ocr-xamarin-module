using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Util;
using AT.Nineyards.Anyline.Models;
using IO.Anyline.Plugin;
using AT.Nineyards.Anyline.Modules.Mrz;
using IO.Anyline.Plugin.ID;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ResultActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ResultActivity).Name;

        private ListView _resultListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.result_activity);
            _resultListView = FindViewById<ListView>(Resource.Id.result_list_view);
            
            var handle = new IntPtr(Intent.GetIntExtra("handle", 0));
            var scanResult = GetObject<ScanResult>(handle, JniHandleOwnership.DoNotTransfer);
            
            if (scanResult != null)
            {
                Title = scanResult.GetType().Name;

                var list = CreatePropertyList(scanResult);
                
                var listAdapter = new ResultListAdapter(this, list);
                _resultListView.Adapter = listAdapter;
                Util.SetListViewHeightBasedOnChildren(_resultListView, this);
            }
        }

        private List<Java.Lang.Object> CreatePropertyList(Java.Lang.Object obj)
        {
            var list = new List<Java.Lang.Object>();
            foreach (var prop in obj.GetType().GetProperties())
            {

                switch (prop.Name)
                {
                    // filter out properties that we don't want to display
                    case "JniPeerMembers":
                    case "JniIdentityHashCode":
                    case "Handle":
                    case "PeerReference":
                    case "Outline":
                    case "Class":
                        break;
                    default:

                        var value = prop.GetValue(obj, null);

                        Log.Debug(TAG, "{0}: {1}", prop.Name, value);
                        if (value != null)
                        {
                            if (value is AnylineImage)
                            {
                                var bitmap = (value as AnylineImage).Clone().Bitmap;
                                list.Add(prop.Name);
                                list.Add(bitmap);
                            }
                            else if (value is ID)
                            {
                                var sublist = CreatePropertyList(value as ID);
                                list = list.Concat(sublist).ToList();
                            }
                            else
                            {
                                list.Add(prop.Name);

                                var str = new Java.Lang.String(value.ToString()).ReplaceAll("\\\\n", "\\\n");
                                list.Add(str);
                            }
                        }
                        break;
                }
            }
            return list;
        }

        #region going back & cleanup
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    GoBack();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            GoBack();
        }

        private void GoBack()
        {
            Finish();
        }
        #endregion


    }
}