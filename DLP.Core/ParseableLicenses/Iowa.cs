using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Iowa : IParseableLicense
    {
        public string FullName => "Iowa";

        public string Abbreviation => "IA";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636018;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}