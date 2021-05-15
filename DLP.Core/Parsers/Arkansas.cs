using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Arkansas : IParseable
    {
        public string FullName => "Arkansas";

        public string Abbreviation => "AR";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636021;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}