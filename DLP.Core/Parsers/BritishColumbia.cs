using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class BritishColumbia : IParseableLicense
    {
        public string FullName => "British Columbia";

        public string Abbreviation => "BC";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636028;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}