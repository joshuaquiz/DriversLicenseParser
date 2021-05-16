using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class RhodeIsland : IParseableLicense
    {
        public string FullName => "Rhode Island";

        public string Abbreviation => "RI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636052;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}