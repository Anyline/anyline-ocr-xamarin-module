using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(Anyline.iOS.AnylineSDKService))]
namespace Anyline.iOS
{
    public class AnylineSDKService : IAnylineSDKService
    {
        public bool SetupWithLicenseKey(string licenseKey, out string licenseErrorMessage)
        {
            // INITIALIZE THE ANYLINE SDK
            //bool validLicense = AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey, out NSError licenseError);
            bool validLicense = AnylineXamarinSDK.iOS.AnylineSDK.SetupWithLicenseKey(licenseKey,
                                AnylineXamarinSDK.iOS.ALCacheConfig.OfflineLicenseEventCachingEnabled,
                                out NSError licenseError);

            if (licenseError == null)
            {
                licenseErrorMessage = null;


                var exportMessage = "Event cache is empty.";
                string exportedCacheFile = AnylineXamarinSDK.iOS.AnylineSDK.ExportCachedEvents(out NSError exportError);
                if (exportedCacheFile != null)
                {
                    exportMessage = $"New file generated at {exportedCacheFile}";
                }
                System.Diagnostics.Debug.WriteLine(exportMessage);


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
