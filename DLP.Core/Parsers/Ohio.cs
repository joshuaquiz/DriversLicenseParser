using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Ohio : IParseable
    {
        public string FullName => "Ohio";

        public string Abbreviation => "OH";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636023;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}