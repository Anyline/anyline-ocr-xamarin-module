using System;
using Android.Widget;
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
                IO.Anyline2.AnylineSdk.Init(licenseKey, context: MainActivity.Instance, cacheConfigPreset: CacheConfig.Preset.OfflineLicenseEventCachingEnabled.Instance);

                var exportMessage = "Event cache is empty.";
                string exportedCacheFile = IO.Anyline2.AnylineSdk.ExportCachedEvents();
                if (exportedCacheFile != null)
                {
                    exportMessage = $"New file generated at {exportedCacheFile}";
                }
                System.Diagnostics.Debug.WriteLine(exportMessage);
                Toast.MakeText(MainActivity.Instance, exportMessage, ToastLength.Long).Show();

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
