using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Nunavut : IParseableLicense
    {
        public string FullName => "Nunavut";

        public string Abbreviation => "NU";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604433;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}