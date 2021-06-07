using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Manitoba : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Manitoba";

        /// <inheritdoc />
        public string Abbreviation => "MB";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636048;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.BasicDriversLicenseParser(data, Country);
    }
}