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
                new KeyValuePair<string, string>("Barcode","sample_barcode_config"),
                new KeyValuePair<string, string>("Barcode - Full frame","sample_barcode_fullframe_config"),
                new KeyValuePair<string, string>("Universal ID","universal_id_front_config"),
                new KeyValuePair<string, string>("License Plate - EU","license_plate_eu_config"),
                new KeyValuePair<string, string>("Meter","meter_config"),
                new KeyValuePair<string, string>("Universal Serial Number","serial_number_view_config"),
                new KeyValuePair<string, string>("NFC", "mrz_config")
            };

            // YOUR LICENSE KEY HERE
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6ICIzLjAiLAogICJkZWJ1Z1JlcG9ydGluZyI6ICJwaW5nIiwKICAibWFqb3JWZXJzaW9uIjogIjM3IiwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgIm1heERheXNOb3RSZXBvcnRlZCI6IDUsCiAgImFkdmFuY2VkQmFyY29kZSI6IHRydWUsCiAgIm11bHRpQmFyY29kZSI6IHRydWUsCiAgInN1cHBvcnRlZEJhcmNvZGVGb3JtYXRzIjogWwogICAgIkFMTCIKICBdLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiAzMCwKICAidmFsaWQiOiAiMjAyMy0xMi0zMSIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcy5pb3MiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMuaW9zIgogIF0sCiAgImFuZHJvaWRJZGVudGlmaWVyIjogWwogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZXhhbXBsZXMiLAogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiCiAgXQp9Ckh0VzY3MkZ2NWpmK1hNYmhZdGJ5aWNVZUNKTGYyWkYyZjNuMWRzaXM2ZDM1ZlFjYm5IdGhLYkF3Nm5XR1FDcFpWdDNtTlN2S0d4WjZZYjUzWUhZdG1UVlRNeXFLMzdORENiRjBNWXdaU0RvT3Ztd2Z0ZldwMHlmSmV0dFpFNXNIUCs1bll6dW53ZzdZNjVRRytBampFbjFJUUNkbEp3MlE2VWtVMytjTlJyeTVwK2Zka25IdGhFSWszaEk0QjhNR21VdmRMcGhSUzYyQU9nRWNOblBKMVdWdjAybERaZldtRXFNdFhIdW1RU0hzYzROZFFRUTZ3WGFNaWR3YnFVVnNDRmpOQnF4eHhNSThUOHAzVDNCMU5PelB5aS94bTExd0VkNERmTVlGQlVNZHFIeERaOEV1Ly9Ja01va0FRY1dSaStldUo0OVAxeEQyckJITVlTRSsxQT09";

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