using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public interface IParseable
    {
        public string FullName { get; }

        public string Abbreviation { get; }

        public string Country { get; }

        public int IssuerIdentificationNumber { get; }

        public bool IsDataFromEntity(string data);

        public DriversLicenseData ParseData(string data);
    }
}