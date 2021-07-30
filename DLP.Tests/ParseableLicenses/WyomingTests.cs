using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class WyomingTests
    {
        [Fact]
        public static void ValidateStateLicenseData()
        {
            // Setup.
            var state = new Wyoming();

            // Assert.
            Assert.Equal(
                "Wyoming",
                state.FullName);
            Assert.Equal(
                "WY",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636060,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636060", true)]
        [InlineData("ha636060ha", true)]
        [InlineData("636140", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Wyoming().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%0DANSI%20636060040002DL00410263ZW03040037DCAC%0ADCBNONE%0ADCDNONE%0ADBA20201215%0ADCSDOE%0ADACJOHN%20CHESTER%0ADAD%0ADBD20160929%0ADBB20100428%0ADBC1%0ADAYBLU%0ADAU073%20IN%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJWY%0ADAK44224-2452%20%20%20%20%20%20%0ADAQ123456789%0ADCF0123456789%0ADCGUSA%0ADDEU%0ADDFU%0ADDGU%0ADAHMYCITY,%20WY%20%2044224%0ADAZBRO%0ADCJ20161010_003008_4_471%0AZWZWA%0AZWBY%0AZWC%0AZWD%0AZWE%0AZWF0060-57020%0A",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "CHESTER",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = "MYCITY, WY  44224",
                        City = "MYCITY",
                        State = "WY",
                        PostalCode = "44224-2452",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = "0123456789",
                        AuditInformation = "20161010_003008_4_471",
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "123456789",
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2020, 12, 15, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2016, 9, 29, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Brown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 73,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version4
                    }
                },
                new object[]
                {
                    "%40%0A%1E%0DANSI+636060040002DL00410263ZW03040037DCAC%0ADCBNONE%0ADCDNONE%0ADBA20201215%0ADCSDOE%0ADACJOHN+CHESTER%0ADAD%0ADBD20160929%0ADBB20100428%0ADBC1%0ADAYBLU%0ADAU073+IN%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWY%0ADAK44224++++++%0ADAQ123456789%0ADCF0123456789%0ADCGUSA%0ADDEU%0ADDFU%0ADDGU%0ADAHMYCITY%2C+WY++44224%0ADAZBRO%0ADCJ20161010_003008_4_471%0AZWZWA%0AZWBY%0AZWC%0AZWD%0AZWE%0AZWF0060-57020%0A",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "CHESTER",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = "MYCITY, WY  44224",
                        City = "MYCITY",
                        State = "WY",
                        PostalCode = "44224",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = "0123456789",
                        AuditInformation = "20161010_003008_4_471",
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "123456789",
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2020, 12, 15, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2016, 9, 29, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Brown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 73,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version4
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new Wyoming().ParseData(HttpUtility.UrlDecode(data));
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