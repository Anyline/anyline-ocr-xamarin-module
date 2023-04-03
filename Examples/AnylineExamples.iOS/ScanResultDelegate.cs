using AnylineXamarinSDK.iOS;
using Foundation;

namespace AnylineExamples.iOS
{
    /// <summary>
    /// This is the delegate class that implements the ResulReceived callback for the ScanPlugin
    /// </summary>
    public sealed class ScanResultDelegate : ALScanPluginDelegate, IALViewPluginCompositeDelegate
    {
        // we store the ScanViewController for navigation purposes
        private readonly ScanViewController _scanViewController;
        private string _title;

        public ScanResultDelegate(ScanViewController scanViewController, string title)
        {
            _scanViewController = scanViewController;
            _title = title;
        }

        public override void ResultReceived(ALScanPlugin scanPlugin, ALScanResult scanResult)
        {
            var resultViewController = new ResultViewController(scanResult, _title);
            _scanViewController.NavigationController?.PushViewController(resultViewController, false);
        }


        [Export("viewPluginComposite:allResultsReceived:")]
        public void AllResultsReceived(ALViewPluginComposite viewPluginComposite, ALScanResult[] scanResults)
        {
            var resultViewController = new ResultViewController(scanResults, _title);
            _scanViewController.NavigationController?.PushViewController(resultViewController, false);
        }   
    }
}