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

public static class MinnesotaTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Minnesota();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Minnesota");
            state.Abbreviation.Should().Be("MN");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636038);
        }
    }

    [Theory]
    [InlineData("636038", true)]
    [InlineData("ha636038ha", true)]
    [InlineData("636132", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Minnesota().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "%40%0A%0DANSI%20636038090002DL00410295ZM03360012DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%0ADDGN%0ADCAD%0ADCB2%0ADCDNONE%0ADBD04032019%0ADBB04282010%0ADBA04082023%0ADBC1%0ADAU071%20in%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJMN%0ADAK442241234%20%20%0ADCF00000000975498%0ADCGUSA%0ADAW160%0ADCKH3080943473110119001%0ADDAN%0ADDB10232017%0ADDJ04082019%0ADDK1%0DZMZMAN%0AZMBN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "MN",
                    PostalCode = "442241234",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "00000000975498",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2023, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2019, 4, 3, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "H3080943473110119001",
                    FirstNameTruncated = Truncation.None,
                    LastNameTruncated = Truncation.None,
                    MiddleNameTruncated = Truncation.None,
                    Gender = Gender.Male,
                    Height = 71,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version9
                }
            },
            new object[]
            {
                "%40%0A%0DANSI%20636038090002DL00410295ZM03360012DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%20LAUD%0ADDGN%0ADCAD%0ADCB2%0ADCDNONE%0ADBD04032019%0ADBB04282010%0ADBA04082023%0ADBC1%0ADAU071%20in%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJMN%0ADAK442241234%20%20%0ADCF00000000975498%0ADCGUSA%0ADAW160%0ADCKH3080943473110119001%0ADDAN%0ADDB10232017%0ADDJ04082019%0ADDK1%0DZMZMAN%0AZMBN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "MN",
                    PostalCode = "442241234",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "00000000975498",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2023, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2019, 4, 3, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "H3080943473110119001",
                    FirstNameTruncated = Truncation.None,
                    LastNameTruncated = Truncation.None,
                    MiddleNameTruncated = Truncation.None,
                    Gender = Gender.Male,
                    Height = 71,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version9
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Minnesota().ParseData(HttpUtility.UrlDecode(data));
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