using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Wisconsin : IParseable
    {
        public string FullName => "Wisconsin";

        public string Abbreviation => "WI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636031;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}