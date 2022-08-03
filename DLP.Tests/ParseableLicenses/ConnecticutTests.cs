using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses;

public static class ConnecticutTests
{
    [Fact]
    public static void ValidateOhioLicenseData()
    {
        // Arrange.
        var state = new Connecticut();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Connecticut");
            state.Abbreviation.Should().Be("CT");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636006);
        }
    }

    [Theory]
    [InlineData("636006", true)]
    [InlineData("ha636006ha", true)]
    [InlineData("636125", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Connecticut().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "%40%0A%1E%0DAAMVA6360060101DL00290175DAADOE%2CJOHN%2CCHESTER%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJCT%0ADAK44224+++++%0ADAQ123456789%0ADARD+%0ADAS++++++++%0ADAT++++%0ADBA20210701%0ADBB20100428%0ADBC2%0ADBD20150618%0ADAU507%0ADAYHAZ%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "CT",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = null,
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2021, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 6, 18, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "00290175",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Female,
                    Height = 67,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DAAMVA6360060101DL00290175DAADOE,JOHN,CHESTER%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJCT%0ADAK44224%20%20%20%20%20%20%0ADAQ123456789%0ADARD%20%20%20%0ADAS%20%20%20%20%20%20%20%20%20%20%0ADAT%20%20%20%20%20%0ADBA20210701%0ADBB20100428%0ADBC2%0ADBD20150618%0ADAU507%0ADAYHAZ%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "CT",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = null,
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2021, 7, 1, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 6, 18, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "00290175",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Female,
                    Height = 67,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Connecticut().ParseData(HttpUtility.UrlDecode(data));
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