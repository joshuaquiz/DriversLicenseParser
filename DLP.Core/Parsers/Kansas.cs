using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Kansas : IParseable
    {
        public string FullName => "Kansas";

        public string Abbreviation => "KS";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636022;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}