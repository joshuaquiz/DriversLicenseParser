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

public static class UtahTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Utah();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Utah");
            state.Abbreviation.Should().Be("UT");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636040);
        }
    }

    [Theory]
    [InlineData("636040", true)]
    [InlineData("ha636040ha", true)]
    [InlineData("636140", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Utah().IsDataFromEntity(input).Should().Be(expected);

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