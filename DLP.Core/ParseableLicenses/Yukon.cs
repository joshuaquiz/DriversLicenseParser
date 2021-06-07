using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Yukon : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Yukon";

        /// <inheritdoc />
        public string Abbreviation => "YT";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 604429;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.BasicDriversLicenseParser(data, Country);
    }
}