using Xamarin.Forms;

namespace Anyline.NFC
{
    public class NFCScanExamplePage : Page
    {
        public string ConfigurationFile = "";
        private MyScanResults myScanResults = new MyScanResults();

        public NFCScanExamplePage(string configurationFile)
        {
            BackgroundColor = Color.Black;
            Title = "Anyline Xamarin Module";
            ConfigurationFile = configurationFile;

            // Listens for the results of the MRZ Scan Result
            MessagingCenter.Subscribe<Xamarin.Forms.Application, MyMRZScanResults>(this, "MRZ_READING_DONE", (s, results) =>
            {
                MessagingCenter.Unsubscribe<Xamarin.Forms.Application, MyMRZScanResults>(this, "MRZ_READING_DONE");
                myScanResults.MRZResults = results;
            });

            // Listens for the results of the NFC Scan Result
            MessagingCenter.Subscribe<Xamarin.Forms.Application, MyNFCScanResults>(this, "NFC_SCAN_FINISHED_SUCCESS", (s, results) =>
            {
                MessagingCenter.Unsubscribe<Xamarin.Forms.Application, MyNFCScanResults>(this, "NFC_SCAN_FINISHED_SUCCESS");
                Device.BeginInvokeOnMainThread(async () =>
                {
                    myScanResults.NFCResults = results;

                    // Opens the Results Page to display the MRZ and NFC data
                    Navigation.InsertPageBefore(new NFCResultsPage(myScanResults, configurationFile), this);
                    await Navigation.PopAsync();
                });
            });

            // Listens for errors on the NFC Scanning Process
            MessagingCenter.Subscribe<Xamarin.Forms.Application, string>(this, "NFC_SCAN_FINISHED_ERROR", (s, message) =>
            {
                MessagingCenter.Unsubscribe<Xamarin.Forms.Application, string>(this, "NFC_SCAN_FINISHED_ERROR");
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("NFC Error", message, "OK");
                });
            });
        }
    }
}