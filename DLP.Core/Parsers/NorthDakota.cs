using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NorthDakota : IParseable
    {
        public string FullName => "North Dakota";

        public string Abbreviation => "ND";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636034;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}