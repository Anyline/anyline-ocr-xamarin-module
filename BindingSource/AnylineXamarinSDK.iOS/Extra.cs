using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UIKit;

namespace AnylineXamarinSDK.iOS
{
    public partial class ALScanView : UIView
    {
        public ALScanView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineAbstractModuleView : UIView
    {
        public AnylineAbstractModuleView(CGRect frame) : base(frame) { }        
    }

    public partial class AnylineEnergyModuleView : AnylineAbstractModuleView
    {
        public AnylineEnergyModuleView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineBarcodeModuleView : AnylineAbstractModuleView
    {
        public AnylineBarcodeModuleView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineMRZModuleView : AnylineAbstractModuleView
    {
        public AnylineMRZModuleView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineOCRModuleView : AnylineAbstractModuleView
    {
        public AnylineOCRModuleView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineDocumentModuleView : AnylineAbstractModuleView
    {
        public AnylineDocumentModuleView(CGRect frame) : base(frame) { }
    }

    public partial class AnylineLicensePlateModuleView : AnylineAbstractModuleView
    {
        public AnylineLicensePlateModuleView(CGRect frame) : base(frame) { }
    }
}