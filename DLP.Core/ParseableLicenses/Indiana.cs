using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Indiana : IParseableLicense
    {
        public string FullName => "Indiana";

        public string Abbreviation => "IN";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636037;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}