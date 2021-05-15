using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Florida : IParseable
    {
        public string FullName => "Florida";

        public string Abbreviation => "FL";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636010;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}