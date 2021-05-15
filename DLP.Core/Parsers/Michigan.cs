using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Michigan : IParseable
    {
        public string FullName => "Michigan";

        public string Abbreviation => "MI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636032;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}