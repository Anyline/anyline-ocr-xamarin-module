using System;
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
using IO.Anyline.Plugin.Document;

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
        protected Activity Activity { get; set; }

        public ScanResultListener(Activity activity)
        {
            Activity = activity;
        }

        /// <summary>
        /// This method is called when a scan result is found.
        /// Since the native Java type is generic, the type of the parameter translates to Java.Lang.Object due to Xamarin.Android generic binding limitations.
        /// </summary>
        /// <param name="result">The scan result</param>
        public void OnResult(Java.Lang.Object result)
        {
            /*
             * In every case, the base type of the result is ScanResult.
             * For every use case, except document, you will find the type of result in the corresponding IO.Anyline.Plugin.* namespace;
             * E.g. IO.Anyline.Plugin.Meter.MeterScanResult for meter scanning.
             * 
             * For document scanning, it is simply of type ScanResult.
            */
            var scanResult = result as ScanResult;
            if(scanResult != null)
            {
                // because we can't simply pass the object through the intent, we'll pass the JNI handle & retrieve the object in the other activity
                var intent = new Intent(Activity.ApplicationContext, typeof(ResultActivity));
                intent.PutExtra("handle", scanResult.Handle.ToInt32());

                Activity.StartActivity(intent);
            }
        }
    }
}