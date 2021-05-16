using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Texas : IParseableLicense
    {
        public string FullName => "Texas";

        public string Abbreviation => "TX";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636015;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}