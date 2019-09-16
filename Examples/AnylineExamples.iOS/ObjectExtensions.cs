using AnylineXamarinSDK.iOS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UIKit;

namespace AnylineExamples.iOS
{
    /// <summary>
    /// Extension class to parse results of any kind via reflection to a list
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Creates a property dictionary via reflection of the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> CreatePropertyDictionary(this object obj)
        {
            int serialScanningIndex = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>();

            if (obj is Dictionary<string, object>)
            {
                var objDict = obj as Dictionary<string, object>;

                foreach (var od in objDict)
                {
                    dict.Add(od.Key, od.Value);
                }
            }
            else
            {
                if (obj is UIImage) return new Dictionary<string, object>() { { "Image", obj } }.CreatePropertyDictionary();

                var props = obj.GetType().GetProperties();
                foreach (var prop in props)
                {
                    switch (prop.Name)
                    {
                        // filter out properties that we don't want to display
                        case "Handle":
                        case "PeerReference":
                        case "Outline":
                        case "Class":
                        case "Self":
                        case "ClassHandle":
                        case "Description":
                        case "DebugDescription":
                        case "IsProxy":
                        case "RetainCount":
                        case "Superclass":
                        case "Zone":
                        case "SuperHandle":
                            break;
                        default:

                            var value = prop.GetValue(obj, null);

                            if (value != null)
                            {
                                if (value is Foundation.NSDictionary results)
                                {
                                    var mapResultsSerialScanning = new Dictionary<string, object>();
                                    foreach (KeyValuePair<Foundation.NSObject, Foundation.NSObject> result in results)
                                    {
                                        var sublist = result.Value.CreatePropertyDictionary();
                                        mapResultsSerialScanning.Add(result.Key.ToString(), sublist);
                                    }
                                    dict.Add($"Serial Scanning {serialScanningIndex}", mapResultsSerialScanning);

                                    serialScanningIndex++;
                                }
                                else
                                {
                                    dict.AddProperty(prop.Name, value);
                                }
                            }
                            break;
                    }
                }
            }

            // we want to present "Result" always first, so:
            if (dict.ContainsKey("Result"))
            {
                var list = dict.ToList();

                var currentIndex = list.FindIndex(x => x.Key == "Result");
                var currentElement = list.ElementAt(currentIndex);

                list.Remove(currentElement);
                list.Insert(0, currentElement);

                dict = list.ToDictionary(x => x.Key, x => x.Value);
            }

            return dict;
        }

        /// <summary>
        /// Adds an object with a given name to the dictionary.
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AddProperty(this Dictionary<string, object> dict, string name, object value)
        {

            Debug.WriteLine("{0}: {1}", name, value);
            if (value != null)
            {
                if (value is ALMRZIdentification
                    || value is ALDrivingLicenseIdentification
                    || value is ALGermanIDFrontIdentification)
                {
                    value.CreatePropertyDictionary().ToList().ForEach(x => dict.Add(x.Key, x.Value));
                }
                else if (value is ALIDFieldConfidences)
                {
                    value.CreatePropertyDictionary().ToList().ForEach(x => dict.Add($"{x.Key} (field confidence)", x.Value));
                }
                else if (value is UIImage && value != null)
                {
                    dict.Add(name, value);
                }
                else if (value.ToString() != "")
                {
                    var str = value.ToString().Replace("\\n", Environment.NewLine);
                    dict.Add(name, str);
                }
            }
        }
    }
}