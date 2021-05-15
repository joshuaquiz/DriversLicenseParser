using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class California : IParseable
    {
        public string FullName => "California";

        public string Abbreviation => "CA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636014;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}