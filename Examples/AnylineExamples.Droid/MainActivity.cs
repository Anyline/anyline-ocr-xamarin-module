using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Threading.Tasks;

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
            Util.SetListViewHeightBasedOnChildren(listView, this);

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
         
            // INSERT YOUR LICENSE KEY HERE
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwKICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwKICAibWFqb3JWZXJzaW9uIjogIjI1IiwKICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwKICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwKICAibXVsdGlCYXJjb2RlIjogdHJ1ZSwKICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbCiAgICAiQUxMIgogIF0sCiAgInBpbmdSZXBvcnRpbmciOiB0cnVlLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiA5MCwKICAidmFsaWQiOiAiMjAyMS0wNi0zMCIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQpJbHE1REZNMU03QzEzNGJiaGo4dm9zMEFEVjEzNm1HbWNEYmdUbUdoWTd3dDlrR0gyYTRyK3RjeDJLYTNZN3d3R1EweThWeFZvZWVmQU5NWEtycm04bGkzN1MzKzdjWTU1dUZ1RVJPUkR6bmd3aCtYMmU3VGtkNDhiemd5Y1JpdnZkM09LZ3JiNDRUbDBycHExc2dOZVVzVVozRnEwd3dFM2VMQWx3VkFrdkRiVjdOdktaMEF5M3J6Mmg0TGNuTmpQTHErOTE0VmVPZUNDVUo3aU9VMW5vWUJKUlBqdDFmWHpqS1dOZmNXRXNPTlJrMVNaMUFzaXREZzNCMHVuZXZLSVNBWXRZT0hTL01DWDlseVlHS05acWQxODBrOXhscUVpbVVYTjc4UnFHd2ZLRFF2SFpoTWp4LzFzVFVrZXI4aFpNcGNtb0c5NWJMSjhoTlFRNjNuZ2c9PQ==";
            IO.Anyline.AnylineSDK.Init(licenseKey, this);
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs a)
        {
            // unregister first
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

            var item = (AndroidExampleModelWrapper)listAdapter.GetItem(a.Position);
            var jsonPath = item.Model.JsonPath;

            if (string.IsNullOrEmpty(jsonPath))
                return;
            try
            {
                var intent = new Intent(ApplicationContext, typeof(ScanActivity));
                //if (item.Model.Type == ItemType.DocumentUI)
                //{
                //    intent = new Intent(ApplicationContext, typeof(DocScanUIMainActivity));
                //}

                intent.PutExtra("jsonPath", jsonPath);
                intent.PutExtra("title", item.Model.Name);
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
            return base.OnOptionsItemSelected(item);
        }
    }
}

