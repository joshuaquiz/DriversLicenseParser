using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class VirginIslands : IParseableLicense
    {
        public string FullName => "Virgin Islands";

        public string Abbreviation => "VI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636062;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}