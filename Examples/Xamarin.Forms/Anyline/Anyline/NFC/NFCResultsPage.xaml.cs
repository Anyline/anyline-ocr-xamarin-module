using System.IO;
using Xamarin.Forms;

namespace Anyline.NFC
{
    public partial class NFCResultsPage : ContentPage
    {
        public NFCResultsPage(MyScanResults results, string configurationFile)
        {
            InitializeComponent();

            ShowResults(results);

            btHome.Clicked += async (s, e) => await Navigation.PopToRootAsync();
            btScanAgain.Clicked += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Navigation.InsertPageBefore(new NFCScanExamplePage(configurationFile), this);
                    await Navigation.PopAsync();
                });
            };
        }

        private void ShowResults(MyScanResults results)
        {
            lbMRZGivenNames.Text = results.MRZResults.GivenNames;
            lbMRZSurname.Text = results.MRZResults.Surname;

            lbNFCFirstName.Text = results.NFCResults.FirstName;
            lbNFCLastName.Text = results.NFCResults.LastName;

            lbMRZPassportNumber.Text = results.MRZResults.PassportNumber;
            lbNFCDocumentNumber.Text = results.NFCResults.DocumentNumber;

            //imMrzFaceImage.Source = ImageSource.FromStream(() => new MemoryStream(results.MRZResults.FaceImage));
            imNFCFaceImage.Source = ImageSource.FromStream(() => new MemoryStream(results.NFCResults.FaceImage));

            //imCutout.Source = ImageSource.FromStream(() => new MemoryStream(results.MRZResults.CroppedImage));
            imFull.Source = ImageSource.FromStream(() => new MemoryStream(results.MRZResults.FullImage));
        }
    }
}