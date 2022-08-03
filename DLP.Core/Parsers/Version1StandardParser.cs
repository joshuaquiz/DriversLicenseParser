using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;
// ReSharper disable UnusedMember.Global

namespace DLP.Core.Parsers;

/// <summary>
/// Represents an AAMVA Version 1 license.
/// </summary>
public static class Version1StandardParser
{
    /// <summary>
    /// Parses an AAMVA Version 1 license.
    /// </summary>
    /// <param name="data">The incoming raw data.</param>
    /// <param name="splitUpData">The raw data split per this versions rules.</param>
    /// <returns><see cref="DriversLicenseData"/></returns>
    public static DriversLicenseData ParseDriversLicenseData(
        string? data,
        out IReadOnlyDictionary<string, string?> splitUpData)
    {
        splitUpData = ParsingHelpers.SplitLicenseString(data);
        return new DriversLicenseData
        {
            FirstName = splitUpData.TryGetValue(Version1StandardMarkers.FirstNameMarker)
                        ?? splitUpData.ParseDriverLicenseName(Version1StandardMarkers.DriverLicenseNameMarker, NamePart.FirstName),
            LastName = splitUpData.TryGetValue(Version1StandardMarkers.LastNameMarker)
                       ?? splitUpData.ParseDriverLicenseName(Version1StandardMarkers.DriverLicenseNameMarker, NamePart.LastName),
            MiddleName = splitUpData.TryGetValue(Version1StandardMarkers.MiddleNameMarker)
                         ?? splitUpData.ParseDriverLicenseName(Version1StandardMarkers.DriverLicenseNameMarker, NamePart.MiddleName),
            ExpirationDate = splitUpData.TryGetValue(Version1StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
            IssueDate = splitUpData.TryGetValue(Version1StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
            DateOfBirth = splitUpData.TryGetValue(Version1StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
            Gender = splitUpData.TryGetValue(Version1StandardMarkers.GenderMarker).ParseGender(),
            EyeColor = splitUpData.TryGetValue(Version1StandardMarkers.EyeColorMarker).ParseEyeColor(),
            Height = splitUpData.TryGetValue(Version1StandardMarkers.HeightMarker).ParseHeightInInches(),
            StreetAddress = splitUpData.TryGetValue(Version1StandardMarkers.StreetAddressMarker),
            City = splitUpData.TryGetValue(Version1StandardMarkers.CityMarker),
            State = splitUpData.TryGetValue(Version1StandardMarkers.StateMarker),
            PostalCode = splitUpData.TryGetValue(Version1StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
            CustomerId = splitUpData.TryGetValue(Version1StandardMarkers.CustomerIdMarker),
            SecondStreetAddress = splitUpData.TryGetValue(Version1StandardMarkers.SecondStreetAddressMarker),
            HairColor = splitUpData.TryGetValue(Version1StandardMarkers.HairColorMarker).ParseHairColor(),
            LastNameAlias = splitUpData.TryGetValue(Version1StandardMarkers.LastNameAliasMarker),
            FirstNameAlias = splitUpData.TryGetValue(Version1StandardMarkers.FirstNameAliasMarker),
            SuffixAlias = splitUpData.TryGetValue(Version1StandardMarkers.SuffixAliasMarker),
            NameSuffix = (splitUpData.TryGetValue(Version1StandardMarkers.NameSuffixMarker)
                          ?? splitUpData.ParseDriverLicenseName(Version1StandardMarkers.DriverLicenseNameMarker, NamePart.Suffix)).ParseNameSuffix(),
            InventoryControl = splitUpData.TryGetValue(Version1StandardMarkers.InventoryControlMarker),
            LicenseVersion = LicenseVersion.Version1
        };
    }

    /// <summary>
    /// AAMVA Version 1 license data codes
    /// </summary>
    /// <remarks>
    /// These codes are used to mark where in the text data a certain field starts.
    /// </remarks>
    public static class Version1StandardMarkers
    {
        /// <summary>
        /// DAA
        /// </summary>
        public const string DriverLicenseNameMarker = "DAA";

        /// <summary>
        /// DAC
        /// </summary>
        public const string FirstNameMarker = "DAC";

        /// <summary>
        /// DAB
        /// </summary>
        public const string LastNameMarker = "DAB";

        /// <summary>
        /// DAD
        /// </summary>
        public const string MiddleNameMarker = "DAD";

        /// <summary>
        /// DBA
        /// </summary>
        public const string ExpirationDateMarker = "DBA";

        /// <summary>
        /// DBD
        /// </summary>
        public const string IssueDateMarker = "DBD";

        /// <summary>
        /// DBB
        /// </summary>
        public const string DateOfBirthMarker = "DBB";

        /// <summary>
        /// DBC
        /// </summary>
        public const string GenderMarker = "DBC";

        /// <summary>
        /// DAY
        /// </summary>
        public const string EyeColorMarker = "DAY";

        /// <summary>
        /// DAU
        /// </summary>
        public const string HeightMarker = "DAU";

        /// <summary>
        /// DAG
        /// </summary>
        public const string StreetAddressMarker = "DAG";

        /// <summary>
        /// DAI
        /// </summary>
        public const string CityMarker = "DAI";

        /// <summary>
        /// DAJ
        /// </summary>
        public const string StateMarker = "DAJ";

        /// <summary>
        /// DAK
        /// </summary>
        public const string PostalCodeMarker = "DAK";

        /// <summary>
        /// DBJ
        /// </summary>
        public const string CustomerIdMarker = "DBJ";

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string DocumentIdMarker = null!;

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string IssuingCountryMarker = null!;

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string MiddleNameTruncatedMarker = null!;

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string FirstNameTruncatedMarker = null!;

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string LastNameTruncatedMarker = null!;

        /// <summary>
        /// DAH
        /// </summary>
        public const string SecondStreetAddressMarker = "DAH";

        /// <summary>
        /// DAZ
        /// </summary>
        public const string HairColorMarker = "DAZ";

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string PlaceOfBirthMarker = null!;

        /// <summary>
        /// Not used in this version.
        /// </summary>
        public const string AuditInformationMarker = null!;

        /// <summary>
        /// DL_
        /// </summary>
        public const string InventoryControlMarker = "DL_";

        /// <summary>
        /// DBO
        /// </summary>
        public const string LastNameAliasMarker = "DBO";

        /// <summary>
        /// DBP
        /// </summary>
        public const string FirstNameAliasMarker = "DBP";

        /// <summary>
        /// DBR
        /// </summary>
        public const string SuffixAliasMarker = "DBR";

        /// <summary>
        /// DBN
        /// </summary>
        public const string NameSuffixMarker = "DBN";
    }
}