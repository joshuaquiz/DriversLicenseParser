using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Yukon : IParseableLicense
    {
        public string FullName => "Yukon";

        public string Abbreviation => "YT";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604429;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}