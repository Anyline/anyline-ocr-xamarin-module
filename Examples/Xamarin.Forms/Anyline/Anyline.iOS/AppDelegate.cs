using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Anyline.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());


            // INSERT YOUR LICENSE KEY HERE
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwKICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwKICAibWFqb3JWZXJzaW9uIjogIjI1IiwKICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwKICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwKICAibXVsdGlCYXJjb2RlIjogdHJ1ZSwKICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbCiAgICAiQUxMIgogIF0sCiAgInBpbmdSZXBvcnRpbmciOiB0cnVlLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiA5MCwKICAidmFsaWQiOiAiMjAyMS0wNi0zMCIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQpJbHE1REZNMU03QzEzNGJiaGo4dm9zMEFEVjEzNm1HbWNEYmdUbUdoWTd3dDlrR0gyYTRyK3RjeDJLYTNZN3d3R1EweThWeFZvZWVmQU5NWEtycm04bGkzN1MzKzdjWTU1dUZ1RVJPUkR6bmd3aCtYMmU3VGtkNDhiemd5Y1JpdnZkM09LZ3JiNDRUbDBycHExc2dOZVVzVVozRnEwd3dFM2VMQWx3VkFrdkRiVjdOdktaMEF5M3J6Mmg0TGNuTmpQTHErOTE0VmVPZUNDVUo3aU9VMW5vWUJKUlBqdDFmWHpqS1dOZmNXRXNPTlJrMVNaMUFzaXREZzNCMHVuZXZLSVNBWXRZT0hTL01DWDlseVlHS05acWQxODBrOXhscUVpbVVYTjc4UnFHd2ZLRFF2SFpoTWp4LzFzVFVrZXI4aFpNcGNtb0c5NWJMSjhoTlFRNjNuZ2c9PQ==";
            NSError licenseError;

            AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey, out licenseError);

            if (licenseError != null)
            {
                throw new Exception(licenseError.LocalizedDescription);
            }


            return base.FinishedLaunching(app, options);
        }
    }
}
