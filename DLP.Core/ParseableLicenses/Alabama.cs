using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{

    public sealed class Alabama : IParseableLicense
    {
        public string FullName => "Alabama";

        public string Abbreviation => "AL";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636033;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }

}