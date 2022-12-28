using AnylineXamarinSDK.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace Anyline.iOS
{
    /// <summary>
    /// This is the delegate class that implements all result callbacks for various ScanPlugins
    /// </summary>
    public sealed class ScanResultDelegate : ALScanPluginDelegate
    //,
    //IALIDPluginDelegate,
    //IALOCRScanPluginDelegate,
    //IALMeterScanPluginDelegate,
    //IALDocumentScanPluginDelegate,
    //IALLicensePlateScanPluginDelegate,
    //IALBarcodeScanPluginDelegate,
    //IALCompositeScanPluginDelegate
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

        //public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        //{
        //    HandleResult(scanResult);
        //}

        //public void DidFindResult(ALOCRScanPlugin anylineOCRScanPlugin, ALOCRResult result)
        //{
        //    HandleResult(result);
        //}

        //public void DidFindResult(ALMeterScanPlugin anylineMeterScanPlugin, ALMeterResult scanResult)
        //{
        //    HandleResult(scanResult);
        //}

        //public void HasResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage transformedImage, UIImage fullFrame, ALSquare corners)
        //{
        //    // the DocumentScanPlugin is slightly different to the other plugins, it doesn't return a document result, but instead several parameters.
        //    // we put together these parameters and pass them to the ResultViewController

        //    Dictionary<string, object> results = new Dictionary<string, object>();
        //    results.Add("transformedImage", transformedImage);
        //    results.Add("fullFrame", fullFrame);
        //    results.Add("corners", corners);

        //    HandleResult(results);
        //}

        //public void DidFindResult(ALLicensePlateScanPlugin anylineLicensePlateScanPlugin, ALLicensePlateResult scanResult)
        //{
        //    HandleResult(scanResult);
        //}

        //public void DidFindResult(ALBarcodeScanPlugin anylineBarcodeScanPlugin, ALBarcodeResult scanResult)
        //{
        //    HandleResult(scanResult);
        //}

        //public void DidFindResult(ALAbstractScanViewPluginComposite anylineCompositeScanPlugin, ALCompositeResult scanResult)
        //{
        //    HandleResult(scanResult);
        //}

    }
}