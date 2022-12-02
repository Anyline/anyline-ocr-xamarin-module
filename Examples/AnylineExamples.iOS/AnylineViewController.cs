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
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6ICIzLjAiLAogICJkZWJ1Z1JlcG9ydGluZyI6ICJwaW5nIiwKICAibWFqb3JWZXJzaW9uIjogIjM3IiwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgIm1heERheXNOb3RSZXBvcnRlZCI6IDUsCiAgImFkdmFuY2VkQmFyY29kZSI6IHRydWUsCiAgIm11bHRpQmFyY29kZSI6IHRydWUsCiAgInN1cHBvcnRlZEJhcmNvZGVGb3JtYXRzIjogWwogICAgIkFMTCIKICBdLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiAzMCwKICAidmFsaWQiOiAiMjAyMy0xMi0zMSIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcy5pb3MiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMuaW9zIgogIF0sCiAgImFuZHJvaWRJZGVudGlmaWVyIjogWwogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiCiAgXQp9Ckh0VzY3MkZ2NWpmK1hNYmhZdGJ5aWNVZUNKTGYyWkYyZjNuMWRzaXM2ZDM1ZlFjYm5IdGhLYkF3Nm5XR1FDcFpWdDNtTlN2S0d4WjZZYjUzWUhZdG1UVlRNeXFLMzdORENiRjBNWXdaU0RvT3Ztd2Z0ZldwMHlmSmV0dFpFNXNIUCs1bll6dW53ZzdZNjVRRytBampFbjFJUUNkbEp3MlE2VWtVMytjTlJyeTVwK2Zka25IdGhFSWszaEk0QjhNR21VdmRMcGhSUzYyQU9nRWNOblBKMVdWdjAybERaZldtRXFNdFhIdW1RU0hzYzROZFFRUTZ3WGFNaWR3YnFVVnNDRmpOQnF4eHhNSThUOHAzVDNCMU5PelB5aS94bTExd0VkNERmTVlGQlVNZHFIeERaOEV1Ly9Ja01va0FRY1dSaStldUo0OVAxeEQyckJITVlTRSsxQT09";

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

    };

    public class TableSource : UITableViewSource
    {
        protected Dictionary<string, List<ExampleModel>> TableItems;

        protected AnylineViewController AnylineScanViewController;

        protected string CellIdentifier = "TableCell";

        private readonly object @lock = new object();
        private bool isNavigating = false;

        public TableSource(Dictionary<string, List<ExampleModel>> tableItems, AnylineViewController parent)
        {
            TableItems = tableItems;

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
