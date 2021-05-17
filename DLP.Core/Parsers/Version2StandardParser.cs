using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public static class Version2StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x);
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version2StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version2StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version2StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version2StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = splitUpData.TryGetValue(Version2StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = splitUpData.TryGetValue(Version2StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = splitUpData.TryGetValue(Version2StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version2StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version2StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version2StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version2StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version2StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version2StandardMarkers.PostalCodeMarker),
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
                NameSuffix = splitUpData.TryGetValue(Version2StandardMarkers.NameSuffixMarker).ParseNameSuffix()
            };
        }

        public static class Version2StandardMarkers
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
            public const string MiddleNameTruncatedMarker = "DDG";
            public const string FirstNameTruncatedMarker = "DDF";
            public const string LastNameTruncatedMarker = "DDE";
            public const string SecondStreetAddressMarker = "DAH";
            public const string HairColorMarker = "DAZ";
            public const string PlaceOfBirthMarker = null;
            public const string AuditInformationMarker = null;
            public const string InventoryControlMarker = null;
            public const string LastNameAliasMarker = "DBN";
            public const string FirstNameAliasMarker = "DBG";
            public const string SuffixAliasMarker = null;
            public const string NameSuffixMarker = "DCU";
        }
    }
}