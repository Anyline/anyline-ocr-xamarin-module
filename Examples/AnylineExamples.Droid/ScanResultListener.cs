using Android.App;
using Android.Content;
using IO.Anyline.Plugin;

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
        /// Since the native Java type is generic, we translated the type of the parameter to ScanResult due to Xamarin.Android generic binding limitations.
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
            if(result != null)
            {
                // because we can't simply pass the object through the intent, we'll pass the JNI handle & retrieve the object in the other activity
                var intent = new Intent(Activity.ApplicationContext, typeof(ResultActivity));
                intent.PutExtra("handle", result.Handle.ToInt32());

                Activity.StartActivity(intent);
            }
        }
    }
}