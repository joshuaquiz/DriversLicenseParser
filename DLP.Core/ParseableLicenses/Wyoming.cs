using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Wyoming : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Wyoming";

        /// <inheritdoc />
        public string Abbreviation => "WY";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636060;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.BasicDriversLicenseParser(data, Country);
    }
}