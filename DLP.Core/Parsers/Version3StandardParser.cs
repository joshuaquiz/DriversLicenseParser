using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.Parsers
{
    public static class Version3StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x.RemoveFirstOccurrence(x.TrimToLength(3)));
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version3StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version3StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version3StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version3StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = splitUpData.TryGetValue(Version3StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = splitUpData.TryGetValue(Version3StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = splitUpData.TryGetValue(Version3StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version3StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version3StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version3StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version3StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version3StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version3StandardMarkers.PostalCodeMarker),
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

        public static class Version3StandardMarkers
        {
            public const string FirstNameMarker = "DCT";
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
            public const string MiddleNameTruncatedMarker = null;
            public const string FirstNameTruncatedMarker = null;
            public const string LastNameTruncatedMarker = null;
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