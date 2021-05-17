using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Hidalgo : IParseableLicense
    {
        public string FullName => "Hidalgo";

        public string Abbreviation => "HL";

        public string Country => "MEXICO";

        public int IssuerIdentificationNumber => 636057;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}