using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class SouthCarolina : IParseable
    {
        public string FullName => "South Carolina";

        public string Abbreviation => "SC";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636005;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}