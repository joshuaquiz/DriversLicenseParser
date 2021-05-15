using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NewfoundlandAndLabrador : IParseable
    {
        public string FullName => "Newfoundland and Labrador";

        public string Abbreviation => "NL";

        public string Country => "CANADA";

        public int IssuerIdentificationNumber => 636016;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}