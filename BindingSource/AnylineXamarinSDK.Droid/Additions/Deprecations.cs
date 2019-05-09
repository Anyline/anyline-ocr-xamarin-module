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

// hidden api's

namespace AT.Nineyards.Anyline.Modules.Barcode
{
    [Obsolete]
    public partial class BarcodeResult : global::AT.Nineyards.Anyline.Models.AnylineScanResult { }
    [Obsolete]
    public partial class NativeBarcodeScanView : global::AT.Nineyards.Anyline.Modules.AnylineBaseModuleView { }
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
