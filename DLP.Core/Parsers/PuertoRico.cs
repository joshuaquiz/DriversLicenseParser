using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class PuertoRico : IParseableLicense
    {
        public string FullName => "Puerto Rico";

        public string Abbreviation => "PR";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 604431;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}