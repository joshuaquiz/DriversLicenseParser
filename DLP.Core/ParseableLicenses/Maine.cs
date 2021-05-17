using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Maine : IParseableLicense
    {
        public string FullName => "Maine";

        public string Abbreviation => "ME";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636041;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}