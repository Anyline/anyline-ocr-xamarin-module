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
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6ICIzLjAiLAogICJkZWJ1Z1JlcG9ydGluZyI6ICJwaW5nIiwKICAibWFqb3JWZXJzaW9uIjogIjM3IiwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgIm1heERheXNOb3RSZXBvcnRlZCI6IDUsCiAgImFkdmFuY2VkQmFyY29kZSI6IHRydWUsCiAgIm11bHRpQmFyY29kZSI6IHRydWUsCiAgInN1cHBvcnRlZEJhcmNvZGVGb3JtYXRzIjogWwogICAgIkFMTCIKICBdLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiAzMCwKICAidmFsaWQiOiAiMjAyMy0xMi0zMSIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcy5pb3MiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMuaW9zIgogIF0sCiAgImFuZHJvaWRJZGVudGlmaWVyIjogWwogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiCiAgXQp9Ckh0VzY3MkZ2NWpmK1hNYmhZdGJ5aWNVZUNKTGYyWkYyZjNuMWRzaXM2ZDM1ZlFjYm5IdGhLYkF3Nm5XR1FDcFpWdDNtTlN2S0d4WjZZYjUzWUhZdG1UVlRNeXFLMzdORENiRjBNWXdaU0RvT3Ztd2Z0ZldwMHlmSmV0dFpFNXNIUCs1bll6dW53ZzdZNjVRRytBampFbjFJUUNkbEp3MlE2VWtVMytjTlJyeTVwK2Zka25IdGhFSWszaEk0QjhNR21VdmRMcGhSUzYyQU9nRWNOblBKMVdWdjAybERaZldtRXFNdFhIdW1RU0hzYzROZFFRUTZ3WGFNaWR3YnFVVnNDRmpOQnF4eHhNSThUOHAzVDNCMU5PelB5aS94bTExd0VkNERmTVlGQlVNZHFIeERaOEV1Ly9Ja01va0FRY1dSaStldUo0OVAxeEQyckJITVlTRSsxQT09";

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
                new KeyValuePair<string, string>("Analog/Digital Meter","analog_digital_meter_config"),
                new KeyValuePair<string, string>("Dial Meter","dial_meter_config"),
            };
            var scanMode_configurations_identity = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Universal ID - Latin","universal_id_config"),
                new KeyValuePair<string, string>("Universal ID - Arabic","arabic_id_config"),
                new KeyValuePair<string, string>("Universal ID - Cyrillic","cyrillic_id_config"),
                new KeyValuePair<string, string>("MRZ / Passport","mrz_config"),
            };
            var scanMode_configurations_vehicle = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("License Plate - EU","license_plate_eu_config"),
                new KeyValuePair<string, string>("License Plate - USA","license_plate_us_config"),
                new KeyValuePair<string, string>("License Plate - Africa","license_plate_af_config"),
                new KeyValuePair<string, string>("Vehicle Identification Number (VIN)","vin_config"),
                new KeyValuePair<string, string>("Vehicle Registration Certificate","vrc_config"),
            };
            var scanMode_configurations_tire = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Tire Identification Number (TIN) - Universal","tin_config"),
                new KeyValuePair<string, string>("Tire Identification Number (TIN) - DOT","tire_config_tin_dot"),
                new KeyValuePair<string, string>("Tire Size Specifications","tire_size_config"),
                new KeyValuePair<string, string>("Commercial Tire Identification Number","commercial_tire_id_config"),
                new KeyValuePair<string, string>("Tire Make","tire_make_config"),
            };
            var scanMode_configurations_mro = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Serial Number","serial_number_config"),
                new KeyValuePair<string, string>("Shipping Container - Horizontal","container_horizontal_config"),
                new KeyValuePair<string, string>("Shipping Container - Vertical","container_vertical_config"),
            };
            var scanMode_configurations_barcode = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Barcode","barcode_config"),
                new KeyValuePair<string, string>("Barcode - PDF417 - AAMVA","barcode_pdf417_config"),
            };
            var scanMode_configurations_composite = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Serial - License Plate (EU) + Driver's License + VIN","composite_serial_config"),
                new KeyValuePair<string, string>("Parallel - Meter + Serial Number","composite_parallel_config"),
                new KeyValuePair<string, string>("Parallel - First Scan (VIN or Barcode)","composite_parallel_config_first_scan.json"),
            };

            var scanMode_configurations_nfc = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Scan NFC of Passports", "mrz_config")
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