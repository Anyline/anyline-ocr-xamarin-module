using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(Anyline.iOS.AnylineSDKService))]
namespace Anyline.iOS
{
    public class AnylineSDKService : IAnylineSDKService
    {
        public bool SetupWithLicenseKey(string licenseKey, out string licenseErrorMessage)
        {
            NSError licenseError;

            AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey, out licenseError);

            if (licenseError == null)
            {
                licenseErrorMessage = null;
                return true;
            }
            else
            {
                licenseErrorMessage = licenseError.LocalizedDescription;
                return false;
            }
        }
    }
}
