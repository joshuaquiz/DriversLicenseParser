using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class IllinoisTests
    {
        [Fact]
        public static void ValidateStateLicenseData()
        {
            // Setup.
            var state = new Illinois();

            // Assert.
            Assert.Equal(
                "Illinois",
                state.FullName);
            Assert.Equal(
                "IL",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636035,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636035", true)]
        [InlineData("ha636035ha", true)]
        [InlineData("636135", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Illinois().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%0DANSI%206360350201DL00290190DLDAADOE,JOHN,CHESTER%0ADAQ123456789%0ADBA20181224%0ADBB20100428%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJIL%0ADAK442240000%20%20%0ADARD%0ADAS********%20%20%0ADAT*****%0ADBD20140529%0ADBCF%0ADAU503%0ADAW125%0ADAYBLU%0A%0D",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "CHESTER",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "IL",
                        PostalCode = "44224",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "123456789",
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2018, 12, 24, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2014, 5, 29, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Unknown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Unknown,
                        Height = 63,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version2
                    }
                },
                new object[]
                {
                    "%40%0A%1C%0DANSI+6360350201DL00290190DLDAADOE%2CJOHN%2CCHESTER%0ADAQ123456789%0ADBA20181224%0ADBB20100428%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJIL%0ADAK442240000++%0ADARD%0ADAS********++%0ADAT*****%0ADBD20140529%0ADBCF%0ADAU503%0ADAW125%0ADAYBLU%0A%0D",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "CHESTER",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "IL",
                        PostalCode = "44224",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = null,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "123456789",
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2018, 12, 24, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2014, 5, 29, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Unknown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Unknown,
                        Height = 63,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version2
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new Illinois().ParseData(HttpUtility.UrlDecode(data));
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