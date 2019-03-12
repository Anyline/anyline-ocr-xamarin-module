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
using IO.Anyline.Xamarin.Support.Plugins.Document;
using IO.Anyline.Plugin.Document;
using System.Collections;
using Android.Graphics;

namespace AnylineExamples.Droid
{
    /// <summary>
    /// This scan result listener implements IDocumentScanResultListener 
    /// in order to receive results and passes the JNI Handle to the 
    /// result activity.
    /// </summary>
    public class DocumentScanResultListener : ScanResultListener, IDocumentScanResultListener
    {
        public DocumentScanResultListener(Activity activity) : base(activity) { }

        public void OnResult(ScanResult scanResult)
        {
            base.OnResult(scanResult);
        }
        
        public void OnPictureProcessingFailure(IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error) { }

        public void OnPictureTransformed(AnylineImage transformedImage) { }

        public void OnPictureTransformError(IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error) { }

        public void OnPreviewProcessingFailure(IO.Anyline.Plugin.Document.DocumentScanViewPlugin.DocumentError error) { }

        public void OnPreviewProcessingSuccess(AnylineImage anylineImage) { }

        public void OnTakePictureError(Throwable error) { }

        public void OnTakePictureSuccess() { }

        public bool OnDocumentOutlineDetected(IList<PointF> corners, bool documentShapeAndBrightnessValid) { return true; }

        public void OnPictureCornersDetected(AnylineImage fullFrame, IList<PointF> corners) { }
    }
}