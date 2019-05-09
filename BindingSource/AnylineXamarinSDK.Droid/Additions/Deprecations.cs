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

// all api's

namespace AT.Nineyards.Anyline.Modules.Barcode
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class BarcodeResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeBarcodeScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
}

namespace AT.Nineyards.Anyline.Modules.Document
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class DocumentResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeDocumentScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
}

namespace AT.Nineyards.Anyline.Modules.Energy
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class EnergyResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeEnergyScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
}

namespace AT.Nineyards.Anyline.Modules.LicensePlate
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class LicensePlateResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeLicensePlateScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
}


namespace AT.Nineyards.Anyline.Modules.Mrz
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class MrzResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeMrzScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
    //[Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    //public partial class Identification : global::IO.Anyline.Plugin.ID.MrzIdentification { }
}

namespace AT.Nineyards.Anyline.Modules.Ocr
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class AnylineOcrResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class AnylineOcrConfig : global::Java.Lang.Object { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class NativeAnylineOcrScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
}


namespace AT.Nineyards.Anyline.Camera
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class AnylineViewConfig : global::Java.Lang.Object { }
}

// official anyline.xamarin api's

namespace AT.Nineyards.Anylinexamarin.Support.Modules.Barcode
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class BarcodeScanView : global::AT.Nineyards.Anyline.Modules.Barcode.NativeBarcodeScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface IBarcodeResultListener : IJavaObject { }
}

namespace AT.Nineyards.Anylinexamarin.Support.Modules.Document
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class DocumentScanView : global::AT.Nineyards.Anyline.Modules.Document.NativeDocumentScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface IDocumentResultListener : IJavaObject { }
}

namespace AT.Nineyards.Anylinexamarin.Support.Modules.Energy
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class EnergyScanView : global::AT.Nineyards.Anyline.Modules.Energy.NativeEnergyScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface IEnergyResultListener : IJavaObject { }
}

namespace AT.Nineyards.Anylinexamarin.Support.Modules.LicensePlate
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class LicensePlateScanView : global::AT.Nineyards.Anyline.Modules.LicensePlate.NativeLicensePlateScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface ILicensePlateResultListener : IJavaObject { }
}

namespace AT.Nineyards.Anylinexamarin.Support.Modules.Mrz
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class MrzScanView : global::AT.Nineyards.Anyline.Modules.Mrz.NativeMrzScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface IMrzResultListener : IJavaObject { }
}
namespace AT.Nineyards.Anylinexamarin.Support.Modules.Ocr
{
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial class AnylineOcrScanView : global::AT.Nineyards.Anyline.Modules.Ocr.NativeAnylineOcrScanView { }
    [Obsolete("As of Anyline 10.1, this class is deprecated and will be removed by November 2019.")]
    public partial interface IAnylineOcrResultListener : IJavaObject { }
}
