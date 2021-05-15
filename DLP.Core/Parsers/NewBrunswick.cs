using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NewBrunswick : IParseable
    {
        public string FullName => "New Brunswick";

        public string Abbreviation => "NB";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636017;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}