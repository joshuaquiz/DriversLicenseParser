using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Wyoming : IParseableLicense
    {
        public string FullName => "Wyoming";

        public string Abbreviation => "WY";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636060;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}