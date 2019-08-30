using Android.App;
using Android.Content;
using Android.Graphics;
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

[assembly: ExportRenderer(typeof(ScanPage), typeof(ScanPageRenderer))]

namespace Anyline.Droid
{
    public class ScanPageRenderer : PageRenderer, IScanResultListener
    {

        private Android.Views.View view;
        private ScanView scanView;

        private readonly string licenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

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

            string configurationFile = (Element as ScanPage).ConfigurationFile.Replace(".json", "") + ".json";

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
            catch (Exception e)
            {
                // show error
            }
        }

        private void ScanView_CameraOpened(object sender, AT.Nineyards.Anyline.Camera.CameraOpenedEventArgs e)
        {
            scanView.ScanViewPlugin.Start();
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
            (Element as ScanPage).ShowResultsAction?.Invoke(processedResults);
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