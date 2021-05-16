using System.Collections.Generic;
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
                .ToDictionary(x => x.TrimToLength(3), x => x);
            var driversLicenseData = new DriversLicenseData
            {
                FirstName = TryGetValue(splitUpData, Version1StandardMarkers.FirstNameMarker),
                LastName = TryGetValue(splitUpData, Version1StandardMarkers.LastNameMarker),
                MiddleName = TryGetValue(splitUpData, Version1StandardMarkers.MiddleNameMarker),
                ExpirationDate = TryGetValue(splitUpData, Version1StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = TryGetValue(splitUpData, Version1StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = TryGetValue(splitUpData, Version1StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = TryGetValue(splitUpData, Version1StandardMarkers.GenderMarker),
                EyeColor = TryGetValue(splitUpData, Version1StandardMarkers.EyeColorMarker),
                Height = TryGetValue(splitUpData, Version1StandardMarkers.HeightMarker),
                StreetAddress = TryGetValue(splitUpData, Version1StandardMarkers.StreetAddressMarker),
                City = TryGetValue(splitUpData, Version1StandardMarkers.CityMarker),
                State = TryGetValue(splitUpData, Version1StandardMarkers.StateMarker),
                PostalCode = TryGetValue(splitUpData, Version1StandardMarkers.PostalCodeMarker),
                CustomerId = TryGetValue(splitUpData, Version1StandardMarkers.CustomerIdMarker),
                SecondStreetAddress = TryGetValue(splitUpData, Version1StandardMarkers.SecondStreetAddressMarker),
                HairColor = TryGetValue(splitUpData, Version1StandardMarkers.HairColorMarker),
                LastNameAlias = TryGetValue(splitUpData, Version1StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = TryGetValue(splitUpData, Version1StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = TryGetValue(splitUpData, Version1StandardMarkers.SuffixAliasMarker),
                NameSuffix = TryGetValue(splitUpData, Version1StandardMarkers.NameSuffixMarker)
            };
            return driversLicenseData;
        }

        public static string TryGetValue(IReadOnlyDictionary<string, string> data, string key) =>
            data.TryGetValue(key, out var value)
                ? value
                : null;

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