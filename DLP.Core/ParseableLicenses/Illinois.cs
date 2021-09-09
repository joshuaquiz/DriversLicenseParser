using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.Parsers;
using System;

namespace DLP.Core.ParseableLicenses
{
    /// <summary>
    /// Represents a license from the US state of Illinois.
    /// </summary>
    public sealed class Illinois : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Illinois";

        /// <inheritdoc />
        public string Abbreviation => "IL";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636035;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data)
        {
            var driversLicenseData = ParsingHelpers.BasicDriversLicenseParser(
                data,
                Country,
                out var splitUpData);
            if (driversLicenseData.LicenseVersion == LicenseVersion.Version2)
            {
                if (string.IsNullOrWhiteSpace(driversLicenseData.LastName)
                    && splitUpData.TryGetValue("ANS", out var ansiData)
                    && ansiData.Contains(Version2StandardParser.Version2StandardMarkers.DriverLicenseNameMarker))
                {
                    var indexOfNameStart = ansiData.IndexOf(
                        Version2StandardParser.Version2StandardMarkers.DriverLicenseNameMarker,
                        StringComparison.InvariantCultureIgnoreCase) + 3;
                    var nameData = ansiData[indexOfNameStart..];
                    driversLicenseData.FirstName = nameData.ParseDriverLicenseName(NamePart.FirstName);
                    driversLicenseData.MiddleName = nameData.ParseDriverLicenseName(NamePart.MiddleName);
                    driversLicenseData.LastName = nameData.ParseDriverLicenseName(NamePart.LastName);
                }
            }

            return driversLicenseData;
        }
    }
}