using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Washington : IParseableLicense
    {
        public string FullName => "Washington";

        public string Abbreviation => "WA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636045;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}