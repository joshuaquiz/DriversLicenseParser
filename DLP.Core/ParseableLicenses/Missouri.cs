using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Missouri : IParseableLicense
    {
        public string FullName => "Missouri";

        public string Abbreviation => "MO";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636030;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}