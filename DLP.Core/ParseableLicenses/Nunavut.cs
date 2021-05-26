using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Nunavut : IParseableLicense
    {
        public string FullName => "Nunavut";

        public string Abbreviation => "NU";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 604433;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}