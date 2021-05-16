using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class StateDeptDiplomatic : IParseableLicense
    {
        public string FullName => "State Dept. (Diplomatic)";

        public string Abbreviation => "";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636027;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}