using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Massachusetts : IParseableLicense
    {
        public string FullName => "Massachusetts";

        public string Abbreviation => "MA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636002;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}