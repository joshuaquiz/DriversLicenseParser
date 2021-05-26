using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Saskatchewan : IParseableLicense
    {
        public string FullName => "Saskatchewan";

        public string Abbreviation => "SK";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636044;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}