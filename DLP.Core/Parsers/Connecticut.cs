using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Connecticut : IParseable
    {
        public string FullName => "Connecticut";

        public string Abbreviation => "CT";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636006;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}