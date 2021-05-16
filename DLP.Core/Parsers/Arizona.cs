using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Arizona : IParseableLicense
    {
        public string FullName => "Arizona";

        public string Abbreviation => "AZ";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636026;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}