using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Hidalgo : IParseable
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