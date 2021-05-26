using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.Parsers
{
    public static class Version6StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x.RemoveFirstOccurrence(x.TrimToLength(3)));
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version6StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version6StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version6StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version6StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = splitUpData.TryGetValue(Version6StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = splitUpData.TryGetValue(Version6StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = splitUpData.TryGetValue(Version6StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version6StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version6StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version6StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version6StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version6StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version6StandardMarkers.PostalCodeMarker),
                CustomerId = splitUpData.TryGetValue(Version6StandardMarkers.CustomerIdMarker),
                DocumentId = splitUpData.TryGetValue(Version6StandardMarkers.DocumentIdMarker),
                IssuingCountry = splitUpData.TryGetValue(Version6StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
                MiddleNameTruncated = splitUpData.TryGetValue(Version6StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
                FirstNameTruncated = splitUpData.TryGetValue(Version6StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
                LastNameTruncated = splitUpData.TryGetValue(Version6StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
                SecondStreetAddress = splitUpData.TryGetValue(Version6StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version6StandardMarkers.HairColorMarker).ParseHairColor(),
                PlaceOfBirth = splitUpData.TryGetValue(Version6StandardMarkers.PlaceOfBirthMarker),
                AuditInformation = splitUpData.TryGetValue(Version6StandardMarkers.AuditInformationMarker),
                InventoryControl = splitUpData.TryGetValue(Version6StandardMarkers.InventoryControlMarker),
                LastNameAlias = splitUpData.TryGetValue(Version6StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version6StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = splitUpData.TryGetValue(Version6StandardMarkers.SuffixAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version6StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
                LicenseVersion = LicenseVersion.Version6
            };
        }

        public static class Version6StandardMarkers
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