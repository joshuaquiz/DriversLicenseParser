using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NovaScotia : IParseable
    {
        public string FullName => "Nova Scotia";

        public string Abbreviation => "NS";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636013;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}