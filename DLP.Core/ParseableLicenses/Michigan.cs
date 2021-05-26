using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.Parsers;

namespace DLP.Core.ParseableLicenses
{
    /// <summary>
    /// Represents a license from the US state of Michigan.
    /// </summary>
    public sealed class Michigan : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Michigan";

        /// <inheritdoc />
        public string Abbreviation => "MI";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636032;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data)
        {
            var driversLicenseData = ParsingHelpers.GetLicenseVersion(data) switch
            {
                LicenseVersion.Version2 => Version2StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version3 => Version3StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version4 => Version4StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version5 => Version5StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version6 => Version6StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version7 => Version7StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version8 => Version8StandardParser.ParseDriversLicenseData(data),
                _ => Version1StandardParser.ParseDriversLicenseData(data)
            };
            driversLicenseData.IssuingCountry = driversLicenseData.IssuingCountry == IssuingCountry.Unknown
                ? Country
                : driversLicenseData.IssuingCountry;
            return driversLicenseData;
        }
    }
}