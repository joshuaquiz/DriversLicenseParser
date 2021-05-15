using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Pennsylvania : IParseable
    {
        public string FullName => "Pennsylvania";

        public string Abbreviation => "PA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636025;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}