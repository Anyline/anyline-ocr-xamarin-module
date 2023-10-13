using System;
using System.Collections.Generic;
using Anyline.NFC;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anyline
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // YOUR LICENSE KEY HERE
            string licenseKey = "YOUR_LICENSE_KEY_HERE";

            // Initializes the Anyline SDK natively in each platform and get the results back
            bool isAnylineInitialized = DependencyService.Get<IAnylineSDKService>().SetupWithLicenseKey(licenseKey, out string licenseErrorMessage);

            if (!isAnylineInitialized)
            {
                DisplayAlert("License Exception", licenseErrorMessage, "OK");
            }

            ShowScanModesButtons(isAnylineInitialized);
        }

        private void ShowScanModesButtons(bool isAnylineInitialized)
        {
            var scanMode_configurations_energy = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Analog/Digital Meter","energy_analog_digital_config"),
                new KeyValuePair<string, string>("Dial Meter","energy_dial_config"),
            };
            var scanMode_configurations_identity = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Universal ID - Latin","id_config_universal"),
                new KeyValuePair<string, string>("Universal ID - Arabic","id_config_arabic"),
                new KeyValuePair<string, string>("Universal ID - Cyrillic","id_config_cyrillic"),
                new KeyValuePair<string, string>("MRZ / Passport","id_config_mrz"),
                new KeyValuePair<string, string>("Japanese Landing Permission","id_config_jlp"),
            };
            var scanMode_configurations_vehicle = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("License Plate - EU","vehicle_config_license_plate_eu"),
                new KeyValuePair<string, string>("License Plate - USA","vehicle_config_license_plate_us"),
                new KeyValuePair<string, string>("License Plate - Africa","vehicle_config_license_plate_africa"),
                new KeyValuePair<string, string>("Vehicle Identification Number (VIN)","vehicle_vin_config"),
                new KeyValuePair<string, string>("Vehicle Registration Certificate","vehicle_registration_certificate_config"),
            };
            var scanMode_configurations_tire = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("TIN - Universal","tire_tin_universal_config"),
                new KeyValuePair<string, string>("TIN - DOT (Noth Americal Only)","tire_tin_dot_config"),
                new KeyValuePair<string, string>("Tire Size Specifications","tire_size_config"),
                new KeyValuePair<string, string>("Commercial Tire Identification Numbers","tire_commercial_tire_id_config"),
                new KeyValuePair<string, string>("Tire Make","tire_make_config"),
            };
            var scanMode_configurations_mro = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Serial Number","mro_usnr_config"),
                new KeyValuePair<string, string>("Shipping Container - Horizontal","mro_shipping_container_horizontal_config"),
                new KeyValuePair<string, string>("Shipping Container - Vertical","mro_shipping_container_vertical_config"),
            };
            var scanMode_configurations_barcode = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Barcode","others_config_barcode")
            };
            var scanMode_configurations_composite = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Serial - License Plate (EU) + ID + VIN","workflows_config_serial_scanning"),
                new KeyValuePair<string, string>("Parallel - Meter + Serial Number","workflows_config_parallel_scanning"),
                new KeyValuePair<string, string>("Parallel - First Scan (VIN or Barcode)","workflows_config_serial_scanning.json"),
            };

            var scanMode_configurations_nfc = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Scan NFC of Passports", "id_config_mrz")
            };
            
            AddCategoryTitle("Energy");
            AddButtons(scanMode_configurations_energy, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Identity Documents");
            AddButtons(scanMode_configurations_identity, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Vehicle");
            AddButtons(scanMode_configurations_vehicle, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Tire");
            AddButtons(scanMode_configurations_tire, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Maintenance, Repair & Operations");
            AddButtons(scanMode_configurations_mro, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Barcode");
            AddButtons(scanMode_configurations_barcode, isEnabled: isAnylineInitialized);
            AddCategoryTitle("Composite");
            AddButtons(scanMode_configurations_composite, isEnabled: isAnylineInitialized);
            AddCategoryTitle("NFC");
            AddButtons(scanMode_configurations_nfc, isEnabled: isAnylineInitialized);
        }

        private void AddCategoryTitle(string title)
        {
            var lbTile = new Label { Text = title, TextColor = Color.FromHex("32ADFF"), FontSize = 18, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.CenterAndExpand, Margin = 10 };
            slScanButtons.Children.Add(lbTile);
        }

        private void AddButtons(List<KeyValuePair<string, string>> scanModes_Configurations, bool isEnabled)
        {
            foreach (var item in scanModes_Configurations)
            {
                var btScan = new Button() { Text = item.Key, BackgroundColor = Color.FromHex("32ADFF"), TextColor = Color.White };
                btScan.Clicked += BtScan_Clicked;
                btScan.ClassId = item.Value;
                btScan.IsEnabled = isEnabled;
                slScanButtons.Children.Add(btScan);
            }
        }

        private async void BtScan_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.Camera>();
            }

            (sender as Button).IsEnabled = false;
            if ((sender as Button).Text == "Scan NFC of Passports")
                await Navigation.PushAsync(new NFCScanExamplePage(((Button)sender).ClassId));
            else
                await Navigation.PushAsync(new ScanExamplePage(((Button)sender).ClassId));

            (sender as Button).IsEnabled = true;
        }
    }
}