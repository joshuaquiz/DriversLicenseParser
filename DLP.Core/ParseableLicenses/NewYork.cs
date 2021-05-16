using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class NewYork : IParseableLicense
    {
        public string FullName => "New York";

        public string Abbreviation => "NY";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636001;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}