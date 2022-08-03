using DLP.Core.Helpers;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System.Collections.Generic;

namespace DLP.Core.Parsers;

public static class Version9StandardParser
{
    public static DriversLicenseData ParseDriversLicenseData(
        string? data,
        out IReadOnlyDictionary<string, string?> splitUpData)
    {
        splitUpData = ParsingHelpers.SplitLicenseString(data);
        return new DriversLicenseData
        {
            FirstName = splitUpData.TryGetValue(Version9StandardMarkers.FirstNameMarker),
            LastName = splitUpData.TryGetValue(Version9StandardMarkers.LastNameMarker),
            MiddleName = splitUpData.TryGetValue(Version9StandardMarkers.MiddleNameMarker),
            ExpirationDate = splitUpData.TryGetValue(Version9StandardMarkers.ExpirationDateMarker).ParseDateTimeMdyThenYmd(),
            IssueDate = splitUpData.TryGetValue(Version9StandardMarkers.IssueDateMarker).ParseDateTimeMdyThenYmd(),
            DateOfBirth = splitUpData.TryGetValue(Version9StandardMarkers.DateOfBirthMarker).ParseDateTimeMdyThenYmd(),
            Gender = splitUpData.TryGetValue(Version9StandardMarkers.GenderMarker).ParseGender(),
            EyeColor = splitUpData.TryGetValue(Version9StandardMarkers.EyeColorMarker).ParseEyeColor(),
            Height = splitUpData.TryGetValue(Version9StandardMarkers.HeightMarker).ParseHeightInInches(),
            StreetAddress = splitUpData.TryGetValue(Version9StandardMarkers.StreetAddressMarker),
            City = splitUpData.TryGetValue(Version9StandardMarkers.CityMarker),
            State = splitUpData.TryGetValue(Version9StandardMarkers.StateMarker),
            PostalCode = splitUpData.TryGetValue(Version9StandardMarkers.PostalCodeMarker).TrimTrailingZerosFromZipCode(),
            CustomerId = splitUpData.TryGetValue(Version9StandardMarkers.CustomerIdMarker),
            DocumentId = splitUpData.TryGetValue(Version9StandardMarkers.DocumentIdMarker),
            IssuingCountry = splitUpData.TryGetValue(Version9StandardMarkers.IssuingCountryMarker).ParseIssuingCountry(),
            MiddleNameTruncated = splitUpData.TryGetValue(Version9StandardMarkers.MiddleNameTruncatedMarker).ParseTruncation(),
            FirstNameTruncated = splitUpData.TryGetValue(Version9StandardMarkers.FirstNameTruncatedMarker).ParseTruncation(),
            LastNameTruncated = splitUpData.TryGetValue(Version9StandardMarkers.LastNameTruncatedMarker).ParseTruncation(),
            SecondStreetAddress = splitUpData.TryGetValue(Version9StandardMarkers.SecondStreetAddressMarker),
            HairColor = splitUpData.TryGetValue(Version9StandardMarkers.HairColorMarker).ParseHairColor(),
            PlaceOfBirth = splitUpData.TryGetValue(Version9StandardMarkers.PlaceOfBirthMarker),
            AuditInformation = splitUpData.TryGetValue(Version9StandardMarkers.AuditInformationMarker),
            InventoryControl = splitUpData.TryGetValue(Version9StandardMarkers.InventoryControlMarker),
            LastNameAlias = splitUpData.TryGetValue(Version9StandardMarkers.LastNameAliasMarker),
            FirstNameAlias = splitUpData.TryGetValue(Version9StandardMarkers.FirstNameAliasMarker),
            SuffixAlias = splitUpData.TryGetValue(Version9StandardMarkers.SuffixAliasMarker),
            NameSuffix = splitUpData.TryGetValue(Version9StandardMarkers.NameSuffixMarker).ParseNameSuffix(),
            LicenseVersion = LicenseVersion.Version9
        };
    }

    public static class Version9StandardMarkers
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