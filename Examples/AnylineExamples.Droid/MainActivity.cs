using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using AnylineExamples.Shared;

namespace AnylineExamples.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ActivityListAdapter listAdapter;
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_main);
            
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            
            listView = FindViewById<ListView>(Resource.Id.listView);

            listAdapter = new ActivityListAdapter(this);
            listView.Adapter = listAdapter;

            //adapt height of listView so it fits.
            Util.SetListViewHeightBasedOnChildren(listView);

            listView.ItemClick -= ListView_ItemClick;
            listView.ItemClick += ListView_ItemClick;

            int REQUEST_CAMERA = 0;
            
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Camera) != Permission.Granted)
            {
                // Should we show an explanation?
                if (!ActivityCompat.ShouldShowRequestPermissionRationale(this, Android.Manifest.Permission.Camera))
                {
                    // No explanation needed, we can request the permission.
                    ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.Camera }, REQUEST_CAMERA);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Permission Granted!");
            }
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs a)
        {// unregister first
            listView.ItemClick -= ListView_ItemClick;

#pragma warning disable CS4014
            Task.Run(async () =>
            {
                // after 500 ms, register the event again
                await Task.Delay(500);
                listView.ItemClick += ListView_ItemClick;
            }).ConfigureAwait(false);
#pragma warning restore CS4014

            if (listAdapter.GetItemViewType(a.Position) == ActivityListAdapter.TypeHeader)
                return;

            var item = (ExampleModel)listAdapter.GetItem(a.Position);
            var jsonPath = item.JsonPath;

            if (string.IsNullOrEmpty(jsonPath))
                return;
            try
            {
                var intent = new Intent(ApplicationContext, typeof(ScanActivity));
                intent.PutExtra("jsonPath", jsonPath);
                intent.PutExtra("title", item.Name);
                StartActivity(intent);

            }
            catch (Java.Lang.ClassNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            /*if (id == Resource.Id.action_settings)
            {
                return true;
            }*/

            return base.OnOptionsItemSelected(item);
        }
	}
}

