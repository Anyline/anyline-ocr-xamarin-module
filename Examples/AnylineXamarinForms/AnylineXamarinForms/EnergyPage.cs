using Xamarin.Forms;

namespace AnylineXamarinForms
{
    public class EnergyPage : ContentPage
    {
        public EnergyPage ()
		{
            Title = "Energy Page (native)";
            // rendering of this page is done natively on each platform (via EnergyPageRenderer)

            NavigationPage.SetHasBackButton(this, false);
        }
    }
}

