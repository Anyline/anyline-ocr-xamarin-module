using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Anyline.NFC;
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
            btScanAgain.Clicked += (s, e) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Navigation.InsertPageBefore(new ScanExamplePage(configurationFile), this);
                    await Navigation.PopAsync();
                });
            };
        }

        private void ShowResults(Dictionary<string, object> results)
        {
            View viewResults = CreateResultView(results);
            Device.BeginInvokeOnMainThread(() => cvContent.Content = viewResults);
        }

        private View CreateResultView(Dictionary<string, object> dict)
        {
            StackLayout slItemResults = new StackLayout() { Padding = new Thickness(5, 0, 0, 0) };

            foreach (var item in dict)
            {
                string[] name_type = item.Key.Split(' ');

                var formmattedString = new FormattedString();
                formmattedString.Spans.Add(new Span() { Text = name_type[0] + " ", TextColor = Color.FromHex("32ADFF"), FontSize = 15, FontAttributes = FontAttributes.Bold });
                formmattedString.Spans.Add(new Span() { Text = name_type[1], TextColor = Color.FromHex("32ADFF"), FontSize = 10 });

                slItemResults.Children.Add(new Label() { FormattedText = formmattedString });

                if (item.Value.GetType() == typeof(byte[]))
                {
                    var img = new Image()
                    {
                        Aspect = Aspect.AspectFit,
                        Source = ImageSource.FromStream(() => new MemoryStream(item.Value as byte[]))
                    };

                    slItemResults.Children.Add(img);
                }
                else if (item.Value is Dictionary<string, object> subItems)
                {
                    slItemResults.Children.Add(CreateResultView(subItems));
                }
                else
                {
                    slItemResults.Children.Add(new Label { Text = item.Value.ToString(), TextColor = Color.White, FontAttributes = FontAttributes.Bold, FontSize = 17 });
                }
            }

            Grid grContent = new Grid() { };
            grContent.ColumnDefinitions.Add(new ColumnDefinition { Width = 0.3 });
            grContent.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grContent.Children.Add(new BoxView { BackgroundColor = Color.Gray }, 0, 0);
            grContent.Children.Add(slItemResults, 1, 0);
            return grContent;
        }
    }
}
