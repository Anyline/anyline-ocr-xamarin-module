namespace Anyline
{
    public interface IAnylineSDKService
    {
        bool SetupWithLicenseKey(string licenseKey, out string licenseErrorMessage);
    }
}
