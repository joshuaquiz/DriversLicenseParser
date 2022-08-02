using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using FluentAssertions;
using FluentAssertions.Execution;
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
            // Arrange.
            var state = new Illinois();

            // Assert.
            using (new AssertionScope())
            {
                state.FullName.Should().Be("Illinois");
                state.Abbreviation.Should().Be("IL");
                state.Country.Should().Be(IssuingCountry.UnitedStates);
                state.IssuerIdentificationNumber.Should().Be(636035);
            }
        }

        [Theory]
        [InlineData("636035", true)]
        [InlineData("ha636035ha", true)]
        [InlineData("636135", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            new Illinois().IsDataFromEntity(input).Should().Be(expected);

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
            using (new AssertionScope())
            {
                driversLicenseData.FirstName.Should().Be(expected.FirstName);
                driversLicenseData.MiddleName.Should().Be(expected.MiddleName);
                driversLicenseData.LastName.Should().Be(expected.LastName);
                driversLicenseData.DateOfBirth.Should().Be(expected.DateOfBirth);
                driversLicenseData.StreetAddress.Should().Be(expected.StreetAddress);
                driversLicenseData.SecondStreetAddress.Should().Be(expected.SecondStreetAddress);
                driversLicenseData.City.Should().Be(expected.City);
                driversLicenseData.State.Should().Be(expected.State);
                driversLicenseData.PostalCode.Should().Be(expected.PostalCode);
                driversLicenseData.IssuingCountry.Should().Be(expected.IssuingCountry);
                driversLicenseData.DocumentId.Should().Be(expected.DocumentId);
                driversLicenseData.AuditInformation.Should().Be(expected.AuditInformation);
                driversLicenseData.FirstNameAlias.Should().Be(expected.FirstNameAlias);
                driversLicenseData.LastNameAlias.Should().Be(expected.LastNameAlias);
                driversLicenseData.SuffixAlias.Should().Be(expected.SuffixAlias);
                driversLicenseData.PlaceOfBirth.Should().Be(expected.PlaceOfBirth);
                driversLicenseData.CustomerId.Should().Be(expected.CustomerId);
                driversLicenseData.EyeColor.Should().Be(expected.EyeColor);
                driversLicenseData.ExpirationDate.Should().Be(expected.ExpirationDate);
                driversLicenseData.IssueDate.Should().Be(expected.IssueDate);
                driversLicenseData.HairColor.Should().Be(expected.HairColor);
                driversLicenseData.InventoryControl.Should().Be(expected.InventoryControl);
                driversLicenseData.FirstNameTruncated.Should().Be(expected.FirstNameTruncated);
                driversLicenseData.LastNameTruncated.Should().Be(expected.LastNameTruncated);
                driversLicenseData.MiddleNameTruncated.Should().Be(expected.MiddleNameTruncated);
                driversLicenseData.Gender.Should().Be(expected.Gender);
                driversLicenseData.Height.Should().Be(expected.Height);
                driversLicenseData.NameSuffix.Should().Be(expected.NameSuffix);
                driversLicenseData.LicenseVersion.Should().Be(expected.LicenseVersion);
            }
        }
    }
}