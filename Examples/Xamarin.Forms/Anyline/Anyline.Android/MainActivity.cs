using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.App;

namespace Anyline.Droid
{
    [Activity(Label = "Anyline", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
        /*, ScreenOrientation = ScreenOrientation.Landscape*/)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

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

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
    }
}