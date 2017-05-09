using Xamarin.Forms;

namespace AnylineXamarinForms
{
    class AnylineFormsPage : ContentPage
    {
        public AnylineFormsPage()
        {
            var label = new Label
            {
                Text = "This is the Xamarin.Forms Page.",
                FontAttributes = FontAttributes.None,
                FontSize = 20
            };

            var button = new Button
            {
                Text = "Launch native scan module",
                FontAttributes = FontAttributes.None,
                FontSize = 18
            };

            button.Clicked += (s, e) => 
            {
                Navigation.PushAsync(new EnergyPage());
            };

            Content = new StackLayout
            {
                Spacing = 30,
                VerticalOptions = LayoutOptions.Start,
                Children = {
					label,
                    button
				}
            };
        }

        
    }
}
