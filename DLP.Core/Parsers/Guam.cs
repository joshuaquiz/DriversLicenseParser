using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Guam : IParseable
    {
        public string FullName => "Guam";

        public string Abbreviation => "GU";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636019;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}