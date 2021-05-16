using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Hawaii : IParseableLicense
    {
        public string FullName => "Hawaii";

        public string Abbreviation => "HI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636047;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}