using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using AT.Nineyards.Anyline.Modules.Document;
using AT.Nineyards.Anyline.Models;
using static AT.Nineyards.Anyline.Modules.Document.NativeDocumentScanView;
using AT.Nineyards.Anylinexamarin.Support.Modules.Document;

namespace AnylineXamarinApp.Document
{
    [Activity(Label = "", 
        MainLauncher = false, 
        Icon = "@drawable/ic_launcher", 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, 
        HardwareAccelerated = true)]
    public class DocumentActivity : Activity, IDocumentResultListener
    {
        public static string TAG = typeof(DocumentActivity).Name;

        private DocumentScanView _scanView;        
        private ImageView _imageViewResult;      
        private TextView _textView;
        private bool _toastAlreadyShowing;

        protected override void OnCreate(Bundle bundle)
        {
            Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);

            base.OnCreate(bundle);

            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.DocumentActivity);

            SetTitle(Resource.String.scan_document);

            _textView = FindViewById<TextView>(Resource.Id.text_feedback);
            _textView.Text = "";

            _scanView = FindViewById<DocumentScanView>(Resource.Id.document_scan_view);
            _imageViewResult = FindViewById<ImageView>(Resource.Id.image_result);
            
            // clear image
            _imageViewResult.Click += ResultImage_Click;

            _scanView.SetConfigFromAsset("DocumentConfig.json");

            // you can set the max output resolution of your image here so it will be scaled to a desired size
            //_scanView.SetMaxDocumentOutputResolution(new Java.Lang.Double(width), new Java.Lang.Double(height));
            
            // you can limit the supported document ratios as follows:
            //Java.Lang.Double[] ratios = { new Java.Lang.Double(DocumentRatio.DinAxLandscape.Ratio), new Java.Lang.Double(DocumentRatio.DinAxPortrait.Ratio) };
            //_scanView.SetDocumentRatios(ratios);

            _scanView.InitAnyline(MainActivity.LicenseKey, this);

            _scanView.CameraOpened += (s, e) =>
            {                
                Log.Debug(TAG, "Camera opened successfully. Frame resolution " + e.Width + " x " + e.Height);
                _scanView.StartScanning();
            };

            _scanView.CameraError += (s, e) => { Log.Error(TAG, "OnCameraError: " + e.Event.Message); };

        }

        private void ResultImage_Click(object sender, EventArgs e)
        {             
            _imageViewResult.SetImageBitmap(null);             
        }

        public void OnResult(DocumentResult scanResult)
        {
            _textView.Text = "Document scanned successfully.";
            
            var resImg = (scanResult.Result as AnylineImage).Clone();
            
            _imageViewResult.SetImageBitmap(resImg.Bitmap);

            _toastAlreadyShowing = false;
            
        }
        
        // handle an error while processing the full picture here - the preview will be restarted automatically
        void IDocumentResultListener.OnPictureProcessingFailure(DocumentError error)
        {
            
            var text = "Error scanning full document. ";
            var e = error.ToString();

            if (e.Equals(DocumentScanView.DocumentError.DocumentNotSharp.ToString()))
                text += "Document is not sharp. Please hold the camera steadily and ensure the document is in focus.";
            if (e.Equals(DocumentScanView.DocumentError.DocumentSkewTooHigh.ToString()))
                text += "Document is skewed. Place the camera directly above the document.";
            if (e.Equals(DocumentScanView.DocumentError.DocumentOutlineNotFound.ToString()))
                text += "Could not detect document outline.";
            if (e.Equals(DocumentScanView.DocumentError.GlareDetected.ToString()))
                text += "Please remove the glare.";
            if (e.Equals(DocumentScanView.DocumentError.ImageTooDark.ToString()))
                text += "The image is too dark. Please ensure there is enough light.";
            if (e.Equals(DocumentScanView.DocumentError.Unknown.ToString()))
                text += "Unknown Failure.";

            _textView.Text = text;
        }

        // this is called on any error while processing the document image
        // Note: this is called every time an error occurs in a run, so that might be quite often
        // An error message should only be presented to the user after some time
        void IDocumentResultListener.OnPreviewProcessingFailure(DocumentScanView.DocumentError error)
        {
            _textView.Text = "";

            var e = error.ToString();
            string text = "";

            if (e.Equals(DocumentScanView.DocumentError.DocumentNotSharp.ToString()))
                text += "Document is not sharp. Please hold the camera steadily and ensure the document is in focus.";
            if (e.Equals(DocumentScanView.DocumentError.DocumentSkewTooHigh.ToString()))
                text += "Document is skewed. Place the camera directly above the document.";
            if (e.Equals(DocumentScanView.DocumentError.DocumentOutlineNotFound.ToString()))
                text += "Could not detect document outline.";
            if (e.Equals(DocumentScanView.DocumentError.GlareDetected.ToString()))
                text += "Please remove the glare.";
            if (e.Equals(DocumentScanView.DocumentError.ImageTooDark.ToString()))
                text += "The image is too dark. Please ensure there is enough light.";
            if (e.Equals(DocumentScanView.DocumentError.Unknown.ToString()))
                text += "Unknown Failure.";

            if (text != "")
            {
                _textView.Text = text;                
            }            
        }
        
        // this is called after the preview of the document is completed, and a full picture will be processed automatically
        void IDocumentResultListener.OnPreviewProcessingSuccess(AnylineImage anylineImage)
        {
            _textView.Text = "Scanning full document. Please hold still.";
        }

        // This is called if the image could not be captured from the camera (most probably because of an OutOfMemoryError)
        void IDocumentResultListener.OnTakePictureError(Java.Lang.Throwable error)
        {
            Console.WriteLine(error.Message);
        }

        // this is called after the image has been captured from the camera and is about to be processed
        void IDocumentResultListener.OnTakePictureSuccess()
        {
            if (_toastAlreadyShowing) return;
            _toastAlreadyShowing = true;
            Toast.MakeText(this, "Processing the picture. Please wait.", ToastLength.Short).Show();
        }

        bool IDocumentResultListener.OnDocumentOutlineDetected(IList<PointF> corners, bool documentShapeAndBrightnessValid) { return false; }

        void IDocumentResultListener.OnPictureCornersDetected(AnylineImage fullFrame, IList<PointF> corners)
        {
            //
        }

        void IDocumentResultListener.OnPictureTransformError(DocumentError error)
        {
            //
        }

        void IDocumentResultListener.OnPictureTransformed(AnylineImage transformedImage)
        {
            //
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _scanView.StartScanning();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _scanView.CancelScanning();
            _scanView.ReleaseCameraInBackground();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Finish();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_imageViewResult != null)
                _imageViewResult.Click -= ResultImage_Click;
            _scanView?.Dispose();
            _scanView = null;

            // explicitly free memory
            GC.Collect(GC.MaxGeneration);
        }        
    }
}