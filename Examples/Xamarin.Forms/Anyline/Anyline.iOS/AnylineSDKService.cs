using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(Anyline.iOS.AnylineSDKService))]
namespace Anyline.iOS
{
    public class AnylineSDKService : IAnylineSDKService
    {
        public bool SetupWithLicenseKey(string licenseKey, out string LicenseError)
        {
            NSError licenseError;

            AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey, out licenseError);

            if (licenseError == null)
            {
                LicenseError = null;
                return true;
            }
            else
            {
                LicenseError = licenseError.LocalizedDescription;
                return false;
            }
        }
    }
}
