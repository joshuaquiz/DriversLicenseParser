using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Virginia : IParseableLicense
    {
        public string FullName => "Virginia";

        public string Abbreviation => "VA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636000;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}