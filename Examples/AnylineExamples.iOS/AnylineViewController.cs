using AnylineExamples.Shared;
using AnylineXamarinAppiOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UIKit;

namespace AnylineExamples.iOS
{
    public partial class AnylineViewController : UITableViewController
    {

        public const string LicenseKey = "eyAiYW5kcm9pZElkZW50aWZpZXIiOiBbICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiIF0sICJkZWJ1Z1JlcG9ydGluZyI6ICJvbiIsICJpbWFnZVJlcG9ydENhY2hpbmciOiB0cnVlLCAiaW9zSWRlbnRpZmllciI6IFsgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLCAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIgXSwgImxpY2Vuc2VLZXlWZXJzaW9uIjogMiwgIm1ham9yVmVyc2lvbiI6ICI0IiwgIm1heERheXNOb3RSZXBvcnRlZCI6IDAsICJwaW5nUmVwb3J0aW5nIjogdHJ1ZSwgInBsYXRmb3JtIjogWyAiaU9TIiwgIkFuZHJvaWQiIF0sICJzY29wZSI6IFsgIkFMTCIgXSwgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwgInNob3dXYXRlcm1hcmsiOiB0cnVlLCAidG9sZXJhbmNlRGF5cyI6IDkwLCAidmFsaWQiOiAiMjAyMS0wMS0wMSIgfQpWQVZoT3FSZGl3cXl3VHpndk5sRjk5a24yQWxSTTE4bEVoQ2JWMlRWc25MUG9zQ1NIM0dtMytmZk1Db1drckt3CnZOZ0o1ZllCRGRSVHpLTmNvV3l0Rys5VjlXdU9kd1Y5elFYRTduWWdyL3cxWko1ald4dVZyK1h2QStLVW16MU8KWjFablhwQzZudU9YNTZIbDZPNkF2bWVqZ3VIekRYbHorUTU5OW8vMjVkMFNlN1NzVHBNRHlBWjVCMDRxdERSNApnMlh0STZCUXBuQ0hEQ20yQ253OGlJb2R5N0ZRb0hrQWdVSE0rMzg2aUpZbzRPbmxKNEdGSmRPQmJJdnRiL1VWCktFcktWdVZaWUxTVnBlU3dHMGNURDNESmhsWUdRdzU2cXdZUHo0WVFXWWVMVzNSeFdNN2FMWlZzRzMzbWhyaXQKQjBXUzVDOUQ3RHRFekFmLzBydld0dz09Cg==";

        public UIViewController CurrentScanViewController { get; set; }

        public Dictionary<string, List<ExampleModel>> TableItems = new Dictionary<string, List<ExampleModel>>();

        public AnylineViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var list = ExampleList.Items;
            list.Remove(ExampleList.Items.FirstOrDefault(x => x.Type == ItemType.DocumentUI));

            string currentCategory = null;
            var currentElements = new List<ExampleModel>();

            foreach (var item in list)
            {
                if (item.JsonPath == "")
                    continue;

                if (item.Category != currentCategory)
                {
                    if (currentCategory != null)
                    {
                        TableItems.Add(currentCategory, currentElements);
                    }

                    currentCategory = item.Category;
                    currentElements = new List<ExampleModel>();
                }

                currentElements.Add(item);
            }

            TableItems.Add(currentCategory, currentElements);
            TableItems.Add(list.Last().Category, new List<ExampleModel>());

            TableView = new UITableView(View.Bounds, UITableViewStyle.Grouped);
            TableView.Source = new TableSource(TableItems, this);
        }

        // Lock orientation to portrait
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.Portrait;
        }

        // Don't allow rotation
        public override bool ShouldAutorotate()
        {
            return false;
        }
    };

    public class TableSource : UITableViewSource
    {
        protected Dictionary<string, List<ExampleModel>> TableItems;

        protected AnylineViewController AnylineScanViewController;

        protected string CellIdentifier = "TableCell";

        private readonly object @lock = new object();
        private bool isNavigating = false;

        private bool nfcSupported = true;

        public TableSource(Dictionary<string, List<ExampleModel>> tableItems, AnylineViewController parent)
        {
            TableItems = tableItems;

            // adds NFC as special case once it's supported
            if (nfcSupported)
            {
                var lastItem = TableItems.Last();
                TableItems.Remove(lastItem.Key);
                TableItems.Add("NFC-Item", new List<ExampleModel> { new ExampleModel(ItemType.Item, "Scan NFC of Passports", Category.Workflows, "") });
                TableItems.Add(lastItem.Key, lastItem.Value);
            }

            AnylineScanViewController = parent;
        }

        private string GetBuildVersion()
        {
            return typeof(AnylineViewController).Assembly.GetName().Version.ToString();
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
                        return $"SDK: {assembly.GetName().Version} - Build: {GetBuildVersion()}";
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
            return TableItems.Keys.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);

            cell.TextLabel.Text = TableItems.ToList().ElementAt(indexPath.Section).Value.ToList().ElementAt(indexPath.Row).Name;
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
            if (isNavigating) return;
            lock (@lock) isNavigating = true;

            // free resources of old controller instances
            if (AnylineScanViewController.CurrentScanViewController != null)
            {
                AnylineScanViewController.CurrentScanViewController.Dispose();
                AnylineScanViewController.CurrentScanViewController = null;
            }

            // create a new ScanViewController with the correct json config
            var example = TableItems.ElementAt(indexPath.Section).Value.ElementAt(indexPath.Row);

            if (example.Name == "Scan NFC of Passports")
            {
                if (!UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                {
                    var okAlertController = UIAlertController.Create("NFC Not Supported", "NFC passport reading is not supported on this device", UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                    AnylineScanViewController.PresentViewController(okAlertController, true, null);
                }
                else AnylineScanViewController.CurrentScanViewController = new NFCScanViewController(example.Name);
            }
            else
            {
                AnylineScanViewController.CurrentScanViewController = new ScanViewController(example.Name, example.JsonPath);
            }
            // navigate to the newly created scan view controller
            if (AnylineScanViewController.CurrentScanViewController != null)
                AnylineScanViewController.NavigationController.PushViewController(AnylineScanViewController.CurrentScanViewController, false);

            // workaround so the row selection is not creating a scanViewController twice
            await Task.Delay(200);

            tableView.DeselectRow(indexPath, true);
            lock (@lock) isNavigating = false;
        }

    };
}
