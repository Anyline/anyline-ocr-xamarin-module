namespace Anyline
{
    public interface IAnylineSDKService
    {
        bool SetupWithLicenseKey(string LicenseKey, out string LicenseError);
    }
}
