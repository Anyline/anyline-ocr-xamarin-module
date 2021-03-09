using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Anyline.Droid
{
    [Activity(Label = "Anyline.XamarinForms.Android", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Instance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


            try
            {
                // INSERT YOUR LICENSE KEY HERE
                string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwKICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwKICAibWFqb3JWZXJzaW9uIjogIjI1IiwKICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwKICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwKICAibXVsdGlCYXJjb2RlIjogdHJ1ZSwKICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbCiAgICAiQUxMIgogIF0sCiAgInBpbmdSZXBvcnRpbmciOiB0cnVlLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiA5MCwKICAidmFsaWQiOiAiMjAyMS0wNi0zMCIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQpJbHE1REZNMU03QzEzNGJiaGo4dm9zMEFEVjEzNm1HbWNEYmdUbUdoWTd3dDlrR0gyYTRyK3RjeDJLYTNZN3d3R1EweThWeFZvZWVmQU5NWEtycm04bGkzN1MzKzdjWTU1dUZ1RVJPUkR6bmd3aCtYMmU3VGtkNDhiemd5Y1JpdnZkM09LZ3JiNDRUbDBycHExc2dOZVVzVVozRnEwd3dFM2VMQWx3VkFrdkRiVjdOdktaMEF5M3J6Mmg0TGNuTmpQTHErOTE0VmVPZUNDVUo3aU9VMW5vWUJKUlBqdDFmWHpqS1dOZmNXRXNPTlJrMVNaMUFzaXREZzNCMHVuZXZLSVNBWXRZT0hTL01DWDlseVlHS05acWQxODBrOXhscUVpbVVYTjc4UnFHd2ZLRFF2SFpoTWp4LzFzVFVrZXI4aFpNcGNtb0c5NWJMSjhoTlFRNjNuZ2c9PQ==";
                IO.Anyline.AnylineSDK.Init(licenseKey, this);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}