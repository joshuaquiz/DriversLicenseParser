using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Utah : IParseableLicense
    {
        public string FullName => "Utah";

        public string Abbreviation => "UT";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636040;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}