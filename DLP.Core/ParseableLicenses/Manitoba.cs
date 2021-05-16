using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Manitoba : IParseableLicense
    {
        public string FullName => "Manitoba";

        public string Abbreviation => "MB";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636048;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}