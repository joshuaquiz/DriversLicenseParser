using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Vermont : IParseableLicense
    {
        public string FullName => "Vermont";

        public string Abbreviation => "VT";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636024;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}