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
    /// <summary>
    /// This is the delegate class that implements all result callbacks for various scan plugins
    /// </summary>
    public sealed class ScanResultDelegate : NSObject, 
        IALIDPluginDelegate, IALOCRScanPluginDelegate, IALMeterScanPluginDelegate,
        IALDocumentScanPluginDelegate, IALLicensePlateScanPluginDelegate,
        IALBarcodeScanPluginDelegate
    {
        private readonly ScanViewController _scanViewController;

        public ScanResultDelegate(ScanViewController scanViewController)
        {
            _scanViewController = scanViewController;
        }

        void HandleResult(object result)
        {
            var resultViewController = new ResultViewController(result);
            _scanViewController.NavigationController?.PushViewController(resultViewController, true);
        }
        
        public void DidFindResult(ALIDScanPlugin anylineIDScanPlugin, ALIDResult scanResult)
        {
            HandleResult(scanResult);
        }

        public void DidFindResult(ALOCRScanPlugin anylineOCRScanPlugin, ALOCRResult result)
        {
            HandleResult(result);
        }

        public void DidFindResult(ALMeterScanPlugin anylineMeterScanPlugin, ALMeterResult scanResult)
        {
            HandleResult(scanResult);
        }

        public void HasResult(ALDocumentScanPlugin anylineDocumentScanPlugin, UIImage transformedImage, UIImage fullFrame, ALSquare corners)
        {
            Dictionary<string, object> results = new Dictionary<string, object>();
            results.Add("transformedImage", transformedImage);
            results.Add("fullFrame", fullFrame);
            results.Add("corners", corners);
            
            HandleResult(results);
        }

        public void DidFindResult(ALLicensePlateScanPlugin anylineLicensePlateScanPlugin, ALLicensePlateResult scanResult)
        {
            HandleResult(scanResult);
        }

        public void DidFindResult(ALBarcodeScanPlugin anylineBarcodeScanPlugin, ALBarcodeResult scanResult)
        {
            HandleResult(scanResult);
        }
    }
}