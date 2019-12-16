using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anyline
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(Dictionary<string, Object> results, string configurationFile)
        {
            InitializeComponent();
            Task.Run(() => ShowResults(results));

            btHome.Clicked += async (s, e) => await Navigation.PopToRootAsync();
            btScanAgain.Clicked += async (s, e) =>
            {
                Navigation.InsertPageBefore(new ScanExamplePage(configurationFile), this);
                await Navigation.PopAsync();
            };
        }

        private void ShowResults(Dictionary<string, object> results)
        {
            StackLayout slResults = new StackLayout();
            foreach (var item in results)
            {
                slResults.Children.Add(new Label { Text = item.Key, TextColor = Color.FromHex("32ADFF"), FontSize = 15 });
                if (item.Value.GetType() == typeof(byte[]))
                {
                    var img = new Image()
                    {
                        Aspect = Aspect.AspectFill,
                        Source = ImageSource.FromStream(() => new MemoryStream(item.Value as byte[]))
                    };

                    slResults.Children.Add(img);
                }
                else
                {
                    slResults.Children.Add(new Label { Text = item.Value.ToString(), TextColor = Color.White, FontAttributes = FontAttributes.Bold, FontSize = 17 });
                }
            }

            Device.BeginInvokeOnMainThread(() => cvContent.Content = slResults);
        }
    }
}