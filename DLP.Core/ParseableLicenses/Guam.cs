using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Guam : IParseableLicense
    {
        public string FullName => "Guam";

        public string Abbreviation => "GU";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636019;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}