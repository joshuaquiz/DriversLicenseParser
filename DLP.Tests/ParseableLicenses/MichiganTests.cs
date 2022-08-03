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

public static class MichiganTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Michigan();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Michigan");
            state.Abbreviation.Should().Be("MI");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636032);
        }
    }

    [Theory]
    [InlineData("636032", true)]
    [InlineData("ha636032ha", true)]
    [InlineData("636132", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Michigan().IsDataFromEntity(input).Should().Be(expected);

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