using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Delaware : IParseableLicense
    {
        public string FullName => "Delaware";

        public string Abbreviation => "DE";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636011;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}