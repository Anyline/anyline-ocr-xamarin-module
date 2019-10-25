using Android.App;
using Android.Content;
using Android.Database;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Text;
using System.Collections.Generic;

namespace AnylineExamples.Droid
{
    [Activity(Label = "Document [Extended UI]")]
    public class DocScanUIMainActivity : AppCompatActivity
    {
        public static int REQUEST_CODE_SCAN = 1;
        private static int CROP_DOCUMENT_REQUEST = 2;

        public static string RESULT_CROPPED_IMAGE_PATH = "RESULT_CROPPED_IMAGE_PATH";
        public static string RESULT_CORNERS = "RESULT_CORNERS";
        public static string EXTRA_FULL_IMAGE_PATH = "EXTRA_FULL_IMAGE_PATH";
        public static string EXTRA_CORNERS = "EXTRA_CORNERS";
        public static string RESULT_PAGES = "RESULT_PAGES";

        private static string[] FullImagePath = null;      // a list of scanned full pictures
        private static string[] CroppedImagePath = null;   // a list of (automatically or manually) cropped pictures. a cropped picture contains the document
        private static IList<IList<PointF>> Corners = null;      // a list of 4 corners, specifying a cropped picture within the full picture
        public static IList<PointF> CornersForCropUI = null;      // a list of 4 corners, specifying a cropped picture within the full picture

        private static int selectedPosition;               // used to update the list of cropped images and corners after adjusting corners in the cropView

        ListView imageListView;
        Button btScan;

        static File fullImgFile;                           // the image as it was taken by the camera. need to declare it globally as it is accessed in a listener

        static Activity CurrentActivity;

        // call the documentScanView where a user will scan documents (automatically or manually):
        private void callDocumentScanViewUIActivity()
        {
            Intent scanActivityIntent = new Intent(this, typeof(DocumentScanViewUIActivity));
            Bundle b = new Bundle();
            StartActivityForResult(scanActivityIntent, REQUEST_CODE_SCAN);
        }

        // call the cropView where a user will adjust corners of a cropped image or - in case the documentScanView did not detect corners - set corners initially:
        private static void callCropViewUIActivity(int pos, File fullImgFile)
        {
            CornersForCropUI = Corners[pos];

            Intent cropActivityIntent = new Intent(CurrentActivity, typeof(CropViewUIActivity));
            cropActivityIntent.PutExtra(EXTRA_FULL_IMAGE_PATH, fullImgFile.AbsolutePath);
            CurrentActivity.StartActivityForResult(cropActivityIntent, CROP_DOCUMENT_REQUEST);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_doc_scan_ui_main);

            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            CurrentActivity = this;
            imageListView = FindViewById<ListView>(Resource.Id.list);

            btScan = FindViewById<Button>(Resource.Id.btScan);
            btScan.Click += (sender, e) =>
            {
                // if "scan document" is called repeatedly the user will be warned that scan results from the previous pass will get lost:
                if (FullImagePath != null &&
                    FullImagePath.Length > 0)
                {
                    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                    builder.SetTitle("Confirm");
                    builder.SetMessage("If you perform new scans existing scans will be overwritten");

                    builder.SetPositiveButton("Ok", (senderAlert, args) => {
                        callDocumentScanViewUIActivity();
                    });

                    Android.App.AlertDialog alert = builder.Create();
                    alert.Show();
                }
                else
                {
                    callDocumentScanViewUIActivity();
                }
            };
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

        public override void OnBackPressed()
        {
            Finish();
        }

        private void displayScannedPages(IList<IO.Anyline.View.ScanPage> scanPages)
        {
            FullImagePath = new string[scanPages.Count];
            CroppedImagePath = new string[scanPages.Count];
            Corners = new List<PointF>[scanPages.Count];
            for (int i = 0; i < scanPages.Count; i++)
            {
                FullImagePath[i] = scanPages[i].FullImagePath;
                CroppedImagePath[i] = scanPages[i].CroppedImagePath;
                Corners[i] = new List<PointF>();
                foreach (var transformationPoint in scanPages[i].TransformationPoints)
                {
                    Corners[i].Add(transformationPoint);
                }
            }

            // create new adapter to display full image, corners and cropped image:
            imageListView.Adapter = new ImageListViewArrayAdapter(this, FullImagePath, CroppedImagePath);
        }


        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == REQUEST_CODE_SCAN && resultCode == Result.Ok)
            {
                displayScannedPages(DocumentScanViewUIActivity.ScanPages);
            }
            else if (requestCode == CROP_DOCUMENT_REQUEST)
            {
                if (resultCode == Result.Ok)
                {
                    Bundle extras = data.Extras;
                    if (extras != null)
                    {
                        Corners[selectedPosition] = new List<PointF>();
                        foreach (var corner in CornersForCropUI)
                        {
                            Corners[selectedPosition].Add(corner);
                        }
                        CroppedImagePath[selectedPosition] = extras.GetString(RESULT_CROPPED_IMAGE_PATH);

                        // redraw list view as corners and cropped image have changed:
                        imageListView.InvalidateViews();
                    }
                }
            }
        }

        internal class ImageListViewArrayAdapter : Java.Lang.Object, IListAdapter, ImageView.IOnClickListener
        {
            private DocScanUIMainActivity docScanUIMainActivity;
            private int layout;
            string[] fullImagePath;
            string[] croppedImagePath;

            private string getPictureResolution(Context context, string imagePath)
            {
                BitmapFactory.Options bitMapOption = new BitmapFactory.Options();
                bitMapOption.InJustDecodeBounds = true;
                BitmapFactory.DecodeFile(imagePath, bitMapOption);
                return (NumberFormat.GetInstance(context.Resources.Configuration.Locale).Format(bitMapOption.OutWidth) + " x " +
                        NumberFormat.GetInstance(context.Resources.Configuration.Locale).Format(bitMapOption.OutHeight));
            }

            public ImageListViewArrayAdapter(DocScanUIMainActivity docScanUIMainActivity, string[] fullImagePath, string[] croppedImagePath)
            {
                this.docScanUIMainActivity = docScanUIMainActivity;
                this.fullImagePath = fullImagePath;
                this.croppedImagePath = croppedImagePath;
                layout = Resource.Layout.activity_doc_scan_ui_main_list_item;
            }

            private class ViewHolder : Java.Lang.Object
            {
                public ImageView ivFullImage;
                public ImageView ivCroppedImage;
                public TextView tvSizeFullImage;
                public TextView tvSizeCroppedImage;
            }

            public int Count => fullImagePath.Length;

            public bool HasStableIds => false;

            public bool IsEmpty => fullImagePath.Length == 0;

            public int ViewTypeCount => 1;

            public bool AreAllItemsEnabled()
            {
                return true;
            }

            public Java.Lang.Object GetItem(int position)
            {
                return fullImagePath[position];
            }

            public long GetItemId(int position)
            {
                return 1;
            }

            public int GetItemViewType(int position)
            {
                return 1;
            }

            public View GetView(int position, View convertView, ViewGroup parent)
            {
                ViewHolder viewHolder;
                if (convertView == null)
                {
                    LayoutInflater inflater = LayoutInflater.From(parent.Context);
                    convertView = inflater.Inflate(layout, parent, false);
                    viewHolder = new ViewHolder();

                    viewHolder.ivFullImage = (ImageView)convertView.FindViewById(Resource.Id.ivFullImage);
                    viewHolder.ivCroppedImage = (ImageView)convertView.FindViewById(Resource.Id.ivCroppedImage);
                    viewHolder.tvSizeFullImage = convertView.FindViewById<TextView>(Resource.Id.tvSizeFullImage);
                    viewHolder.tvSizeCroppedImage = convertView.FindViewById<TextView>(Resource.Id.tvSizeCroppedImage);

                    convertView.Tag = viewHolder;
                }
                else
                {
                    viewHolder = (ViewHolder)convertView.Tag;
                }

                // the tag will be used to retrieve the actual position in the list when clicking on an image:
                viewHolder.ivFullImage.Tag = position;
                viewHolder.ivCroppedImage.Tag = position;

                //values[position] = "";
                fullImgFile = null;
                if (fullImagePath[position] != null)
                { // values[position] contains the path of the full image
                    fullImgFile = new File(fullImagePath[position]);
                    if (fullImgFile.Exists())
                    {
                        // create bitmap in ARGB-format from full image file:
                        Bitmap fullBitmap = BitmapFactory.DecodeFile(fullImgFile.AbsolutePath);
                        Bitmap drawableFullBitmap = fullBitmap.Copy(Bitmap.Config.Argb8888, true);

                        // draw small red circles on the fullBitmap, indicating the corners:
                        if (Corners[position] != null)
                        {
                            Canvas canvas = new Canvas(drawableFullBitmap);
                            Paint paint = new Paint();
                            paint.Color = Color.Red;
                            paint.StrokeWidth = 4;
                            canvas.DrawBitmap(drawableFullBitmap, new Matrix(), null);
                            canvas.DrawCircle(Corners[position][0].X, Corners[position][0].Y, 12, paint);
                            canvas.DrawCircle(Corners[position][1].X, Corners[position][1].Y, 12, paint);
                            canvas.DrawCircle(Corners[position][2].X, Corners[position][2].Y, 12, paint);
                            canvas.DrawCircle(Corners[position][3].X, Corners[position][3].Y, 12, paint);
                        }

                        // display the full image with the 4 corners:
                        viewHolder.ivFullImage.SetImageBitmap(drawableFullBitmap);

                        // display the size (height and width) of the full image:
                        viewHolder.tvSizeFullImage.SetText(getPictureResolution(parent.Context, fullImagePath[position]), TextView.BufferType.Normal);

                        // if user clicks on full image: call cropView where the user can adjust corners:
                        viewHolder.ivFullImage.SetOnClickListener(this);
                    }
                }

                if (croppedImagePath[position] != null)
                {
                    File croppedImgFile = new File(croppedImagePath[position]);
                    if (croppedImgFile.Exists())
                    {
                        // create bitmap in ARGB-format from cropped image file:
                        Bitmap croppedBitmap = BitmapFactory.DecodeFile(croppedImgFile.AbsolutePath);
                        Bitmap drawableCroppedBitmap = croppedBitmap.Copy(Bitmap.Config.Argb8888, true);

                        // display the cropped image:
                        viewHolder.ivCroppedImage.SetImageBitmap(drawableCroppedBitmap);

                        // display the size (height and width) of the cropped image:
                        viewHolder.tvSizeCroppedImage.SetText(getPictureResolution(parent.Context, croppedImagePath[position]), TextView.BufferType.Normal);

                        // if a full image exists and user clicks on cropped image: call cropView where the user can adjust corners:
                        if (fullImgFile != null)
                        {
                            if (fullImgFile.Exists())
                            {
                                viewHolder.ivCroppedImage.SetOnClickListener(this);
                            }
                        }
                    }
                }
                return convertView;
            }

            public bool IsEnabled(int position)
            {
                return true;
            }

            public void RegisterDataSetObserver(DataSetObserver observer)
            {
            }

            public void UnregisterDataSetObserver(DataSetObserver observer)
            {
            }

            public void OnClick(View v)
            {
                selectedPosition = (int)v.Tag;
                callCropViewUIActivity(selectedPosition, new File(fullImagePath[selectedPosition]));
            }
        }
    }
}