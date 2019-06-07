using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using AT.Nineyards.Anyline.Camera;
using IO.Anyline.View;

using Android.Support.V7.App;
using Android.Util;
using IO.Anyline.Plugin.ID;
using IO.Anyline.Plugin.Barcode;
using System.Collections;

namespace AnylineExamples.Droid
{
    [Activity(Label = "",
        MainLauncher = false,
        //ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class ScanActivity : AppCompatActivity
    {
        public static readonly string TAG = typeof(ScanActivity).Name;

        //INSERT YOUR LICENSE KEY HERE
        public static readonly string LICENSE_KEY = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";
        
        private ScanView _scanView;
        private bool _isInitialized = false;
        
        private ScanResultListener _scanResultListener;

        public ScanActivity()
        {
            // the document result listener is inheriting from ScanResultListener and additionally implementing the callbacks for document scanning
            // therefore, we're using it here for all the use-cases.
            _scanResultListener = new DocumentScanResultListener(this);
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            try
            {
                SupportActionBar.SetHomeButtonEnabled(true);
                SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                
                // we pass the json path from the previous activity
                var jsonPath = Intent.GetStringExtra("jsonPath");
                
                // we pass the title from the previous activity
                Title = Intent.GetStringExtra("title");

                Window.SetFlags(WindowManagerFlags.KeepScreenOn, WindowManagerFlags.KeepScreenOn);
                SetContentView(Resource.Layout.scan_activity);

                _scanView = FindViewById<ScanView>(Resource.Id.scan_view);
                
                // the initialization parses the json configuration and builds the whole use-case
                _scanView.Init(jsonPath, LICENSE_KEY);
                
                /*
                 * Depending on your config/use-case, the ScanViewPlugin is of a different type.
                 * You need to add your implementation of IO.Anyline.Plugin.IScanResultListener to retrieve scan results.
                 */
                _scanView.ScanViewPlugin.AddScanResultListener(_scanResultListener);

                //var myBarcodeListener = new MyBarcodeListener();
                //_scanView.CameraView.EnableBarcodeDetection(myBarcodeListener, null);

                //var bar = new AT.Nineyards.Anyline.Modules.Barcode.NativeBarcodeScanView(ApplicationContext, null);

                // handle camera open events
                _scanView.CameraOpened += ScanView_CameraOpened;

                // handle camera error events
                _scanView.CameraError += ScanView_CameraError;

                _isInitialized = true;
            }
            catch (Exception e)
            {
                Util.ShowError(e.ToString(), this);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();

            try
            {
                if (_isInitialized)
                    _scanView.Start();
            }
            catch (Exception e)
            {
                Log.Debug(TAG, e.ToString());
            }
        }

        private void ScanView_CameraError(object sender, CameraErrorEventArgs e)
        {
            Log.Debug(TAG, e.ToString());
        }

        private void ScanView_CameraOpened(object sender, CameraOpenedEventArgs args)
        {
            Log.Debug(TAG, $"Camera opened with resolution {args.Width} x {args.Height}.");
        }

        #region going back & cleanup
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

                if (_scanView != null)
                {
                    _scanView.Stop();
                    _scanView.CameraView.ReleaseCamera();

                    _scanView.CameraOpened -= ScanView_CameraOpened;
                    _scanView.CameraError -= ScanView_CameraError;

                    _scanView.Dispose();
                    _scanView = null;

                    GC.Collect();
                }
            } catch (Exception) { }
            Finish();
        }
        #endregion
    }
}