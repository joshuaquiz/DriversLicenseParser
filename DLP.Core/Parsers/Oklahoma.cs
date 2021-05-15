using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Oklahoma : IParseable
    {
        public string FullName => "Oklahoma";

        public string Abbreviation => "OK";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636058;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}