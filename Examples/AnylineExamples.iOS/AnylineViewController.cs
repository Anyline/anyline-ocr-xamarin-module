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
        public UIViewController CurrentScanViewController { get; set; }

        public Dictionary<string, List<ExampleModel>> TableItems = new Dictionary<string, List<ExampleModel>>();

        public AnylineViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // INSERT YOUR LICENSE KEY HERE
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwKICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwKICAibWFqb3JWZXJzaW9uIjogIjI1IiwKICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwKICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwKICAibXVsdGlCYXJjb2RlIjogdHJ1ZSwKICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbCiAgICAiQUxMIgogIF0sCiAgInBpbmdSZXBvcnRpbmciOiB0cnVlLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiA5MCwKICAidmFsaWQiOiAiMjAyMS0wNi0zMCIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQpJbHE1REZNMU03QzEzNGJiaGo4dm9zMEFEVjEzNm1HbWNEYmdUbUdoWTd3dDlrR0gyYTRyK3RjeDJLYTNZN3d3R1EweThWeFZvZWVmQU5NWEtycm04bGkzN1MzKzdjWTU1dUZ1RVJPUkR6bmd3aCtYMmU3VGtkNDhiemd5Y1JpdnZkM09LZ3JiNDRUbDBycHExc2dOZVVzVVozRnEwd3dFM2VMQWx3VkFrdkRiVjdOdktaMEF5M3J6Mmg0TGNuTmpQTHErOTE0VmVPZUNDVUo3aU9VMW5vWUJKUlBqdDFmWHpqS1dOZmNXRXNPTlJrMVNaMUFzaXREZzNCMHVuZXZLSVNBWXRZT0hTL01DWDlseVlHS05acWQxODBrOXhscUVpbVVYTjc4UnFHd2ZLRFF2SFpoTWp4LzFzVFVrZXI4aFpNcGNtb0c5NWJMSjhoTlFRNjNuZ2c9PQ==";

            // INITIALIZE THE ANYLINE SDK
            bool validLicense = AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey, out NSError licenseError);

            // If the License Key is invalid
            if (!validLicense)
            {
                // Do something about it here.
                var okAlertController = UIAlertController.Create("License Exception", licenseError.LocalizedDescription, UIAlertControllerStyle.Alert);
                okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                PresentViewController(okAlertController, true, null);
                System.Diagnostics.Debug.WriteLine(licenseError.LocalizedDescription);
            }

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
