using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Georgia : IParseableLicense
    {
        public string FullName => "Georgia";

        public string Abbreviation => "GA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636055;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}