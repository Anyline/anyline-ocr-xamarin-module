using System;
using IO.Anyline2;

[assembly: Xamarin.Forms.Dependency(typeof(Anyline.Droid.AnylineSDKService))]
namespace Anyline.Droid
{
    public class AnylineSDKService : IAnylineSDKService
    {
        public bool SetupWithLicenseKey(string licenseKey, out string licenseErrorMessage)
        {
            try
            {
                AnylineSdk.Init(licenseKey, context: MainActivity.Instance);
                licenseErrorMessage = null;
                return true;
            }
            catch (Exception ex)
            {
                licenseErrorMessage = ex.Message;
                return false;
            }
        }
    }
}
