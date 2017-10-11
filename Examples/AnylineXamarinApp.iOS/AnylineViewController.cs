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

namespace AnylineXamarinApp.iOS
{
	public partial class AnylineViewController : UITableViewController
	{

        public const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJBVC5BbnlsaW5lLlhhbWFyaW4uQXBwLkRyb2lkIiwgIkFULkFueWxpbmUuWGFtYXJpbi5Gb3Jtcy5BcHAuRHJvaWQiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpb3NJZGVudGlmaWVyIjogWyAiQVQuQW55bGluZS5YYW1hcmluLkFwcC5pT1MiLCAiQVQuQW55bGluZS5YYW1hcmluLkZvcm1zLkFwcC5pT1MiIF0sICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsICJtYWpvclZlcnNpb24iOiAiMyIsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMC0wMS0wMSIgfQprcS9WL0wrSGlpN0NzL2tXa1E5VWRzbGxzd0hOanphelZEZ2Z2WU1LLytJN1VHYmlITy9SblMrdGZIeUZxQmlJCkN3QXkrdkk5RnJpOVc5MStGdjJTS2FJNS8vLzZhUVgyVXlSVC9CaVRKM1QzTXBVOEIrMWpFZTQxbCtXejRqaFgKMlZ6dENpT2E3cit3d2RlTm1GUFpxdGVUTG5BRmgxQWgycDZpMzgyMWhOb3FsVHNxcFlJdjN3cWdCbWg5clh2WgpBM01pRnpkZ0dab1gzbzNINzFGRUtJME9JSy9ZRkNJRk5nVEI0MFhBM3ZTOXk2ak1FR2E5bjVQRHY5MU5NZEFRCnlHTzcxRVVuZE9ndmJmTkJWbVJYNUR1MGVrZ0RGYUNFMUwweVpUQ3dhMFJVTStLSE9PcXA3TThYOWVFdjJ0RVkKVEcyejdydGQ5YytiRlBvTU5vcUpwZz09Cg==";

        public Dictionary<string, string[]> TableItems = new Dictionary<string, string[]>
        {
            { "Energy", new[] {
                    "Analog Meter Scan",
                    "Digital Meter Scan",
                    "Heat Meter Scan",
                    "Analog/Digital Scan"
                }},
            { "Identification", new[] {
                    "Passport / ID MRZ Scan"
                }},
            { "Barcodes", new[] {
                    "Barcode Scan"
                }},
            { "Fintech", new[] {
                    "IBAN Scan"
                }},
            { "Document", new[] {
                    "Document Scan"
                }},
            { "Loyalty", new[] {
                    "Voucher Code Scan",
                    "Bottlecap Code Scan"                    
                }},
            { "Vehicle", new[] {
                    "License Plate Scan"
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

        protected AnylineViewController Parent;

        protected string CellIdentifier = "TableCell";

        private readonly object _lock = new object();
        private bool _isNavigating = false;

        public TableSource(Dictionary<string, string[]> tableItems, AnylineViewController parent)
        {
            TableItems = tableItems;
            Parent = parent;
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
                    }

                    Parent.NavigationController.PushViewController(new AnylineEnergyScanViewController(name, scanModeItems, labelText, defaultIndex), true);
                    break;

                case 1: //Identification
                    //Passport / ID MRZ Scan
                    Parent.NavigationController.PushViewController(new AnylineMrzScanViewController(name), true);
                    break;

                case 2: //Barcodes
                    //Barcode Scan
                    Parent.NavigationController.PushViewController(new AnylineBarcodeScanViewController(name), true);
                    break;

                case 3: //Fintech
                    //Iban Scan
                    Parent.NavigationController.PushViewController(new AnylineIBANScanViewController(name), true);
                    break;

                case 4: //Document
                    //Document Scan
                    Parent.NavigationController.PushViewController(new AnylineDocumentScanViewController(name), true);
                    break;

                case 5: //Loyalty
                    if (indexPath.Row == 0) //Voucher Code Scan
                        Parent.NavigationController.PushViewController(new AnylineVoucherScanViewController(name), true);
                    if (indexPath.Row == 1) //Bottlecap Code Scan
                        Parent.NavigationController.PushViewController(new AnylineBottlecapScanViewController(name), true);                    
                    break;
                case 6: //License Plate
                    Parent.NavigationController.PushViewController(new AnylineLicensePlateScanViewController(name), true);                    
                    break;
            }

            // workaround so the row selection is not creating a scanViewController twice
            await Task.Delay(200);

            tableView.DeselectRow(indexPath, true);
            lock (_lock) _isNavigating = false;
        }

    };
}
