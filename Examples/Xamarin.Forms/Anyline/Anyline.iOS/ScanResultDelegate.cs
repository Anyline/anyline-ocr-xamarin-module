using AnylineXamarinSDK.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Anyline.iOS
{
    /// <summary>
    /// This is the delegate class that implements the ResulReceived callback for the ScanPlugin
    /// </summary>
    public sealed class ScanResultDelegate : ALScanPluginDelegate
    {
        private Action<object> resultsAction;

        public ScanResultDelegate(Action<object> resultsAction)
        {
            this.resultsAction = resultsAction;
        }

        public override void ResultReceived(ALScanPlugin scanPlugin, ALScanResult scanResult)
        {
            resultsAction?.Invoke(scanResult.CreatePropertyDictionary());
        }
    }
}