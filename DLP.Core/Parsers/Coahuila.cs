using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Coahuila : IParseable
    {
        public string FullName => "Coahuila";

        public string Abbreviation => "CU";

        public string Country => "MEXICO";

        public int IssuerIdentificationNumber => 636056;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}