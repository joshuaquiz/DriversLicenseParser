﻿using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;

namespace DLP.Core.Parsers;

public static class Version8StandardParser
{
    public static DriversLicenseData ParseDriversLicenseData(
        string? data,
        out IReadOnlyDictionary<string, string?> splitUpData)
    {
        splitUpData = ParsingHelpers.SplitLicenseString(data);
        return new DriversLicenseData
        {
            FirstName = splitUpData.TryGetValue(Version8StandardMarkers.FirstNameMarker),
            LastName = splitUpData.TryGetValue(Version8StandardMarkers.LastNameMarker),
            MiddleName = splitUpData.TryGetValue(Version8StandardMarkers.MiddleNameMarker),
            ExpirationDate = splitUpData.TryGetValue(Version8StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
            IssueDate = splitUpData.TryGetValue(Version8StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
            DateOfBirth = splitUpData.TryGetValue(Version8StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
            Gender = splitUpData.TryGetValue(Version8StandardMarkers.GenderMarker).ParseGender(),
            EyeColor = splitUpData.TryGetValue(Version8StandardMarkers.EyeColorMarker).ParseEyeColor(),
            Height = splitUpData.TryGetValue(Version8StandardMarkers.HeightMarker).ParseHeightInInches(),
            StreetAddress = splitUpData.TryGetValue(Version8StandardMarkers.StreetAddressMarker),
            City = splitUpData.TryGetValue(Version8StandardMarkers.CityMarker),
            State = splitUpData.TryGetValue(Version8StandardMarkers.StateMarker),
            PostalCode = splitUpData.TryGetValue(Version8StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
            CustomerId = splitUpData.TryGetValue(Version8StandardMarkers.CustomerIdMarker),
            DocumentId = splitUpData.TryGetValue(Version8StandardMarkers.DocumentIdMarker),
            IssuingCountry = splitUpData.TryGetValue(Version8StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
            MiddleNameTruncated = splitUpData.TryGetValue(Version8StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
            FirstNameTruncated = splitUpData.TryGetValue(Version8StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
            LastNameTruncated = splitUpData.TryGetValue(Version8StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
            SecondStreetAddress = splitUpData.TryGetValue(Version8StandardMarkers.SecondStreetAddressMarker),
            HairColor = splitUpData.TryGetValue(Version8StandardMarkers.HairColorMarker).ParseHairColor(),
            PlaceOfBirth = splitUpData.TryGetValue(Version8StandardMarkers.PlaceOfBirthMarker),
            AuditInformation = splitUpData.TryGetValue(Version8StandardMarkers.AuditInformationMarker),
            InventoryControl = splitUpData.TryGetValue(Version8StandardMarkers.InventoryControlMarker),
            LastNameAlias = splitUpData.TryGetValue(Version8StandardMarkers.LastNameAliasMarker),
            FirstNameAlias = splitUpData.TryGetValue(Version8StandardMarkers.FirstNameAliasMarker),
            SuffixAlias = splitUpData.TryGetValue(Version8StandardMarkers.SuffixAliasMarker),
            NameSuffix = splitUpData.TryGetValue(Version8StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
            LicenseVersion = LicenseVersion.Version8
        };
    }

    public static class Version8StandardMarkers
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