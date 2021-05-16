using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Wisconsin : IParseableLicense
    {
        public string FullName => "Wisconsin";

        public string Abbreviation => "WI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636031;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}