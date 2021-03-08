using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Anyline;
using Anyline.Droid;
using IO.Anyline.Models;
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

                    scanView.Init(configurationFile);

                    scanView.ScanViewPlugin.AddScanResultListener(this);

                    scanView.CameraOpened += ScanView_CameraOpened;
                }

            }
            catch (Exception)
            {
                // show error
            }
        }

        private void ScanView_CameraOpened(object sender, IO.Anyline.Camera.CameraOpenedEventArgs e)
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
                    case "Coordinates":
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
                                if (value is JavaList)
                                {
                                    var i = 0;
                                    var resultList = (value as JavaList);
                                    foreach (Java.Lang.Object v in resultList)
                                    {
                                        var sublist = CreatePropertyList(v);
                                        sublist.ToList().ForEach(x => dict.Add(x.Key + $" ({i})", x.Value));
                                        i++;
                                    }
                                }
                                else if (value is Java.Util.AbstractList resultList)
                                {
                                    var i = 0;
                                    var iterator = resultList.Iterator();
                                    while (iterator.HasNext)
                                    {
                                        var v = iterator.Next();
                                        var sublist = CreatePropertyList(v);
                                        sublist.ToList().ForEach(x => dict.Add(x.Key + $" ({i})", x.Value));
                                        i++;
                                    }
                                }
                                else if (value is AnylineImage)
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