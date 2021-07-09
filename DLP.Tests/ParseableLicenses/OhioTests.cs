using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class OhioTests
    {
        [Fact]
        public static void ValidateStateLicenseData()
        {
            // Setup.
            var state = new Ohio();

            // Assert.
            Assert.Equal(
                "Ohio",
                state.FullName);
            Assert.Equal(
                "OH",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636023,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636023", true)]
        [InlineData("ha636023ha", true)]
        [InlineData("636123", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Ohio().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24%24%5E1234%20FAKE%20CT%5E6360231816123456789%3D16092010093010451409248%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509195BROBLU",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = null,
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 9, 30, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE CT",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "45140-9248",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1816123456789",
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2016, 9, 01, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Brown,
                        InventoryControl = "6360231816123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 69,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%20TWP%5EDOE%24JOHN%24D%24%5E1234%20FAKE%20WAY%5E6360231820123456789%3D17122010121510450115913%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509210BROBRO&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 12, 15, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE WAY",
                        SecondStreetAddress = null,
                        City = "MYCITY TWP",
                        State = "OH",
                        PostalCode = "45011-5913",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1820123456789",
                        EyeColor = EyeColor.Brown,
                        ExpirationDate = new DateTimeOffset(2017, 12, 01, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Brown,
                        InventoryControl = "6360231820123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 69,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24%24D%5E1234%20N%20FAKE%20ST%5E6360231803123456789%3D1805201005311045066%20%20%20%20%20%20D%20A%20%20%20%20%20%20%20%20%20M%20%20%201511175REDBLU&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 5, 31, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 N FAKE ST",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "45066",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1803123456789",
                        EyeColor = EyeColor.Unknown,
                        ExpirationDate = new DateTimeOffset(2018, 5, 01, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Unknown,
                        InventoryControl = "6360231803123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 151,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24D%24%5E1234%20FIVE%20POINTS%20MOWRYMYCITYN%20R6360231821123456789%3D1802201002141045171%20%20%20%20%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%202507200BROGRN&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 2, 14, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FIVE POINTS MOWRYMYCITYN R",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "45171",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1821123456789",
                        EyeColor = EyeColor.Green,
                        ExpirationDate = new DateTimeOffset(2018, 2, 01, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Brown,
                        InventoryControl = "6360231821123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Female,
                        Height = 67,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24D%24%5E1234%20FAKE%20AVE%5E6360232017123456789%3D16122010122310452273804%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%202503130BROHAZ",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 12, 23, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE AVE",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "45227-3804",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "2017123456789",
                        EyeColor = EyeColor.Hazel,
                        ExpirationDate = new DateTimeOffset(2016, 12, 01, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Brown,
                        InventoryControl = "6360232017123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Female,
                        Height = 63,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "M",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 3, 8, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "44224-2452",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1820123456789",
                        EyeColor = EyeColor.Unknown,
                        ExpirationDate = new DateTimeOffset(2018, 3, 1, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Unknown,
                        InventoryControl = "6360231820123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Unknown,
                        Height = null,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                },
                new object[]
                {
                    "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201601205BROHAZ&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "M",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 3, 8, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "OH",
                        PostalCode = "44224-2452",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "1820123456789",
                        EyeColor = EyeColor.Hazel,
                        ExpirationDate = new DateTimeOffset(2018, 3, 1, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = null,
                        HairColor = HairColor.Brown,
                        InventoryControl = "6360231820123456789",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 73,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.UnknownVersion
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new Ohio().ParseData(HttpUtility.UrlDecode(data));
            Assert.Equal(expected.FirstName, driversLicenseData.FirstName);
            Assert.Equal(expected.MiddleName, driversLicenseData.MiddleName);
            Assert.Equal(expected.LastName, driversLicenseData.LastName);
            Assert.Equal(expected.DateOfBirth, driversLicenseData.DateOfBirth);
            Assert.Equal(expected.StreetAddress, driversLicenseData.StreetAddress);
            Assert.Equal(expected.SecondStreetAddress, driversLicenseData.SecondStreetAddress);
            Assert.Equal(expected.City, driversLicenseData.City);
            Assert.Equal(expected.State, driversLicenseData.State);
            Assert.Equal(expected.PostalCode, driversLicenseData.PostalCode);
            Assert.Equal(expected.IssuingCountry, driversLicenseData.IssuingCountry);
            Assert.Equal(expected.DocumentId, driversLicenseData.DocumentId);
            Assert.Equal(expected.AuditInformation, driversLicenseData.AuditInformation);
            Assert.Equal(expected.FirstNameAlias, driversLicenseData.FirstNameAlias);
            Assert.Equal(expected.LastNameAlias, driversLicenseData.LastNameAlias);
            Assert.Equal(expected.SuffixAlias, driversLicenseData.SuffixAlias);
            Assert.Equal(expected.PlaceOfBirth, driversLicenseData.PlaceOfBirth);
            Assert.Equal(expected.CustomerId, driversLicenseData.CustomerId);
            Assert.Equal(expected.EyeColor, driversLicenseData.EyeColor);
            Assert.Equal(expected.ExpirationDate, driversLicenseData.ExpirationDate);
            Assert.Equal(expected.IssueDate, driversLicenseData.IssueDate);
            Assert.Equal(expected.HairColor, driversLicenseData.HairColor);
            Assert.Equal(expected.InventoryControl, driversLicenseData.InventoryControl);
            Assert.Equal(expected.FirstNameTruncated, driversLicenseData.FirstNameTruncated);
            Assert.Equal(expected.LastNameTruncated, driversLicenseData.LastNameTruncated);
            Assert.Equal(expected.MiddleNameTruncated, driversLicenseData.MiddleNameTruncated);
            Assert.Equal(expected.Gender, driversLicenseData.Gender);
            Assert.Equal(expected.Height, driversLicenseData.Height);
            Assert.Equal(expected.NameSuffix, driversLicenseData.NameSuffix);
            Assert.Equal(expected.LicenseVersion, driversLicenseData.LicenseVersion);
        }
    }
}