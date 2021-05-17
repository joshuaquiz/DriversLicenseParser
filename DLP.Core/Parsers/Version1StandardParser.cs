using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public static class Version1StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x.Substring(2));
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version1StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version1StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version1StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version1StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = splitUpData.TryGetValue(Version1StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = splitUpData.TryGetValue(Version1StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = splitUpData.TryGetValue(Version1StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version1StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version1StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version1StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version1StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version1StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version1StandardMarkers.PostalCodeMarker),
                CustomerId = splitUpData.TryGetValue(Version1StandardMarkers.CustomerIdMarker),
                SecondStreetAddress = splitUpData.TryGetValue(Version1StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version1StandardMarkers.HairColorMarker).ParseHairColor(),
                LastNameAlias = splitUpData.TryGetValue(Version1StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version1StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = splitUpData.TryGetValue(Version1StandardMarkers.SuffixAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version1StandardMarkers.NameSuffixMarker).ParseNameSuffix()
            };
        }

        public static class Version1StandardMarkers
        {
            public const string FirstNameMarker = "DAC";
            public const string LastNameMarker = "DAB";
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
            public const string CustomerIdMarker = "DBJ";
            public const string DocumentIdMarker = null;
            public const string IssuingCountryMarker = null;
            public const string MiddleNameTruncatedMarker = null;
            public const string FirstNameTruncatedMarker = null;
            public const string LastNameTruncatedMarker = null;
            public const string SecondStreetAddressMarker = "DAH";
            public const string HairColorMarker = "DAZ";
            public const string PlaceOfBirthMarker = null;
            public const string AuditInformationMarker = null;
            public const string InventoryControlMarker = null;
            public const string LastNameAliasMarker = "DBO";
            public const string FirstNameAliasMarker = "DBP";
            public const string SuffixAliasMarker = "DBR";
            public const string NameSuffixMarker = "DBN";
        }
    }
}