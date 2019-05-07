using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IO.Anyline.Plugin.ID
{
    // Metadata.xml XPath class reference: path="/api/package[@name='io.anyline.plugin.id']/class[@name='MrzIdentification']"
    //[global::Android.Runtime.Register("io/anyline/plugin/id/MrzIdentification", DoNotGenerateAcw = true)]
    public partial class MrzIdentification : global::IO.Anyline.Plugin.ID.ID
    {
        public bool AllCheckDigitsValid
        {
            get
            {
                try
                {
                    return AreAllCheckDigitsValid();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Unable to get all check digits valid: " + e.Message);
                    return false;
                }
            }
        }
    }
}