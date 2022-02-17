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
            string licenseKey = "ewogICJsaWNlbnNlS2V5VmVyc2lvbiI6ICIzLjAiLAogICJkZWJ1Z1JlcG9ydGluZyI6ICJwaW5nIiwKICAibWFqb3JWZXJzaW9uIjogIjM3IiwKICAic2NvcGUiOiBbCiAgICAiQUxMIgogIF0sCiAgIm1heERheXNOb3RSZXBvcnRlZCI6IDUsCiAgImFkdmFuY2VkQmFyY29kZSI6IHRydWUsCiAgIm11bHRpQmFyY29kZSI6IHRydWUsCiAgInN1cHBvcnRlZEJhcmNvZGVGb3JtYXRzIjogWwogICAgIkFMTCIKICBdLAogICJwbGF0Zm9ybSI6IFsKICAgICJpT1MiLAogICAgIkFuZHJvaWQiCiAgXSwKICAic2hvd1dhdGVybWFyayI6IHRydWUsCiAgInRvbGVyYW5jZURheXMiOiAzMCwKICAidmFsaWQiOiAiMjAyMi0xMi0zMSIsCiAgImlvc0lkZW50aWZpZXIiOiBbCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5mb3Jtcy5leGFtcGxlcyIKICBdLAogICJhbmRyb2lkSWRlbnRpZmllciI6IFsKICAgICJjb20uYW55bGluZS54YW1hcmluLmV4YW1wbGVzIiwKICAgICJjb20uYW55bGluZS54YW1hcmluLmZvcm1zLmV4YW1wbGVzIgogIF0KfQozWVhKdjlwZ21sVkdTS1EwbEV4VWZib1hneEZDOTMxcXR2a3k2MVh0NnJpK1hiRUhZb1FDL3p3N3ovK1YyUEdGTmtJYm8vSEs5U2ZlRy9sUU1nY1gzbVhYeGFMMFhrM3paNlNxVWhXM3lKV2F6Ni8wOG5nbHAza3psbjgrSklwRklOU3ZRN3V0SEh0UEdHLy9sVGlZd1BpcGZYSGFqbTMzWG5lSGJuY21OSVdNclUxRjVjS3NHL3pCei80aUxHa0MwR2lIRlpub3g0VUFPcW1ueldDREFKQlZZWHZ1UUdJSFhRc0Rwc2NpOFM5bk5hVys2QThXZGhyaVFLYkEvY2xueUJqN0VTNXc5dHl1L0J2YmZ6RzRPWDhQQlVhSHJHbEVNM3lDc1JNbzBvYURpNzVLTEVFcktnNWNoM0ZDTlN3elJ0eXIyRWtNQWpFMGkyTG1mUnJValE9PQ";

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