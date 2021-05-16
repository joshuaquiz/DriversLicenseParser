using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Nevada : IParseableLicense
    {
        public string FullName => "Nevada";

        public string Abbreviation => "NV";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636049;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}