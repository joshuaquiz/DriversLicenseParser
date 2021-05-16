using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class AmericanSamoa : IParseableLicense
    {
        public string FullName => "American Samoa";

        public string Abbreviation => "AS";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 604427;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}