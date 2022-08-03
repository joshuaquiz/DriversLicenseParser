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

public static class WyomingTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Wyoming();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Wyoming");
            state.Abbreviation.Should().Be("WY");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636060);
        }
    }

    [Theory]
    [InlineData("636060", true)]
    [InlineData("ha636060ha", true)]
    [InlineData("636140", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Wyoming().IsDataFromEntity(input).Should().Be(expected);

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