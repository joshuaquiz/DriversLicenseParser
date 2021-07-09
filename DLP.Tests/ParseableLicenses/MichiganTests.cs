using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class MichiganTests
    {
        [Fact]
        public static void ValidateStateLicenseData()
        {
            // Setup.
            var state = new Michigan();

            // Assert.
            Assert.Equal(
                "Michigan",
                state.FullName);
            Assert.Equal(
                "MI",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636032,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636032", true)]
        [InlineData("ha636032ha", true)]
        [InlineData("636132", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Michigan().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%1E%0DANSI+636032030002DL00410201ZM02420027DLDCA%0ADCB%0ADCD%0ADBA08082020%0ADCSDOE%0ADCTJOHNCHESTER%0ADBD08082016%0ADBB04282010%0ADBC1%0ADAY%0ADAU%0ADAG1234+FAKE+BLVD%0ADAIMYCITY%0ADAJMI%0ADAK442241601++%0ADAQW+123+456+789+012%0ADCF%0ADCG%0ADCH%0ADAH%0ADCKW123456789012198308082020%0A%0DZMZMARev+01-21-2011%0AZMB01%0A%0D",
                    new DriversLicenseData
                    {
                        FirstName = "JOHNCHESTER",
                        MiddleName = null,
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = string.Empty,
                        City = "MYCITY",
                        State = "MI",
                        PostalCode = "442241601",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = string.Empty,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "W 123 456 789 012",
                        EyeColor = EyeColor.Unknown,
                        ExpirationDate = new DateTimeOffset(2020, 8, 8, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2016, 8, 8, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Unknown,
                        InventoryControl = "W123456789012198308082020",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = null,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version3
                    }
                },
                new object[]
                {
                    "%40%0A%0DANSI%20636032030002DL00410201ZM02420027DLDCA%0ADCB%0ADCD%0ADBA08082020%0ADCSDOE%0ADCTJOHNCHESTER%0ADBD08082016%0ADBB04282010%0ADBC1%0ADAY%0ADAU%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJMI%0ADAK442241601%20%20%0ADAQW%20123%20456%20789%20012%0ADCF%0ADCG%0ADCH%0ADAH%0ADCKW123456789012198308082020%0A%0DZMZMARev%2001-21-2011%0AZMB01%0A%0D",
                    new DriversLicenseData
                    {
                        FirstName = "JOHNCHESTER",
                        MiddleName = null,
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE BLVD",
                        SecondStreetAddress = string.Empty,
                        City = "MYCITY",
                        State = "MI",
                        PostalCode = "442241601",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = string.Empty,
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = "W 123 456 789 012",
                        EyeColor = EyeColor.Unknown,
                        ExpirationDate = new DateTimeOffset(2020, 8, 8, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2016, 8, 8, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Unknown,
                        InventoryControl = "W123456789012198308082020",
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Male,
                        Height = null,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version3
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new Michigan().ParseData(HttpUtility.UrlDecode(data));
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