using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace Anyline.Droid
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
            Dictionary<string, object> dict = new Dictionary<string, object>();

            var props = obj.GetType().GetProperties();
            foreach (var prop in props)
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

                            if (value == null) { continue; }

                            if (value.GetType().Namespace.StartsWith("IO.Anyline"))
                            {
                                dict.Add($"{prop.Name} ({prop.PropertyType})", value.CreatePropertyDictionary());
                            }
                            else
                            {
                                dict.AddProperty($"{prop.Name} ({prop.PropertyType})", value);
                            }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }
                        break;
                }
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
                if (value is IO.Anyline2.Image.AnylineImage)
                {
                    var bitmap = (value as IO.Anyline2.Image.AnylineImage).Bitmap;

                    MemoryStream stream = new MemoryStream();
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    byte[] bitmapData = stream.ToArray();

                    dict.Add(name, bitmapData);
                }
                else if (value is Android.Graphics.Bitmap bitmap)
                {
                    MemoryStream stream = new MemoryStream();
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                    byte[] bitmapData = stream.ToArray();

                    dict.Add(name, bitmapData);
                }
                else if (value is byte[])
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