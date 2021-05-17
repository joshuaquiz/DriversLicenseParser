using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Maryland : IParseableLicense
    {
        public string FullName => "Maryland";

        public string Abbreviation => "MD";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636003;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}