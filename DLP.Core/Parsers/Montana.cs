using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Montana : IParseable
    {
        public string FullName => "Montana";

        public string Abbreviation => "MT";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636008;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}