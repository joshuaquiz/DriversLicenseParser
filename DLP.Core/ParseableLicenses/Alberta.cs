using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Alberta : IParseableLicense
    {
        public string FullName => "Alberta";

        public string Abbreviation => "AB";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604432;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}