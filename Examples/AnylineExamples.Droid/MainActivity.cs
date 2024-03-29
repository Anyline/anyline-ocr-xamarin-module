﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using System;
using System.Threading.Tasks;

namespace AnylineExamples.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IO.Anyline.Products.IAnylineUpdateDelegate
    {
        // the "IO.Anyline.Products.IAnylineUpdateDelegate" interface is only necessary when using the Anyline Trainer - OTA
        // for the default usage, it is not necessary to implement this interface

        private ActivityListAdapter listAdapter;
        private ListView listView;

        //private IO.Anyline.Trainer.ProjectContext projectContext;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.toolbar);
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
            string licenseKey = "YOUR_LICENSE_KEY_HERE";
            try
            {
                IO.Anyline2.AnylineSdk.Init(licenseKey, this);
            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            TriggerAnylineTrainerUpdate();

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

                if (item.Model.Name == "Scan NFC of Passports")
                {
                    var intent = new Intent(ApplicationContext, typeof(NFC.MRZScanActivity));

                    intent.PutExtra("jsonPath", jsonPath);
                    intent.PutExtra("title", item.Model.Name);
                    StartActivity(intent);
                }
                else
                {
                    var intent = new Intent(ApplicationContext, typeof(ScanActivity));

                    intent.PutExtra("jsonPath", jsonPath);
                    intent.PutExtra("title", item.Model.Name);
                    StartActivity(intent);
                }
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

        #region Anyline Trainer  - OTA
        private void TriggerAnylineTrainerUpdate()
        {
            // //The id of the project on the Anyline Trainer
            // string projectId = "";
            // //The API key for the project
            // string apiKey = "";
            // // The Asset ID
            // string assetId = "";
            // // An id for the Anyline Scan Plugin that will be using these assets
            // string pluginId = "";
            // projectContext = new IO.Anyline.Trainer.ProjectContext(this, pluginId, projectId, apiKey, assetId);

            // IO.Anyline.Products.AnylineUpdater.Update(this, projectContext, this);
            /* Check the methods OnUpdateError, OnUpdateFinished and OnUpdateProgress for the callbacks of the Update method. */
        }

        public void OnUpdateError(string error)
        {
            System.Diagnostics.Debug.WriteLine("Update FAILED");
        }

        public void OnUpdateFinished()
        {
            System.Diagnostics.Debug.WriteLine("Update Finished");
        }

        public void OnUpdateProgress(string filename, float progress)
        {
            float updateProgress = (int)(progress * 100);
            System.Diagnostics.Debug.WriteLine("Update progress: %" + updateProgress);
        }

        #endregion
    }
}

