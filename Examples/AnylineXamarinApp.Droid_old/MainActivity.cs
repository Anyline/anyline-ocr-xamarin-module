using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AnylineXamarinApp.Energy;
using System.Threading.Tasks;
using System.Diagnostics;
using Android.Support.V4.Content;
using Android.Content.PM;
using Android.Support.V4.App;

namespace AnylineXamarinApp
{
    [Activity(Label = "Anyline Xamarin Examples", 
        MainLauncher = true, Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        //INSERT YOUR LICENSE KEY HERE
        //AT.Anyline.Xamarin.App.Droid
        public const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";
        
        private ActivityListAdapter listAdapter;
        private ListView listView;

        /// <summary>
        /// Called when the activity is starting.
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainActivity);

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
                if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Android.Manifest.Permission.Camera))
                {
                    // Provide an additional rationale to the user if the permission was not granted
                    // and the user would benefit from additional context for the use of the permission.
                    // For example if the user has previously denied the permission.

                    // Show an explanation to the user *asynchronously* -- don't block
                    // this thread waiting for the user's response! After the user
                    // sees the explanation, try again to request the permission.

                    // Log.Info(TAG, "Displaying camera permission rationale to provide additional context.");
                }
                else
                {
                    // No explanation needed, we can request the permission.
                    ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.Camera }, REQUEST_CAMERA);

                    // REQUEST_CAMERA is an app-defined int constant. The callback method gets the
                    // result of the request.
                }
            }
                else
                {
                System.Diagnostics.Debug.WriteLine("Permission Granted!");
            }
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

            //starts activity from the given class name in example_activities.xml
            var type = Type.GetType(listAdapter.ClassName(a.Position));

            if (type == null)
                return;
            try
            {
                var intent = new Intent(ApplicationContext, type);

                // we generate the energy activity with different radiobuttons, depending on the use-case
                // therefore we add which scan modes should be selectable
                if (type == typeof(EnergyActivity))
                    intent.PutExtra("OBJECT", listAdapter.GetItem(a.Position).ToString());

                StartActivity(intent);
                
            }
            catch (Java.Lang.ClassNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Kills the App when Back is pressed
        /// </summary>
        public override void OnBackPressed()
        {
            Finish();
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}

