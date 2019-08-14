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
using AnylineExamples.Shared;
using Java.Util;

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

                var dict = CreatePropertyList(scanResult);
                
                var listAdapter = new ResultListAdapter(this, dict);
                _resultListView.Adapter = listAdapter;
                Util.SetListViewHeightBasedOnChildren(_resultListView, this);
            }
        }

        private Dictionary<string, Java.Lang.Object> CreatePropertyList(Java.Lang.Object obj)
        {
            var dict = new Dictionary<string, Java.Lang.Object>();
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

                        try
                        {
                            var value = prop.GetValue(obj, null);


                            // filter out deprecated fields
                            if (prop.GetCustomAttributes(typeof(ObsoleteAttribute), true).ToArray().Length > 0)
                                continue;

                            Log.Debug(TAG, "{0}: {1}", prop.Name, value);
                            if (value != null)
                            {
                                // TODO: iterate through every result and display them
                                //if(value is JavaList)
                                //{
                                //    var i = 0;
                                //    var resultList = (value as JavaList);
                                //    foreach (Java.Lang.Object v in resultList)
                                //    {
                                //        var sublist = CreatePropertyList(v);
                                //        sublist.ToList().ForEach(x => dict.Add(x.Key + $" ({i})", x.Value));
                                //        i++;
                                //    }
                                //}
                                if (value is AnylineImage)
                                {
                                    var bitmap = (value as AnylineImage).Clone().Bitmap;
                                    dict.Add(prop.Name, bitmap);
                                }
                                else if (value is ID)
                                {
                                    var sublist = CreatePropertyList(value as ID);
                                    sublist.ToList().ForEach(x => dict.Add(x.Key, x.Value));
                                }
                                else if (value is IDFieldConfidences)
                                {
                                    var sublist = CreatePropertyList(value as IDFieldConfidences);
                                    sublist.ToList().ForEach(x => dict.Add($"{x.Key} (field confidence)", x.Value));
                                }
                                else
                                {
                                    var str = new Java.Lang.String(value.ToString()).ReplaceAll("\\\\n", "\\\n");
                                    dict.Add(prop.Name, str);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
                        }
                        break;
                }
            }
            
            // quick hack to re-order the list so that the result will be presented first:
            dict.MoveElementToIndex("Result", 0);

            return dict;
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