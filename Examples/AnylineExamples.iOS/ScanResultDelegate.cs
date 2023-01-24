using AnylineXamarinSDK.iOS;

namespace AnylineExamples.iOS
{
    /// <summary>
    /// This is the delegate class that implements the ResulReceived callback for the ScanPlugin
    /// </summary>
    public sealed class ScanResultDelegate : ALScanPluginDelegate
    {
        // we store the ScanViewController for navigation purposes
        private readonly ScanViewController scanViewController;

        public ScanResultDelegate(ScanViewController scanViewController)
        {
            this.scanViewController = scanViewController;
        }

        public override void ResultReceived(ALScanPlugin scanPlugin, ALScanResult scanResult)
        {
            var resultViewController = new ResultTableViewController(scanResult);
            scanViewController.NavigationController?.PushViewController(resultViewController, false);
        }
    }
}