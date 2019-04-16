using System.Collections.Generic;
using Foundation;
using UIKit;
using AnylineXamarinSDK.iOS;
using System.Threading.Tasks;

namespace AnylineExamples.iOS
{
    /// <summary>
    /// This is the delegate class that implements all result callbacks for various ScanPlugins
    /// </summary>
    public sealed class ScanResultDelegate : NSObject, 
        IALIDPluginDelegate, 
        IALOCRScanPluginDelegate, 
        IALMeterScanPluginDelegate,
        IALDocumentScanPluginDelegate, 
        IALLicensePlateScanPluginDelegate,
        IALBarcodeScanPluginDelegate
    {
        // we store the ScanViewController for navigation purposes
        private readonly ScanViewController _scanViewController;

        public ScanResultDelegate(ScanViewController scanViewController)
        {
            _scanViewController = scanViewController;
        }

        // we call this method in every case a result is received and deal with processing that result in the ResultViewController
        void HandleResult(object result)
        {
            var resultViewController = new ResultViewController(result);
            _scanViewController.NavigationController?.PushViewController(resultViewController, false);
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
            // the DocumentScanPlugin is slightly different to the other plugins, it doesn't return a document result, but instead several parameters.
            // we put together these parameters and pass them to the ResultViewController

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