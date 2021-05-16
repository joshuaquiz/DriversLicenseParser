using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Tennessee : IParseableLicense
    {
        public string FullName => "Tennessee";

        public string Abbreviation => "TN";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636053;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}