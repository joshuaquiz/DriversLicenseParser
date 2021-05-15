using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class WestVirginia : IParseable
    {
        public string FullName => "West Virginia";

        public string Abbreviation => "WV";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636061;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}