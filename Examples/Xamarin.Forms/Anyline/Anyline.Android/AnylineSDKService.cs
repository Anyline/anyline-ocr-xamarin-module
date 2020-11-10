using System;
using IO.Anyline;

[assembly: Xamarin.Forms.Dependency(typeof(Anyline.Droid.AnylineSDKService))]
namespace Anyline.Droid
{
    public class AnylineSDKService : IAnylineSDKService
    {
        public bool SetupWithLicenseKey(string licenseKey, out string LicenseError)
        {
            try
            {
                AnylineSDK.Init(licenseKey, MainActivity.Instance);
                LicenseError = null;
                return true;
            }
            catch (Exception ex)
            {
                LicenseError = ex.Message;
                return false;
            }
        }
    }
}
