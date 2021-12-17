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
            string licenseKey = "ew0KICAibGljZW5zZUtleVZlcnNpb24iOiAyLA0KICAiZGVidWdSZXBvcnRpbmciOiAib24iLA0KICAiaW1hZ2VSZXBvcnRDYWNoaW5nIjogdHJ1ZSwNCiAgIm1ham9yVmVyc2lvbiI6ICIyNSIsDQogICJtYXhEYXlzTm90UmVwb3J0ZWQiOiA1LA0KICAiYWR2YW5jZWRCYXJjb2RlIjogdHJ1ZSwNCiAgIm11bHRpQmFyY29kZSI6IHRydWUsDQogICJzdXBwb3J0ZWRCYXJjb2RlRm9ybWF0cyI6IFsNCiAgICAiQUxMIg0KICBdLA0KICAicGluZ1JlcG9ydGluZyI6IHRydWUsDQogICJwbGF0Zm9ybSI6IFsNCiAgICAiaU9TIiwNCiAgICAiQW5kcm9pZCINCiAgXSwNCiAgInNjb3BlIjogWw0KICAgICJBTEwiDQogIF0sDQogICJzaG93UG9wVXBBZnRlckV4cGlyeSI6IHRydWUsDQogICJzaG93V2F0ZXJtYXJrIjogdHJ1ZSwNCiAgInRvbGVyYW5jZURheXMiOiA5MCwNCiAgInZhbGlkIjogIjIwMjItMTItMzEiLA0KICAiaW9zSWRlbnRpZmllciI6IFsNCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsDQogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiDQogIF0sDQogICJhbmRyb2lkSWRlbnRpZmllciI6IFsNCiAgICAiY29tLmFueWxpbmUueGFtYXJpbi5leGFtcGxlcyIsDQogICAgImNvbS5hbnlsaW5lLnhhbWFyaW4uZm9ybXMuZXhhbXBsZXMiDQogIF0NCn0KdDNNWS9pbDFxT2U4am1vMkJ3bW9qa3YwTjNWRDV2dGU3R1JtMU82L2ZILzRoV09SdStYSEdPWnJhc05wUkl3dUxCTEdjZkptVys5czdUazEzQUVTSkgwMmExMXhZN1VuSUlDM0hzMXBXUGN1K1JEREdFYk9TVXZ4ME50UGlFNVdnNUsrdzBQTWF0Z1lqYUhJSjZ2cnNXVTVvdjcwR1NxNnBvUTJVTkczZVhScUlMbGpjSlp5aTNXMlhPcXFtTmsxRmhDdGZWLzRYa3R0MzMrKzgreERLT0RtbmZhYUNVZTVpYmJSektDemdPcSs4eFR3T1pFcHhOMm1ON1BIVGN6MWhkdExZbGRMdjdRcjJNUHd6SGR0eU5HVXJ0UlJXVVNTQ1N5MGRDajNlSXd6cFp5bERnejdveXFzR205YVpRN3RKQUMrZjByakF3cWJxZHRsZUdqUC9BPT0=";

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