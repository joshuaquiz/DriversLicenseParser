using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Nebraska : IParseable
    {
        public string FullName => "Nebraska";

        public string Abbreviation => "NE";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636054;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}