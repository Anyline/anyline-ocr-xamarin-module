using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnylineExamples.iOS;
using Foundation;
using UIKit;
using AnylineXamarinSDK.iOS;

namespace AnylineExamples.iOS
{
    public class ScanResultDelegate : ALAbstractScanViewPlugin // TODO
    {
        private readonly ScanViewController _scanViewController;

        public ScanResultDelegate(ScanViewController scanViewController)
        {
            _scanViewController = scanViewController;
        }
    }
}