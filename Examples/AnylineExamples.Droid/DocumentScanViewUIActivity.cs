using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using IO.Anyline.View;
using System;
using System.Collections.Generic;

namespace AnylineExamples.Droid
{
    [Activity(Label = "Document [Extended UI]")]
    public class DocumentScanViewUIActivity : AppCompatActivity, DocumentScanViewUI.IDocumentScanViewListener
    {
        public static IList<ScanPage> ScanPages;

        public static readonly string TAG = typeof(DocumentScanViewUIActivity).Name;

        public static readonly string LICENSE_KEY = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";
        private DocumentScanViewUI documentScanViewUI;
        private bool _isInitialized = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ScanPages = new List<ScanPage>();
            base.OnCreate(savedInstanceState);
            try
            {
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                SetContentView(Resource.Layout.demo_activity_document_scan_view_ui);

                Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
             
                documentScanViewUI = FindViewById<DocumentScanViewUI>(Resource.Id.document_scan_view_ui);
                // initialize the documentScanViewConfig from a scan-view config file:
                DocumentScanViewConfig documentScanViewConfig = new DocumentScanViewConfig(this, "document_scan_view_config.json");

                documentScanViewUI.Init(LICENSE_KEY, documentScanViewConfig, "document_view_config.json", savedInstanceState);
                documentScanViewUI.SetDocumentScanViewListener(this);

                _isInitialized = true;
            }
            catch (Exception e)
            {
                Util.ShowError(e.ToString(), this);
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState = documentScanViewUI.AddSavedInstanceState(outState);
            base.OnSaveInstanceState(outState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            try
            {
                if (_isInitialized)
                    documentScanViewUI.StartScanning();

            }
            catch (Exception e)
            {
                Log.Debug(TAG, e.ToString());
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (_isInitialized)
                documentScanViewUI.StopScanning();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    GoBack();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            GoBack();
        }


        private void GoBack()
        {
            try
            {
                _isInitialized = false;
                // back button collapses bottom sheet if this is open
                if (documentScanViewUI.IsBottomSheetExpanded)
                {
                    documentScanViewUI.CollapseBottomSheet();
                    return;
                }
                documentScanViewUI.StopScanning();
                documentScanViewUI.Dispose();
            }
            catch (Exception) { }
            Finish();
        }

        public void OnCancel()
        {
            GoBack();
        }

        public void OnSave(IList<ScanPage> scannedPages)
        {
            ScanPages = scannedPages;
            SetResult(Result.Ok);
            Finish();
        }
    }
}