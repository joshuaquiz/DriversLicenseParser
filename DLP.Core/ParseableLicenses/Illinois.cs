using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Illinois : IParseableLicense
    {
        public string FullName => "Illinois";

        public string Abbreviation => "IL";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636035;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}