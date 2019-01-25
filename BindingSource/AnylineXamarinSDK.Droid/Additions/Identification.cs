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

namespace AT.Nineyards.Anyline.Modules.Mrz
{
    //[global::Android.Runtime.Register("at/nineyards/anyline/modules/mrz/Identification", DoNotGenerateAcw = true)]
    public partial class Identification : global::IO.Anyline.Plugin.ID.ID
    {
        public bool AllCheckDigitsValid
        {
            get
            {
                return AreAllCheckDigitsValid();
            }
        }
    }
}