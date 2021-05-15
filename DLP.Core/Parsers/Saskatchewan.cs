using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Saskatchewan : IParseable
    {
        public string FullName => "Saskatchewan";

        public string Abbreviation => "SK";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636044;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}