using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NorthCarolina : IParseable
    {
        public string FullName => "North Carolina";

        public string Abbreviation => "NC";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636004;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}