using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Massachusetts : IParseable
    {
        public string FullName => "Massachusetts";

        public string Abbreviation => "MA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636002;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}