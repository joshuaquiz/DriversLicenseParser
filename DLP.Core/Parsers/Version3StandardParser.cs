using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;
// ReSharper disable UnusedMember.Global

namespace DLP.Core.Parsers;

/// <summary>
/// Represents an AAMVA Version 3 license.
/// </summary>
public static class Version3StandardParser
{
    /// <summary>
    /// Parses an AAMVA Version 3 license.
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
            // Pulling the "Last" name because the first name is where the last name should be.
            FirstName = splitUpData.ParseDriverLicenseName(Version3StandardMarkers.FirstNameMarker, NamePart.LastName),
            LastName = splitUpData.TryGetValue(Version3StandardMarkers.LastNameMarker),
            MiddleName = splitUpData.TryGetValue(Version3StandardMarkers.MiddleNameMarker)
                         ?? splitUpData.ParseDriverLicenseName(Version3StandardMarkers.FirstNameMarker, NamePart.ShortMiddleName),
            ExpirationDate = splitUpData.TryGetValue(Version3StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
            IssueDate = splitUpData.TryGetValue(Version3StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
            DateOfBirth = splitUpData.TryGetValue(Version3StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
            Gender = splitUpData.TryGetValue(Version3StandardMarkers.GenderMarker).ParseGender(),
            EyeColor = splitUpData.TryGetValue(Version3StandardMarkers.EyeColorMarker).ParseEyeColor(),
            Height = splitUpData.TryGetValue(Version3StandardMarkers.HeightMarker).ParseHeightInInches(),
            StreetAddress = splitUpData.TryGetValue(Version3StandardMarkers.StreetAddressMarker),
            City = splitUpData.TryGetValue(Version3StandardMarkers.CityMarker),
            State = splitUpData.TryGetValue(Version3StandardMarkers.StateMarker),
            PostalCode = splitUpData.TryGetValue(Version3StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
            CustomerId = splitUpData.TryGetValue(Version3StandardMarkers.CustomerIdMarker),
            DocumentId = splitUpData.TryGetValue(Version3StandardMarkers.DocumentIdMarker),
            IssuingCountry = splitUpData.TryGetValue(Version3StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
            SecondStreetAddress = splitUpData.TryGetValue(Version3StandardMarkers.SecondStreetAddressMarker),
            HairColor = splitUpData.TryGetValue(Version3StandardMarkers.HairColorMarker).ParseHairColor(),
            PlaceOfBirth = splitUpData.TryGetValue(Version3StandardMarkers.PlaceOfBirthMarker),
            AuditInformation = splitUpData.TryGetValue(Version3StandardMarkers.AuditInformationMarker),
            InventoryControl = splitUpData.TryGetValue(Version3StandardMarkers.InventoryControlMarker),
            LastNameAlias = splitUpData.TryGetValue(Version3StandardMarkers.LastNameAliasMarker),
            FirstNameAlias = splitUpData.TryGetValue(Version3StandardMarkers.FirstNameAliasMarker),
            SuffixAlias = splitUpData.TryGetValue(Version3StandardMarkers.SuffixAliasMarker),
            NameSuffix = splitUpData.TryGetValue(Version3StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
            LicenseVersion = LicenseVersion.Version3
        };
    }

    /// <summary>
    /// AAMVA Version 3 license data codes
    /// </summary>
    /// <remarks>
    /// These codes are used to mark where in the text data a certain field starts.
    /// </remarks>
    public static class Version3StandardMarkers
    {
        /// <summary>
        /// DCT
        /// </summary>
        public const string FirstNameMarker = "DCT";

        /// <summary>
        /// DCS
        /// </summary>
        public const string LastNameMarker = "DCS";

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
        /// DAQ
        /// </summary>
        public const string CustomerIdMarker = "DAQ";

        /// <summary>
        /// DCF
        /// </summary>
        public const string DocumentIdMarker = "DCF";

        /// <summary>
        /// DCG
        /// </summary>
        public const string IssuingCountryMarker = "DCG";

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
        /// DCI
        /// </summary>
        public const string PlaceOfBirthMarker = "DCI";

        /// <summary>
        /// DCJ
        /// </summary>
        public const string AuditInformationMarker = "DCJ";

        /// <summary>
        /// DCK
        /// </summary>
        public const string InventoryControlMarker = "DCK";

        /// <summary>
        /// DBN
        /// </summary>
        public const string LastNameAliasMarker = "DBN";

        /// <summary>
        /// DBG
        /// </summary>
        public const string FirstNameAliasMarker = "DBG";

        /// <summary>
        /// DBS
        /// </summary>
        public const string SuffixAliasMarker = "DBS";

        /// <summary>
        /// DCU
        /// </summary>
        public const string NameSuffixMarker = "DCU";
    }
}