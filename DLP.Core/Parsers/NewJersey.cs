using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NewJersey : IParseableLicense
    {
        public string FullName => "New Jersey";

        public string Abbreviation => "NJ";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636036;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}