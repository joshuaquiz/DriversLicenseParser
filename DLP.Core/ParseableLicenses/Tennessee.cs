using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Tennessee : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Tennessee";

        /// <inheritdoc />
        public string Abbreviation => "TN";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636053;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.BasicDriversLicenseParser(data, Country);
    }
}