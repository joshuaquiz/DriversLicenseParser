using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Minnesota : IParseableLicense
    {
        public string FullName => "Minnesota";

        public string Abbreviation => "MN";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636038;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}