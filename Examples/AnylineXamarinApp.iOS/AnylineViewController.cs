using AnylineXamarinSDK.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using AnylineXamarinApp.iOS.Modules.Barcode.ViewController;
using AnylineXamarinApp.iOS.Modules.Document.ViewController;
using AnylineXamarinApp.iOS.Modules.Energy.ViewController;
using AnylineXamarinApp.iOS.Modules.Mrz.ViewController;
using AnylineXamarinApp.iOS.Modules.OCR.ViewController;
using UIKit;
using System.Threading.Tasks;
using System.Reflection;
using AnylineXamarinApp.iOS.Modules.LicensePlate.ViewController;
using AnylineXamarinApp.iOS.Modules.DrivingLicense.ViewController;

namespace AnylineXamarinApp.iOS
{
	public partial class AnylineViewController : UITableViewController
	{

        public const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        public UIViewController CurrentScanViewController { get; set; }

        public Dictionary<string, string[]> TableItems = new Dictionary<string, string[]>
        {
            { "Meter Reading", new[] {
                    "Analog Meter",
                    "Digital Meter",
                    "Heat Meter",
                    "Analog/Digital",
                    "Serial Number",
                    "Dial Meter",
                    "Dot Matrix Meter",
                }},
            { "Identification", new[] {
                    "Passport / MRZ"
                }},
            { "Barcodes", new[] {
                    "Barcode / QR-Code"
                }},
            { "Serial Numbers", new[] {
                    "Universal Serial Number"
                }},
            { "Fintech", new[] {
                    "IBAN"
                }},
            { "Document", new[] {
                    "Document"
                }},
            { "Loyalty", new[] {
                    "Voucher Code",
                    "Bottlecap"
                }},
            { "Vehicle", new[] {
                    "EU License Plate",
                    "AT Driving License"
                }}
        };
        
        public AnylineViewController (IntPtr handle) : base (handle){ }
		
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
            TableView.Source = new TableSource(TableItems, this);
        }

        //lock orientation to portrait
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations ()
        {
            return UIInterfaceOrientationMask.Portrait;
        }

        //stop rotating away from portrait
        public override bool ShouldAutorotate()
        {
            return false;
        }
	};

    public class TableSource : UITableViewSource
    {
        protected Dictionary<string, string[]> TableItems;

        protected AnylineViewController AnylineViewController;

        protected string CellIdentifier = "TableCell";

        private readonly object _lock = new object();
        private bool _isNavigating = false;

        public TableSource(Dictionary<string, string[]> tableItems, AnylineViewController parent)
        {
            TableItems = tableItems;
            AnylineViewController = parent;            
        }
        
        public override string TitleForHeader(UITableView tableView, nint section)
        {
            try
            {
                if (section == NumberOfSections(tableView) - 1)
                {
                    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    var assembly = assemblies.Where(x => x.FullName.StartsWith("AnylineXamarinSDK")).FirstOrDefault();
                    if (assembly != null)
                    {
                        return $"SDK: {assembly.GetName().Version}";                        
                    }
                    return "";
                }
                return TableItems.Keys.ToList().ElementAt((int)section);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {            
            try
            {
                return TableItems.ToList().ElementAt((int)section).Value.Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return (nint)TableItems.Keys.Count + 1;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);

            cell.TextLabel.Text = TableItems.ToList().ElementAt(indexPath.Section).Value.ToList().ElementAt(indexPath.Row);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

            return cell;
        }

        /*
         * Navigate to the selected use case and initialize the appropriate viewcontroller with the appropriate settings
         */
        public override async void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Because this method might be triggered asynchronously multiple times, we have to make sure
            // that we won't create multiple ViewControllers at the same time.
            if (_isNavigating) return;
            lock (_lock) _isNavigating = true;
            
            if (AnylineViewController.CurrentScanViewController != null)
            {
                AnylineViewController.CurrentScanViewController.Dispose();
                AnylineViewController.CurrentScanViewController = null;
            }

            var name = TableItems.ElementAt(indexPath.Section).Value.ElementAt(indexPath.Row);            
            switch (indexPath.Section)
            {
                case 0: //ENERGY
                    var scanModeItems = new Dictionary<string,ALScanMode>();
                    string labelText = "";
                    int defaultIndex = 0;

                    switch (indexPath.Row)
                    {                        
                        case 0: //Analog Water Meter Scan                            
                            scanModeItems.Add("", ALScanMode.AnalogMeter);
                            break;
                        case 1: //Digital Meter Scan
                            scanModeItems.Add("", ALScanMode.DigitalMeter);
                            break;
                        case 2: //Heat Meter Scan
                            scanModeItems.Add("4 digits", ALScanMode.HeatMeter4);
                            scanModeItems.Add("5 digits", ALScanMode.HeatMeter5);
                            scanModeItems.Add("6 digits", ALScanMode.HeatMeter6);
                            break;
                        case 3: //Automatic Analog/Digital Meter Scan
                            scanModeItems.Add("", ALScanMode.AutoAnalogDigitalMeter);
                            break;
                        case 4: //Automatic Serial Number Scan
                            scanModeItems.Add("", ALScanMode.SerialNumber);
                            break;
                        case 5: //Dial Meter Scan
                            scanModeItems.Add("", ALScanMode.DialMeter);
                            break;
                        case 6: //Dot Matrix Meter Scan
                            scanModeItems.Add("", ALScanMode.DotMatrixMeter);
                            break;
                    }
                    AnylineViewController.CurrentScanViewController = new AnylineEnergyScanViewController(name, scanModeItems, labelText, defaultIndex);
                    break;

                case 1: //Identification
                    //Passport / ID MRZ Scan
                    AnylineViewController.CurrentScanViewController = new AnylineMrzScanViewController(name);
                    break;

                case 2: //Barcodes
                    //Barcode Scan
                    AnylineViewController.CurrentScanViewController = new AnylineBarcodeScanViewController(name);
                    break;

                case 3: //Serial Numbers
                    //Universal Serial Number
                    AnylineViewController.CurrentScanViewController = new AnylineSerialNumberScanViewController(name);
                    break;

                case 4: //Fintech
                    //Iban Scan
                    AnylineViewController.CurrentScanViewController = new AnylineIBANScanViewController(name);
                    break;

                case 5: //Document
                    //Document Scan
                    AnylineViewController.CurrentScanViewController = new AnylineDocumentScanViewController(name);
                    break;

                case 6: //Loyalty
                    if (indexPath.Row == 0) //Voucher Code Scan
                        AnylineViewController.CurrentScanViewController = new AnylineVoucherScanViewController(name);
                    if (indexPath.Row == 1) //Bottlecap Code Scan
                        AnylineViewController.CurrentScanViewController = new AnylineBottlecapScanViewController(name);
                    break;
                case 7: //Vehicle
                    if (indexPath.Row == 0) //License Plate Scan
                        AnylineViewController.CurrentScanViewController = new AnylineLicensePlateScanViewController(name);
                    if (indexPath.Row == 1) //Driving License Scan
                        AnylineViewController.CurrentScanViewController = new AnylineDrivingLicenseScanViewController(name);
                    if (indexPath.Row == 2) //VIN Scan
                        AnylineViewController.CurrentScanViewController = new AnylineVinScanViewController(name);
                    break;
                default:
                    break;
            }

            // navigate to the newly created scan view controller
            if (AnylineViewController.CurrentScanViewController != null)            
                AnylineViewController.NavigationController.PushViewController(AnylineViewController.CurrentScanViewController, true);

            // workaround so the row selection is not creating a scanViewController twice
            await Task.Delay(200);

            tableView.DeselectRow(indexPath, true);
            lock (_lock) _isNavigating = false;
        }

    };
}
