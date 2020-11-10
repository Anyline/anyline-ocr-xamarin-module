using System;
using System.Collections.Generic;
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
                new KeyValuePair<string, string>("License Plate","vehicle_config_license_plate"),
                new KeyValuePair<string, string>("Meter","energy_config_analog_digital"),
                new KeyValuePair<string, string>("USNR","mro_config_usnr")
            };

            // YOUR LICENSE KEY HERE
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6IDIsCiAgImRlYnVnUmVwb3J0aW5nIjogIm9uIiwKICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwKICAibWFqb3JWZXJzaW9uIjogIjI1IiwKICAibWF4RGF5c05vdFJlcG9ydGVkIjogNSwKICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwKICAibXVsdGlCYXJjb2RlIjogdHJ1ZSwKICAic3VwcG9ydGVkQmFyY29kZUZvcm1hdHMiOiBbCiAgICAiQUxMIgogIF0sCiAgInBpbmdSZXBvcnRpbmciOiB0cnVlLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgInNob3dQb3BVcEFmdGVyRXhwaXJ5IjogdHJ1ZSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiA5MCwKICAidmFsaWQiOiAiMjAyMS0wNi0zMCIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQpJbHE1REZNMU03QzEzNGJiaGo4dm9zMEFEVjEzNm1HbWNEYmdUbUdoWTd3dDlrR0gyYTRyK3RjeDJLYTNZN3d3R1EweThWeFZvZWVmQU5NWEtycm04bGkzN1MzKzdjWTU1dUZ1RVJPUkR6bmd3aCtYMmU3VGtkNDhiemd5Y1JpdnZkM09LZ3JiNDRUbDBycHExc2dOZVVzVVozRnEwd3dFM2VMQWx3VkFrdkRiVjdOdktaMEF5M3J6Mmg0TGNuTmpQTHErOTE0VmVPZUNDVUo3aU9VMW5vWUJKUlBqdDFmWHpqS1dOZmNXRXNPTlJrMVNaMUFzaXREZzNCMHVuZXZLSVNBWXRZT0hTL01DWDlseVlHS05acWQxODBrOXhscUVpbVVYTjc4UnFHd2ZLRFF2SFpoTWp4LzFzVFVrZXI4aFpNcGNtb0c5NWJMSjhoTlFRNjNuZ2c9PQ";

            // Initializes the AnylineSDK natively in each platform and get the results back
            bool validLicense = DependencyService.Get<IAnylineSDKService>().SetupWithLicenseKey(licenseKey, out string licenseError);

            AddButtons(scanMode_configurations, isEnabled: validLicense);

            if (!validLicense)
            {
                DisplayAlert("License Exception", licenseError, "OK");
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
            await Navigation.PushAsync(new ScanExamplePage(((Button)sender).ClassId));
            (sender as Button).IsEnabled = true;
        }
    }
}