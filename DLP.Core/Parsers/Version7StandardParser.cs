using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.Parsers
{
    public static class Version7StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x.RemoveFirstOccurrence(x.TrimToLength(3)));
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version7StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version7StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version7StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version7StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
                IssueDate = splitUpData.TryGetValue(Version7StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
                DateOfBirth = splitUpData.TryGetValue(Version7StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
                Gender = splitUpData.TryGetValue(Version7StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version7StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version7StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version7StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version7StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version7StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version7StandardMarkers.PostalCodeMarker),
                CustomerId = splitUpData.TryGetValue(Version7StandardMarkers.CustomerIdMarker),
                DocumentId = splitUpData.TryGetValue(Version7StandardMarkers.DocumentIdMarker),
                IssuingCountry = splitUpData.TryGetValue(Version7StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
                MiddleNameTruncated = splitUpData.TryGetValue(Version7StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
                FirstNameTruncated = splitUpData.TryGetValue(Version7StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
                LastNameTruncated = splitUpData.TryGetValue(Version7StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
                SecondStreetAddress = splitUpData.TryGetValue(Version7StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version7StandardMarkers.HairColorMarker).ParseHairColor(),
                PlaceOfBirth = splitUpData.TryGetValue(Version7StandardMarkers.PlaceOfBirthMarker),
                AuditInformation = splitUpData.TryGetValue(Version7StandardMarkers.AuditInformationMarker),
                InventoryControl = splitUpData.TryGetValue(Version7StandardMarkers.InventoryControlMarker),
                LastNameAlias = splitUpData.TryGetValue(Version7StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version7StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = splitUpData.TryGetValue(Version7StandardMarkers.SuffixAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version7StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
                LicenseVersion = LicenseVersion.Version7
            };
        }

        public static class Version7StandardMarkers
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