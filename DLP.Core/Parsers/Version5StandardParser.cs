using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;

namespace DLP.Core.Parsers
{
    public static class Version5StandardParser
    {
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
                FirstName = splitUpData.TryGetValue(Version5StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version5StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version5StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version5StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
                IssueDate = splitUpData.TryGetValue(Version5StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
                DateOfBirth = splitUpData.TryGetValue(Version5StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
                Gender = splitUpData.TryGetValue(Version5StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version5StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version5StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version5StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version5StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version5StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version5StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
                CustomerId = splitUpData.TryGetValue(Version5StandardMarkers.CustomerIdMarker),
                DocumentId = splitUpData.TryGetValue(Version5StandardMarkers.DocumentIdMarker),
                IssuingCountry = splitUpData.TryGetValue(Version5StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
                MiddleNameTruncated = splitUpData.TryGetValue(Version5StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
                FirstNameTruncated = splitUpData.TryGetValue(Version5StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
                LastNameTruncated = splitUpData.TryGetValue(Version5StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
                SecondStreetAddress = splitUpData.TryGetValue(Version5StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version5StandardMarkers.HairColorMarker).ParseHairColor(),
                PlaceOfBirth = splitUpData.TryGetValue(Version5StandardMarkers.PlaceOfBirthMarker),
                AuditInformation = splitUpData.TryGetValue(Version5StandardMarkers.AuditInformationMarker),
                InventoryControl = splitUpData.TryGetValue(Version5StandardMarkers.InventoryControlMarker),
                LastNameAlias = splitUpData.TryGetValue(Version5StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version5StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = splitUpData.TryGetValue(Version5StandardMarkers.SuffixAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version5StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
                LicenseVersion = LicenseVersion.Version5
            };
        }

        public static class Version5StandardMarkers
        {
            public const string FirstNameMarker = "DAC";
            public const string LastNameMarker = "DCS";
            public const string MiddleNameMarker = "DAD";
            public const string ExpirationDateMarker = "DBA";
            public const string IssueDateMarker = "DBD";
            public const string DateOfBirthMarker = "DBB";
            public const string GenderMarker = "DBC";
            public const string EyeColorMarker = "DAY";
            public const string HeightMarker = "DAU";
            public const string StreetAddressMarker = "DAG";
            public const string CityMarker = "DAI";
            public const string StateMarker = "DAJ";
            public const string PostalCodeMarker = "DAK";
            public const string CustomerIdMarker = "DAQ";
            public const string DocumentIdMarker = "DCF";
            public const string IssuingCountryMarker = "DCG";
            public const string MiddleNameTruncatedMarker = "DDG";
            public const string FirstNameTruncatedMarker = "DDF";
            public const string LastNameTruncatedMarker = "DDE";
            public const string SecondStreetAddressMarker = "DAH";
            public const string HairColorMarker = "DAZ";
            public const string PlaceOfBirthMarker = "DCI";
            public const string AuditInformationMarker = "DCJ";
            public const string InventoryControlMarker = "DCK";
            public const string LastNameAliasMarker = "DBN";
            public const string FirstNameAliasMarker = "DBG";
            public const string SuffixAliasMarker = "DBS";
            public const string NameSuffixMarker = "DCU";
        }
    }
}