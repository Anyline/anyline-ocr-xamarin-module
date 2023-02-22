using System;
namespace Anyline.NFC
{
    public class MyScanResults
    {
        public MyMRZScanResults MRZResults { get; set; }
        public MyNFCScanResults NFCResults { get; set; }
    }

    public class MyMRZScanResults
    {
        public byte[] CroppedImage { get; set; }
        public byte[] FullImage { get; set; }
        public byte[] FaceImage { get; set; }

        public string GivenNames { get; set; }
        public string Surname { get; set; }

        public string PassportNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfExpiry { get; set; }
    }

    public class MyNFCScanResults
    {
        public byte[] FaceImage { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfExpiry { get; set; }
        public string DocumentType { get; set; }
        public string IssueAuthority { get; set; }
        public string IssuingCountryCode { get; set; }
        public string Nationality { get; set; }
        public string ValidFrom { get; set; }
        public string ValidUntil { get; set; }
        public string OrganizationalUnit { get; set; }
        public string CertificationAuthority { get; set; }
        public string IssuerCountry { get; set; }
        public string IssuingStateCode { get; set; }
    }
}
