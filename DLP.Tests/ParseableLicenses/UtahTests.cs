using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class UtahTests
    {
        [Fact]
        public static void ValidateOhioLicenseData()
        {
            // Setup.
            var utah = new Utah();

            // Assert.
            Assert.Equal(
                "Utah",
                utah.FullName);
            Assert.Equal(
                "UT",
                utah.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                utah.Country);
            Assert.Equal(
                636040,
                utah.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636040", true)]
        [InlineData("ha636040ha", true)]
        [InlineData("636140", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Utah().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%1E%0DANSI%20636040030002DL00410223ZU02640008DLDCAD%0ADCBB%0ADCD%0ADBA10162017%0ADCSDOE%0ADCTJOHN%2CD%2C%0ADBD10152012%0ADBB10162010%0ADBC1%0ADAYBRO%0ADAU%2070%20in%0ADAG1234 FAKE AVE%0ADAISALT%20LAKE%20CITY%0ADAJUT%0ADAK84115%20%20%20%20%20%20%0ADAQ123456789%0ADCF0123456789_108425421%0ADCGUSA%0ADCHNONE%0ADAZBROWN%0A%0DZUZUAY%0A%0D&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 10, 16, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE AVE",
                        SecondStreetAddress = null,
                        City = "SALT LAKE CITY",
                        State = "UT",
                        PostalCode = "84115",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = "0123456789_108425421",
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "123456789",
                        EyeColor = EyeColor.Brown,
                        ExpirationDate = new DateTimeOffset(2017, 10, 16, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2012, 10, 15, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Unknown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = 70,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version3
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new Utah().ParseData(HttpUtility.UrlDecode(data));
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