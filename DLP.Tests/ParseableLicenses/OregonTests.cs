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

public static class OregonTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Oregon();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Oregon");
            state.Abbreviation.Should().Be("OR");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636029);
        }
    }

    [Theory]
    [InlineData("636029", true)]
    [InlineData("ha636029ha", true)]
    [InlineData("636132", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Oregon().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "%40%0A%1E%0DANSI+6360290102DL00390183ZO02220025DLDAQW+123+456+789+012%0ADAADOE%2C+JOHN%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADAT++++++%0ADAU508%0ADAW160%0ADBA20251227%0ADBB20100428%0ADBC1%0ADBD20171214%0AZOZOARECORD+CREATED+1995%0A",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OR",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = null,
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2025, 12, 27, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 12, 14, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "00390183ZO02220025",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 68,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+6360290102DL00390183ZO02220025DLDAQW+123+456+789+012%0ADAADOE%2C+JOHN+CHESTER%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADAT++++++%0ADAU508%0ADAW160%0ADBA20251227%0ADBB20100428%0ADBC1%0ADBD20171214%0AZOZOARECORD+CREATED+1995%0A",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OR",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = null,
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2025, 12, 27, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 12, 14, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "00390183ZO02220025",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 68,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+6360290102DL00390188ZO02270031DLDAQW+123+456+789+012%0ADAALAUD+DOE%2C+JOHN+CHESTER%0ADAG%0ADAL1234+FAKE+BLVD%0ADAIMYCITY%0ADAJOR%0ADAK44224++++++%0ADARC+++%0ADASD+++++++++%0ADATM+++++%0ADAU510%0ADAW270%0ADBA20201028%0ADBB20100428%0ADBC1%0ADBD20190305%0AZOZOAFIRST+LICENSED+10-20-2004%0A",
                new DriversLicenseData
                {
                    FirstName = "DOE",
                    MiddleName = "JOHN",
                    LastName = "LAUD",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OR",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = null,
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2020, 10, 28, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2019, 3, 5, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "00390188ZO02270031",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 70,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Oregon().ParseData(HttpUtility.UrlDecode(data));
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