using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using IO.Anyline.View;
using System.Collections.Generic;

namespace AnylineExamples.Droid
{
    [Activity(Label = "CropViewUIActivity")]
    public class CropViewUIActivity : AppCompatActivity, CropViewUI.ICropViewUIListener
    {
        private CropViewUI cropViewUI;

        public void OnCancel()
        {
            Finish();
        }

        public void OnSave(string filePath, IList<PointF> scaledCorners)
        {
            Intent data = new Intent();
            // pass the path of the cropped file and (adjusted) corners to the calling activity:
            DocScanUIMainActivity.CornersForCropUI = scaledCorners;
            data.PutExtra(CropViewUI.ResultCroppedImagePath, filePath);
            SetResult(Result.Ok, data);
            Finish();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            // save state of activity before an activity is paused:
            outState = cropViewUI.AddSavedInstanceState(outState);
            base.OnSaveInstanceState(outState);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.demo_activity_crop_view_ui);

            // corners and the fullImageFilePath are required parameters for cropViewUI - calling activity has to pass it:
            IList<PointF> corners = DocScanUIMainActivity.CornersForCropUI;
            string fullImagefilePath = Intent.Extras.GetString(DocScanUIMainActivity.EXTRA_FULL_IMAGE_PATH);

            // initialize the documentScanViewConfig from a scan-view config file:
            DocumentScanViewConfig documentScanViewConfig = new DocumentScanViewConfig(this, "document_scan_view_config.json");

            // init the cropViewUI from the layout file:
            cropViewUI = FindViewById<CropViewUI>(Resource.Id.crop_document_view_new);

            cropViewUI.Init(documentScanViewConfig, fullImagefilePath, corners, savedInstanceState);
            cropViewUI.SetCropViewUIListener(this);

        }
    }
}