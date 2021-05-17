using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Louisiana : IParseableLicense
    {
        public string FullName => "Louisiana";

        public string Abbreviation => "LA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636007;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}