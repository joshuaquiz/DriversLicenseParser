using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Idaho : IParseableLicense
    {
        public string FullName => "Idaho";

        public string Abbreviation => "ID";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636050;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}