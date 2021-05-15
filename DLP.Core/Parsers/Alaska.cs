using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Alaska : IParseable
    {
        public string FullName => "Alaska";

        public string Abbreviation => "AK";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636059;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}