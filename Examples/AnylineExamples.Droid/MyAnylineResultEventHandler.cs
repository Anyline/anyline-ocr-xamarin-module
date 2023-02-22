using Android.App;
using Android.Content;
using IO.Anyline.Plugin;
using IO.Anyline2;
using Java.Lang;

namespace AnylineExamples.Droid
{
    /// <summary>
    /// This scan result listener implements IScanResultListener 
    /// in order to receive results and passes the JNI Handle to the 
    /// result activity.
    /// </summary>
    public class MyAnylineResultEventHandler : Java.Lang.Object, IEvent
    {
        public static readonly string TAG = typeof(ScanResultListener).Name;
        public string Title { get; set; }
        protected Activity Activity { get; set; }

        public MyAnylineResultEventHandler(Activity activity)
        {
            Activity = activity;
        }

        /// <summary>
        /// This method is called when a scan result is found.
        /// Since the native Java type is generic, we translated the type of the parameter to ScanResult due to Xamarin.Android generic binding limitations.
        /// </summary>
        /// <param name="data">The scan result</param>
        public void EventReceived(Object data)
        {
            if (data != null)
            {
                // because we can't simply pass the object through the intent, we'll pass the JNI handle & retrieve the object in the other activity
                var intent = new Intent(Activity.ApplicationContext, typeof(ResultActivity));
                intent.PutExtra("handle", data.Handle.ToInt32());
                intent.PutExtra("title", Title);
                Activity.StartActivity(intent);
            }
        }
    }
}