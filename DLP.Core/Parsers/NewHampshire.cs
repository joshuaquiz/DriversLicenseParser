using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public sealed class NewHampshire : IParseableLicense
    {
        public string FullName => "New Hampshire";

        public string Abbreviation => "NH";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636039;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}