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

public static class WashingtonTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Washington();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Washington");
            state.Abbreviation.Should().Be("WA");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636045);
        }
    }

    [Theory]
    [InlineData("636045", true)]
    [InlineData("ha636045ha", true)]
    [InlineData("636140", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
        new Washington().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "%40%0A%0DANSI%20636045030002DL00410241ZW02820051DLDCSDOE%0ADCTJOHN%20CHESTER%0ADCU%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442249142%20%20%0ADCGUSA%0ADAQ123456789%0ADCANONE%0ADCBNONE%0ADCDNONE%0ADCF12345678932152304B1136%0ADCHNONE%0ADBA08172021%0ADBB04282010%0ADBC1%0ADBD08182015%0ADAU071%20in%0ADCE4%0ADAYHAZ%0DZWZWA152304B1136%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev03122007%0A%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "WA",
                    PostalCode = "442249142",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "12345678932152304B1136",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2021, 8, 17, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 8, 18, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = null,
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 71,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version3
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+636045030002DL00410241ZW02820051DLDCSDOE%0ADCTJOHN+CHESTER%0ADCU%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442249142++%0ADCGUSA%0ADAQ123456789%0ADCANONE%0ADCBNONE%0ADCDNONE%0ADCF12345678932152304B1136%0ADCHNONE%0ADBA08172021%0ADBB04282010%0ADBC1%0ADBD08182015%0ADAU071+in%0ADCE4%0ADAYHAZ%0DZWZWA152304B1136%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev03122007%0A%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "WA",
                    PostalCode = "442249142",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "12345678932152304B1136",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2021, 8, 17, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 8, 18, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = null,
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 71,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version3
                }
            },
            new object[]
            {
                "%40%0A%0DANSI%20636045030002DL00410241ZW02820051DLDCANONE%0ADCBNONE%0ADCDNONE%0ADBA05052023%0ADCSDOE%0ADCTJOHN%0ADCU%0ADBD05022017%0ADBB04282010%0ADBC1%0ADAYBLK%0ADAU066%20in%0ADCE3%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442244027%20%20%0ADAQ123456789%0ADCF12345678932171223A1326%0ADCGUSA%0ADCHNONE%0A%0DZWZWA171223A1326%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev09162009%0A%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "WA",
                    PostalCode = "442244027",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "12345678932171223A1326",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Black,
                    ExpirationDate = new DateTimeOffset(2023, 5, 5, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 5, 2, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = null,
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 66,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version3
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+636045030002DL00410241ZW02820051DLDCANONE%0ADCBNONE%0ADCDNONE%0ADBA05052023%0ADCSDOE%0ADCTJOHN%0ADCU%0ADBD05022017%0ADBB04282010%0ADBC1%0ADAYBLK%0ADAU066+in%0ADCE3%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJWA%0ADAK442244027++%0ADAQ123456789%0ADCF12345678932171223A1326%0ADCGUSA%0ADCHNONE%0A%0DZWZWA171223A1326%0AZWB%0AZWC32%0AZWD%0AZWE%0AZWFRev09162009%0A%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "WA",
                    PostalCode = "442244027",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "12345678932171223A1326",
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Black,
                    ExpirationDate = new DateTimeOffset(2023, 5, 5, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 5, 2, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = null,
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 66,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version3
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Washington().ParseData(HttpUtility.UrlDecode(data));
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