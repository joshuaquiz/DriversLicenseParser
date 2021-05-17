using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class NewMexico : IParseableLicense
    {
        public string FullName => "New Mexico";

        public string Abbreviation => "NM";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636009;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}