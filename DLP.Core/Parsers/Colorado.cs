using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Colorado : IParseable
    {
        public string FullName => "Colorado";

        public string Abbreviation => "CO";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636020;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}