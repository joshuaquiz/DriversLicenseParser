using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class Quebec : IParseable
    {
        public string FullName => "Quebec";

        public string Abbreviation => "QC";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604428;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}