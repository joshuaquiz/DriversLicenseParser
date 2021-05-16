using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Pennsylvania : IParseableLicense
    {
        public string FullName => "Pennsylvania";

        public string Abbreviation => "PA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636025;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}