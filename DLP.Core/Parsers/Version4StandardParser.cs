﻿using System.Linq;
using DLP.Core.Helpers;
using DLP.Core.Models;

namespace DLP.Core.Parsers
{
    public static class Version4StandardParser
    {
        public static DriversLicenseData ParseDriversLicenseData(string data)
        {
            var splitUpData = data
                .Split('\r', '\n')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToDictionary(x => x.TrimToLength(3), x => x);
            return new DriversLicenseData
            {
                FirstName = splitUpData.TryGetValue(Version4StandardMarkers.FirstNameMarker),
                LastName = splitUpData.TryGetValue(Version4StandardMarkers.LastNameMarker),
                MiddleName = splitUpData.TryGetValue(Version4StandardMarkers.MiddleNameMarker),
                ExpirationDate = splitUpData.TryGetValue(Version4StandardMarkers.ExpirationDateMarker).ParseDateTimeMonthDayYear(),
                IssueDate = splitUpData.TryGetValue(Version4StandardMarkers.IssueDateMarker).ParseDateTimeMonthDayYear(),
                DateOfBirth = splitUpData.TryGetValue(Version4StandardMarkers.DateOfBirthMarker).ParseDateTimeMonthDayYear(),
                Gender = splitUpData.TryGetValue(Version4StandardMarkers.GenderMarker).ParseGender(),
                EyeColor = splitUpData.TryGetValue(Version4StandardMarkers.EyeColorMarker).ParseEyeColor(),
                Height = splitUpData.TryGetValue(Version4StandardMarkers.HeightMarker).ParseHeightInInches(),
                StreetAddress = splitUpData.TryGetValue(Version4StandardMarkers.StreetAddressMarker),
                City = splitUpData.TryGetValue(Version4StandardMarkers.CityMarker),
                State = splitUpData.TryGetValue(Version4StandardMarkers.StateMarker),
                PostalCode = splitUpData.TryGetValue(Version4StandardMarkers.PostalCodeMarker),
                CustomerId = splitUpData.TryGetValue(Version4StandardMarkers.CustomerIdMarker),
                DocumentId = splitUpData.TryGetValue(Version4StandardMarkers.DocumentIdMarker),
                IssuingCountry = splitUpData.TryGetValue(Version4StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
                MiddleNameTruncated = splitUpData.TryGetValue(Version4StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
                FirstNameTruncated = splitUpData.TryGetValue(Version4StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
                LastNameTruncated = splitUpData.TryGetValue(Version4StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
                SecondStreetAddress = splitUpData.TryGetValue(Version4StandardMarkers.SecondStreetAddressMarker),
                HairColor = splitUpData.TryGetValue(Version4StandardMarkers.HairColorMarker).ParseHairColor(),
                PlaceOfBirth = splitUpData.TryGetValue(Version4StandardMarkers.PlaceOfBirthMarker),
                AuditInformation = splitUpData.TryGetValue(Version4StandardMarkers.AuditInformationMarker),
                InventoryControl = splitUpData.TryGetValue(Version4StandardMarkers.InventoryControlMarker),
                LastNameAlias = splitUpData.TryGetValue(Version4StandardMarkers.LastNameAliasMarker),
                FirstNameAlias = splitUpData.TryGetValue(Version4StandardMarkers.FirstNameAliasMarker),
                SuffixAlias = splitUpData.TryGetValue(Version4StandardMarkers.SuffixAliasMarker),
                NameSuffix = splitUpData.TryGetValue(Version4StandardMarkers.NameSuffixMarker).ParseNameSuffix()
            };
        }

        public static class Version4StandardMarkers
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