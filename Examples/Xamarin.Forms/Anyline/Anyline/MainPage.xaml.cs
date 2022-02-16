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

            var scanMode_configurations = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Barcode","others_config_barcode"),
                new KeyValuePair<string, string>("Universal ID","id_config_universal"),
                new KeyValuePair<string, string>("License Plate","vehicle_config_license_plate"),
                new KeyValuePair<string, string>("Meter","energy_config_analog_digital"),
                new KeyValuePair<string, string>("USNR","mro_config_usnr"),
                new KeyValuePair<string, string>("NFC", "id_config_mrz")
            };

            // YOUR LICENSE KEY HERE
            string licenseKey = "ew0KICAibGljZW5zZUtleVZlcnNpb24iOiAiMy4wIiwNCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwNCiAgIm1ham9yVmVyc2lvbiI6ICIzNyIsDQogICJzY29wZSI6IFsNCiAgICAiQUxMIiwNCiAgICAiTkZDIiwNCiAgICAiRkFVIg0KICBdLA0KICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwNCiAgImFkdmFuY2VkQmFyY29kZSI6IHRydWUsDQogICJtdWx0aUJhcmNvZGUiOiB0cnVlLA0KICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbDQogICAgIkFMTCINCiAgXSwNCiAgInBsYXRmb3JtIjogWw0KICAgICJpT1MiLA0KICAgICJBbmRyb2lkIg0KICBdLA0KICAic2hvd1dhdGVybWFyayI6IHRydWUsDQogICJ0b2xlcmFuY2VEYXlzIjogMzAsDQogICJ2YWxpZCI6ICIyMDIyLTEyLTMxIiwNCiAgImlvc0lkZW50aWZpZXIiOiBbDQogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLA0KICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIg0KICBdLA0KICAiYW5kcm9pZElkZW50aWZpZXIiOiBbDQogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLA0KICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIg0KICBdDQp9CnkxRng4cUlvV01NSmlNYlRLblV6bzNiUlBGN3Z6MDZSSmxQaGM5VlNOMVRqRW4yWGxsd3VkbHhDWnRTTERWamUxdWZ4ZXZXL0Zwejg0N29lWWpLTTVTQ2xwVzlrQ3lGd09jcCtTUjI3dTM0bEFKM3FHbjUrWnptbTdOVmhzalpadTgxU0MrMVRlNWtQcEROYmN1OS92Q3R4MDlKZGNIa2RpRHhZNTZreU9CcFdXRFZEOTdScVphZXl3b2lhazQ0YWtGL3NoSzdUZHpvVFlZYWV6WFU4QWExYW05Z2crZll4L2dIRTZ5WWJ3bEUyeHM3UHFlY0ticWxXTkVDRXJJT0NuNTNiMUVUQURDREU5bEdDdlhybko3YUMyWU84SlpRQllIZlpscWc1SHordisrcVhDZXFoZUdVZDhKQVdYejNlUlVObzlGaFQySUY5OUE5V210QWlwQT09";

            // Initializes the Anyline SDK natively in each platform and get the results back
            bool isAnylineInitialized = DependencyService.Get<IAnylineSDKService>().SetupWithLicenseKey(licenseKey, out string licenseErrorMessage);

            AddButtons(scanMode_configurations, isEnabled: isAnylineInitialized);

            if (!isAnylineInitialized)
            {
                DisplayAlert("License Exception", licenseErrorMessage, "OK");
            }
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
            if ((sender as Button).Text == "NFC")
                await Navigation.PushAsync(new NFCScanExamplePage(((Button)sender).ClassId));
            else
                await Navigation.PushAsync(new ScanExamplePage(((Button)sender).ClassId));

            (sender as Button).IsEnabled = true;
        }
    }
}