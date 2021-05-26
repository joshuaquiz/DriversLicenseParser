using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class AmericanSamoa : IParseableLicense
    {
        public string FullName => "American Samoa";

        public string Abbreviation => "AS";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 604427;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}