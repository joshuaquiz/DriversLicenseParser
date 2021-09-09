using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;

namespace DLP.Core.Parsers
{
    /// <summary>
    /// Represents an AAMVA Version 2 license.
    /// </summary>
    public static class Version2StandardParser
    {
        /// <summary>
        /// Parses an AAMVA Version 2 license.
        /// </summary>
        /// <param name="data">The incoming raw data.</param>
        /// <param name="splitUpData">The raw data split per this versions rules.</param>
        /// <returns><see cref="DriversLicenseData"/></returns>
        public static DriversLicenseData ParseDriversLicenseData(
            string data,
            out IReadOnlyDictionary<string, string> splitUpData)
        {
            splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x.RemoveFirstOccurrence(x.TrimToLength(3)));
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version2StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version2StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version2StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version2StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
                IssueDate = splitUpData.TryGetValue(Version2StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
                DateOfBirth = splitUpData.TryGetValue(Version2StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
                Gender = splitUpData.TryGetValue(Version2StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version2StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version2StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version2StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version2StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version2StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version2StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
                CustomerId = splitUpData.TryGetValue(Version2StandardMarkers.CustomerIdMarker),
                DocumentId = splitUpData.TryGetValue(Version2StandardMarkers.DocumentIdMarker),
                IssuingCountry = splitUpData.TryGetValue(Version2StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
                MiddleNameTruncated = splitUpData.TryGetValue(Version2StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
                FirstNameTruncated = splitUpData.TryGetValue(Version2StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
                LastNameTruncated = splitUpData.TryGetValue(Version2StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
                SecondStreetAddress = splitUpData.TryGetValue(Version2StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version2StandardMarkers.HairColorMarker).ParseHairColor(),
                LastNameAlias = splitUpData.TryGetValue(Version2StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version2StandardMarkers.FirstNameAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version2StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
                LicenseVersion = LicenseVersion.Version2
            };
        }

        /// <summary>
        /// AAMVA Version 2 license data codes
        /// </summary>
        /// <remarks>
        /// These codes are used to mark where in the text data a certain field starts.
        /// </remarks>
        public static class Version2StandardMarkers
        {
            /// <summary>
            /// DAA
            /// </summary>
            public const string DriverLicenseNameMarker = "DAA";

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
            /// DDG
            /// </summary>
            public const string MiddleNameTruncatedMarker = "DDG";

            /// <summary>
            /// DDF
            /// </summary>
            public const string FirstNameTruncatedMarker = "DDF";

            /// <summary>
            /// DDE
            /// </summary>
            public const string LastNameTruncatedMarker = "DDE";

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
            public const string PlaceOfBirthMarker = null;

            /// <summary>
            /// Not used in this version.
            /// </summary>
            public const string AuditInformationMarker = null;

            /// <summary>
            /// Not used in this version.
            /// </summary>
            public const string InventoryControlMarker = null;

            /// <summary>
            /// DBN
            /// </summary>
            public const string LastNameAliasMarker = "DBN";

            /// <summary>
            /// DBG
            /// </summary>
            public const string FirstNameAliasMarker = "DBG";

            /// <summary>
            /// Not used in this version.
            /// </summary>
            public const string SuffixAliasMarker = null;

            /// <summary>
            /// DCU
            /// </summary>
            public const string NameSuffixMarker = "DCU";
        }
    }
}