﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace AnylineXamarinForms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {

        /*
         *  Add this method manually to prevent the following exception:
         *  Foundation.MonoTouchException: Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: -[AppDelegate window]: unrecognized selector sent to instance
         *  
         *  See https://bugzilla.xamarin.com/show_bug.cgi?id=41859
         */
        //[Export("window")]
        //public UIWindow GetWindow() { return UIApplication.SharedApplication.Windows[0]; }

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

            return base.FinishedLaunching(app, options);
        }
    }
}
