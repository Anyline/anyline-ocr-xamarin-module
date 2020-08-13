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

            List<KeyValuePair<string, string>> scanMode_configurations = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Barcode","others_config_barcode"),
                new KeyValuePair<string, string>("License Plate","vehicle_config_license_plate"),
                new KeyValuePair<string, string>("Meter","energy_config_analog_digital"),
                new KeyValuePair<string, string>("USNR","mro_config_usnr")
            };

            AddButtons(scanMode_configurations);
        }

        private void AddButtons(List<KeyValuePair<string, string>> scanModes_Configurations)
        {
            foreach (var item in scanModes_Configurations)
            {
                var btScan = new Button() { Text = item.Key, BackgroundColor = Color.FromHex("32ADFF"), TextColor = Color.White };
                btScan.Clicked += BtScan_Clicked;
                btScan.ClassId = item.Value;
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