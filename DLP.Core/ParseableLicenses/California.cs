using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class California : IParseableLicense
    {
        public string FullName => "California";

        public string Abbreviation => "CA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636014;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}