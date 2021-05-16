using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Oregon : IParseableLicense
    {
        public string FullName => "Oregon";

        public string Abbreviation => "OR";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636029;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}