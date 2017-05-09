using Xamarin.Forms;

namespace AnylineXamarinForms
{
    public class MrzPage : ContentPage
    {
        public MrzPage ()
		{
            Title = "Mrz Scan Page";
            // rendering of this page is done natively on each platform (via EnergyPageRenderer / MrzPageRenderer etc.)

            NavigationPage.SetHasBackButton(this, false);
        }
    }
}

