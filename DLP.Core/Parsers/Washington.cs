using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Washington : IParseable
    {
        public string FullName => "Washington";

        public string Abbreviation => "WA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636045;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}