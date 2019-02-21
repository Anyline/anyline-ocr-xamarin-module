﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IO.Anyline.Plugin;
using IO.Anyline.Plugin.Meter;
using Java.Lang;

using System.Reflection;
using Android.Util;
using AT.Nineyards.Anyline.Models;

namespace AnylineExamples.Droid
{
    /// <summary>
    /// This scan result listener implements IScanResultListener 
    /// in order to receive results and passes the JNI Handle to the 
    /// result activity.
    /// </summary>
    public class ScanResultListener : Java.Lang.Object, IScanResultListener
    {
        public static readonly string TAG = typeof(ScanResultListener).Name;
        private Activity _activity;

        public ScanResultListener(Activity activity)
        {
            _activity = activity;
        }

        /// <summary>
        /// Since the native Java type is generic, the type of the parameter translates to 
        /// </summary>
        /// <param name="result"></param>
        public void OnResult(Java.Lang.Object result)
        {
            var scanResult = result as ScanResult;
            if(scanResult != null)
            {
                // because the scan result is a complex object, we'll pass the JNI handle & retrieve the object later
                var intent = new Intent(_activity.ApplicationContext, typeof(ResultActivity));
                intent.PutExtra("handle", scanResult.Handle.ToInt32());

                _activity.StartActivity(intent);
            }
        }
    }
}