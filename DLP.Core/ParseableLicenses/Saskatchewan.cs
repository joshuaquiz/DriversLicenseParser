using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Saskatchewan : IParseableLicense
    {
        public string FullName => "Saskatchewan";

        public string Abbreviation => "SK";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636044;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}