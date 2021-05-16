using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class PrinceEdwardIsland : IParseableLicense
    {
        public string FullName => "Prince Edward Island ";

        public string Abbreviation => "PE";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 604426;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}