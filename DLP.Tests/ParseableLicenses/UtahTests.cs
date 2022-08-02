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
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
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
            expected.FirstName.Should().Be(driversLicenseData.FirstName);
            expected.MiddleName.Should().Be(driversLicenseData.MiddleName);
            expected.LastName.Should().Be(driversLicenseData.LastName);
            expected.DateOfBirth.Should().Be(driversLicenseData.DateOfBirth);
            expected.StreetAddress.Should().Be(driversLicenseData.StreetAddress);
            expected.SecondStreetAddress.Should().Be(driversLicenseData.SecondStreetAddress);
            expected.City.Should().Be(driversLicenseData.City);
            expected.State.Should().Be(driversLicenseData.State);
            expected.PostalCode.Should().Be(driversLicenseData.PostalCode);
            expected.IssuingCountry.Should().Be(driversLicenseData.IssuingCountry);
            expected.DocumentId.Should().Be(driversLicenseData.DocumentId);
            expected.AuditInformation.Should().Be(driversLicenseData.AuditInformation);
            expected.FirstNameAlias.Should().Be(driversLicenseData.FirstNameAlias);
            expected.LastNameAlias.Should().Be(driversLicenseData.LastNameAlias);
            expected.SuffixAlias.Should().Be(driversLicenseData.SuffixAlias);
            expected.PlaceOfBirth.Should().Be(driversLicenseData.PlaceOfBirth);
            expected.CustomerId.Should().Be(driversLicenseData.CustomerId);
            expected.EyeColor.Should().Be(driversLicenseData.EyeColor);
            expected.ExpirationDate.Should().Be(driversLicenseData.ExpirationDate);
            expected.IssueDate.Should().Be(driversLicenseData.IssueDate);
            expected.HairColor.Should().Be(driversLicenseData.HairColor);
            expected.InventoryControl.Should().Be(driversLicenseData.InventoryControl);
            expected.FirstNameTruncated.Should().Be(driversLicenseData.FirstNameTruncated);
            expected.LastNameTruncated.Should().Be(driversLicenseData.LastNameTruncated);
            expected.MiddleNameTruncated.Should().Be(driversLicenseData.MiddleNameTruncated);
            expected.Gender.Should().Be(driversLicenseData.Gender);
            expected.Height.Should().Be(driversLicenseData.Height);
            expected.NameSuffix.Should().Be(driversLicenseData.NameSuffix);
            expected.LicenseVersion.Should().Be(driversLicenseData.LicenseVersion);
        }
    }
}