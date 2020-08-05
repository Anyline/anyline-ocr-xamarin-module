using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Anyline;
using Anyline.Droid;
using AT.Nineyards.Anyline.Models;
using IO.Anyline.Plugin;
using IO.Anyline.Plugin.ID;
using IO.Anyline.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScanExamplePage), typeof(ScanPageRenderer))]

namespace Anyline.Droid
{
    public class ScanPageRenderer : PageRenderer, IScanResultListener
    {

        private Android.Views.View view;
        private ScanView scanView;

        private readonly string licenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpbWFnZVJlcG9ydENhY2hpbmciOiB0cnVlLCAiaW9zSWRlbnRpZmllciI6IFsgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLCAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIgXSwgImxpY2Vuc2VLZXlWZXJzaW9uIjogMiwgIm1ham9yVmVyc2lvbiI6ICI0IiwgIm1heERheXNOb3RSZXBvcnRlZCI6IDAsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMS0wMS0wMSIgfQpWQVZoT3FSZGl3cXl3VHpndk5sRjk5a24yQWxSTTE4bEVoQ2JWMlRWc25MUG9zQ1NIM0dtMytmZk1Db1drckt3CnZOZ0o1ZllCRGRSVHpLTmNvV3l0Rys5VjlXdU9kd1Y5elFYRTduWWdyL3cxWko1ald4dVZyK1h2QStLVW16MU8KWjFablhwQzZudU9YNTZIbDZPNkF2bWVqZ3VIekRYbHorUTU5OW8vMjVkMFNlN1NzVHBNRHlBWjVCMDRxdERSNApnMlh0STZCUXBuQ0hEQ20yQ253OGlJb2R5N0ZRb0hrQWdVSE0rMzg2aUpZbzRPbmxKNEdGSmRPQmJJdnRiL1VWCktFcktWdVZaWUxTVnBlU3dHMGNURDNESmhsWUdRdzU2cXdZUHo0WVFXWWVMVzNSeFdNN2FMWlZzRzMzbWhyaXQKQjBXUzVDOUQ3RHRFekFmLzBydld0dz09Cg==";

        public ScanPageRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> args)
        {
            base.OnElementChanged(args);

            if (args.OldElement != null || Element == null)
            {
                return;
            }

            string configurationFile = (Element as ScanExamplePage).ConfigurationFile.Replace(".json", "") + ".json";

            try
            {
                if (view == null)
                {

                    var activity = Context as Activity;
                    view = activity.LayoutInflater.Inflate(Resource.Layout.ScanLayout, this, false);

                    AddView(view);

                    scanView = view.FindViewById<ScanView>(Resource.Id.scan_view);

                    scanView.Init(configurationFile, licenseKey);

                    scanView.ScanViewPlugin.AddScanResultListener(this);

                    scanView.CameraOpened += ScanView_CameraOpened;
                }

            }
            catch (Exception)
            {
                // show error
            }
        }

        private void ScanView_CameraOpened(object sender, AT.Nineyards.Anyline.Camera.CameraOpenedEventArgs e)
        {
            if (scanView != null)
                scanView.Start();
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var w = r - l;
            var h = b - t;

            var msw = MeasureSpec.MakeMeasureSpec(w, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(h, MeasureSpecMode.Exactly);
            view.Measure(msw, msh);
            view.Layout(0, 0, w, h);
        }

        public void OnResult(Java.Lang.Object result)
        {
            var processedResults = CreatePropertyList((result as AnylineScanResult));
            (Element as ScanExamplePage).ShowResultsAction?.Invoke(processedResults);
        }

        protected override void Dispose(bool disposing)
        {
            DisposeResources();
            base.Dispose(disposing);
        }

        protected override void OnDetachedFromWindow()
        {
            scanView.Stop();
            scanView.CameraView.ReleaseCameraInBackground();
            base.OnDetachedFromWindow();
        }

        private void DisposeResources()
        {
            if (scanView != null)
            {
                scanView.Dispose();
                scanView = null;
            }
            view = null;
            RemoveAllViews();
            GC.Collect();
        }

        private Dictionary<string, object> CreatePropertyList(Java.Lang.Object obj)
        {
            var dict = new Dictionary<string, object>();
            foreach (var prop in obj.GetType().GetProperties())
            {
                switch (prop.Name)
                {
                    // filter out properties that we don't want to display
                    case "JniPeerMembers":
                    case "JniIdentityHashCode":
                    case "Handle":
                    case "PeerReference":
                    case "Outline":
                    case "Class":
                    case "FieldNames":
                        break;
                    default:

                        try
                        {
                            var value = prop.GetValue(obj, null);


                            // filter out deprecated fields
                            if (prop.GetCustomAttributes(typeof(ObsoleteAttribute), true).ToArray().Length > 0)
                                continue;

                            if (value != null)
                            {
                                // TODO: iterate through every result and display them
                                //if(value is JavaList)
                                //{
                                //    var i = 0;
                                //    var resultList = (value as JavaList);
                                //    foreach (Java.Lang.Object v in resultList)
                                //    {
                                //        var sublist = CreatePropertyList(v);
                                //        sublist.ToList().ForEach(x => dict.Add(x.Key + $" ({i})", x.Value));
                                //        i++;
                                //    }
                                //}
                                if (value is AnylineImage)
                                {
                                    var bitmap = (value as AnylineImage).Clone().Bitmap;

                                    MemoryStream stream = new MemoryStream();
                                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                                    byte[] bitmapData = stream.ToArray();

                                    dict.Add(prop.Name, bitmapData);
                                }
                                else if (value is ID)
                                {
                                    var sublist = CreatePropertyList(value as ID);
                                    sublist.ToList().ForEach(x => dict.Add(x.Key, x.Value));
                                }
                                else if (value is IDFieldConfidences)
                                {
                                    var sublist = CreatePropertyList(value as IDFieldConfidences);
                                    sublist.ToList().ForEach(x => dict.Add($"{x.Key} (field confidence)", x.Value));
                                }
                                else if (value is JavaDictionary<String, String> dictionaryValues)
                                {
                                    foreach (var v in dictionaryValues)
                                        dict.Add(v.Key, new Java.Lang.String(v.Value.ToString()).ReplaceAll("\\\\n", "\\\n"));
                                }
                                else
                                {
                                    var str = new Java.Lang.String(value.ToString()).ReplaceAll("\\\\n", "\\\n");
                                    dict.Add(prop.Name, str);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
                        }
                        break;
                }
            }

            // quick hack to re-order the list so that the result will be presented first:
            MoveElementToIndex(dict, "Result", 0);

            return dict;
        }

        public static void MoveElementToIndex<T>(Dictionary<string, T> dict, string identifier, int pos)
        {
            var result = new Dictionary<string, T>();

            if (dict.ContainsKey(identifier))
            {
                var list = dict.ToList();

                var currentIndex = list.FindIndex(x => x.Key == identifier);
                var currentElement = list.ElementAt(currentIndex);

                list.Remove(currentElement);
                list.Insert(pos, currentElement);

                dict.Clear();
                list.ForEach(x => dict.Add(x.Key, x.Value));
            }
        }
    }
}