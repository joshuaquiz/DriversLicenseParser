using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class BritishColumbia : IParseableLicense
    {
        public string FullName => "British Columbia";

        public string Abbreviation => "BC";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636028;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}