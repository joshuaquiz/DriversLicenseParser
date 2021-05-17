using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Florida : IParseableLicense
    {
        public string FullName => "Florida";

        public string Abbreviation => "FL";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636010;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}