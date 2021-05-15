using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Ontario : IParseable
    {
        public string FullName => "Ontario";

        public string Abbreviation => "ON";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636012;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}