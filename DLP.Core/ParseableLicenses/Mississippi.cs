using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Mississippi : IParseableLicense
    {
        public string FullName => "Mississippi";

        public string Abbreviation => "MS";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636051;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}