﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AnylineXamarinSDK.iOS;
using Foundation;
using UIKit;

namespace Anyline.iOS
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
            int groupIndex = 0;
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
                bool compositeScanResult = false;
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
                        case "AccessibilityAttributedUserInputLabels":
                        case "AccessibilityRespondsToUserInteraction":
                        case "AccessibilityTextualContext":
                        case "AccessibilityUserInputLabels":
                        case "ToJSONString":
                            break;
                        default:
                            try
                            {

                                var value = prop.GetValue(obj, null);

                                if (value != null)
                                {
                                    if (value is Foundation.NSDictionary results)
                                    {
                                        compositeScanResult = true;
                                        var mapGroupResults = new Dictionary<string, object>();
                                        foreach (KeyValuePair<Foundation.NSObject, Foundation.NSObject> result in results)
                                        {
                                            var sublist = result.Value.CreatePropertyDictionary();
                                            mapGroupResults.Add(result.Key.ToString(), sublist);
                                        }
                                        dict.Add($"Result group {groupIndex}", mapGroupResults);

                                        groupIndex++;
                                    }
                                    else if (value is Foundation.NSArray resultArray)
                                    {
                                        for (nuint i = 0; i < resultArray.Count; i++)
                                        {
                                            resultArray.GetItem<Foundation.NSObject>(i).CreatePropertyDictionary().ToList().ForEach(x => dict.AddProperty(x.Key, x.Value));
                                        }
                                    }
                                    else
                                    {
                                        dict.AddProperty(prop.Name, value);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Debug.WriteLine(e.Message);
                            }
                            break;
                    }
                }
                // if this is a composite scan result, ignore the global Confidence value
                if (compositeScanResult) dict.Remove("Confidence");
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
            if (value != null)
            {
                if (value is ALMRZIdentification
                    || value is ALDrivingLicenseIdentification
                    || value is ALGermanIDFrontIdentification
                    || value is ALLayoutDefinition)
                {
                    value.CreatePropertyDictionary().ToList().ForEach(x => dict.AddProperty(x.Key, x.Value));
                }
                else if (value is ALUniversalIDIdentification universalIDIdentification)
                {
                    foreach (var field in universalIDIdentification.FieldNames)
                    {
                        dict.AddProperty(field, universalIDIdentification.ValueForField(field));
                    }

                    dict.AddProperty("LayoutDefinition", universalIDIdentification.LayoutDefinition);
                }
                else if (value is ALIDFieldConfidences)
                {
                    value.CreatePropertyDictionary().ToList().ForEach(x => dict.Add($"{x.Key} (field confidence)", x.Value));
                }
                else if (value is UIImage && value != null)
                {
                    dict.Add(name, (value as UIImage).AsJPEG().ToArray());
                }
                else if(value is byte[])
                {
                    dict.Add(name, value);
                }
                else if (value is ALDataGroup1 || value is ALDataGroup2)
                {
                    value.CreatePropertyDictionary().ToList().ForEach(x => dict.Add(x.Key, x.Value));
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