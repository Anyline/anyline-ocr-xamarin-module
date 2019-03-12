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
    public sealed class ScanResultDelegate : NSObject, 
        IALIDPluginDelegate, IALOCRScanPluginDelegate, IALMeterScanPluginDelegate,
        IALDocumentScanPluginDelegate
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
            HandleResult(transformedImage);
        }
    }
}