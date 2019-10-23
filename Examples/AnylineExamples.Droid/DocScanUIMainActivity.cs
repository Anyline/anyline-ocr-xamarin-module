using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Widget;
using Java.IO;
using Java.Text;
using System;
using System.Collections.Generic;

namespace AnylineExamples.Droid
{
    [Activity(Label = "DocScanUIMainActivity")]
    public class DocScanUIMainActivity : AppCompatActivity
    {
        public static int REQUEST_CODE_SCAN = 1;
        private static int CROP_DOCUMENT_REQUEST = 2;

        public static String RESULT_CROPPED_IMAGE_PATH = "RESULT_CROPPED_IMAGE_PATH";
        public static String RESULT_CORNERS = "RESULT_CORNERS";
        public static String EXTRA_FULL_IMAGE_PATH = "EXTRA_FULL_IMAGE_PATH";
        public static String EXTRA_CORNERS = "EXTRA_CORNERS";
        public static String RESULT_PAGES = "RESULT_PAGES";

        private String[] fullImagePath = null;      // a list of scanned full pictures
        private String[] croppedImagePath = null;   // a list of (automatically or manually) cropped pictures. a cropped picture contains the document
        private IList<PointF>[] corners = null;      // a list of 4 corners, specifying a cropped picture within the full picture

        private int selectedPosition;               // used to update the list of cropped images and corners after adjusting corners in the cropView

        ListView imageListView;
        Button btScan;

        File fullImgFile;                           // the image as it was taken by the camera. need to declare it globally as it is accessed in a listener

        // call the documentScanView where a user will scan documents (automatically or manually):
        private void callDocumentScanViewUIActivity()
        {
            Intent scanActivityIntent = new Intent(this, typeof(DocumentScanViewUIActivity));
            Bundle b = new Bundle();
            StartActivityForResult(scanActivityIntent, REQUEST_CODE_SCAN);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_doc_scan_ui_main);

            btScan = FindViewById<Button>(Resource.Id.btScan);
            btScan.Click += (sender, e) =>
            {
                callDocumentScanViewUIActivity();
            };
        }

        private string getPictureResolution(string imagePath)
        {
            BitmapFactory.Options bitMapOption = new BitmapFactory.Options();
            bitMapOption.InJustDecodeBounds = true;
            BitmapFactory.DecodeFile(imagePath, bitMapOption);
            return (NumberFormat.GetInstance(Resources.Configuration.Locale).Format(bitMapOption.OutWidth) + " x " +
                    NumberFormat.GetInstance(Resources.Configuration.Locale).Format(bitMapOption.OutHeight));
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_CODE_SCAN && resultCode == Result.Ok)
            {
            }
        }
    }

}