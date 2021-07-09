using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Coahuila : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Coahuila";

        /// <inheritdoc />
        public string Abbreviation => "CU";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Mexico;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636056;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
    }
}