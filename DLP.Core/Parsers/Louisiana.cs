using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Louisiana : IParseable
    {
        public string FullName => "Louisiana";

        public string Abbreviation => "LA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636007;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}