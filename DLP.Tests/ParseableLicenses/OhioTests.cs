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

public static class OhioTests
{
    [Fact]
    public static void ValidateStateLicenseData()
    {
        // Arrange.
        var state = new Ohio();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Ohio");
            state.Abbreviation.Should().Be("OH");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636023);
        }
    }

    [Theory]
    [InlineData("636023", true)]
    [InlineData("ha636023ha", true)]
    [InlineData("636123", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Ohio().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24%24%5E1234%20FAKE%20CT%5E6360231816123456789%3D16092010093010451409248%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509195BROBLU",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 9, 30, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE CT",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "45140-9248",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1816123456789",
                    EyeColor = EyeColor.Blue,
                    ExpirationDate = new DateTimeOffset(2016, 9, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231816123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%20TWP%5EDOE%24JOHN%24D%24%5E1234%20FAKE%20WAY%5E6360231820123456789%3D17122010121510450115913%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509210BROBRO&",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "D",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 12, 15, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE WAY",
                    SecondStreetAddress = null,
                    City = "MYCITY TWP",
                    State = "OH",
                    PostalCode = "45011-5913",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1820123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2017, 12, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231820123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%20TWP%5EDOE%24JOHN%24D%24D%24%5E1234%20FAKE%20WAY%5E6360231820123456789%3D17122010121510450115913%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509210BROBRO&",
                new DriversLicenseData
                {
                    FirstName = null,
                    MiddleName = null,
                    LastName = "DOE$JOHN$D$D$",
                    DateOfBirth = new DateTimeOffset(2010, 12, 15, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE WAY",
                    SecondStreetAddress = null,
                    City = "MYCITY TWP",
                    State = "OH",
                    PostalCode = "45011-5913",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1820123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2017, 12, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231820123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%20TWP%5EDOE%24%5E1234%20FAKE%20WAY%5E6360231820123456789%3D17122010121510450115913%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201509210BROBRO&",
                new DriversLicenseData
                {
                    FirstName = null,
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 12, 15, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE WAY",
                    SecondStreetAddress = null,
                    City = "MYCITY TWP",
                    State = "OH",
                    PostalCode = "45011-5913",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1820123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2017, 12, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231820123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24%24D%5E1234%20N%20FAKE%20ST%5E6360231803123456789%3D1805201005311045066%20%20%20%20%20%20D%20A%20%20%20%20%20%20%20%20%20M%20%20%201511175REDBLU&",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "D",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 5, 31, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 N FAKE ST",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "45066",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1803123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360231803123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 151,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24D%24%5E1234%20FIVE%20POINTS%20MOWRYMYCITYN%20R6360231821123456789%3D1802201002141045171%20%20%20%20%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%202507200BROGRN&",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "D",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 2, 14, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FIVE POINTS MOWRYMYCITYN R",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "45171",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1821123456789",
                    EyeColor = EyeColor.Green,
                    ExpirationDate = new DateTimeOffset(2018, 2, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231821123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Female,
                    Height = 67,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24D%24%5E1234%20FAKE%20AVE%5E6360232017123456789%3D16122010122310452273804%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%202503130BROHAZ",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "D",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 12, 23, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE AVE",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "45227-3804",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "2017123456789",
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2016, 12, 01, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360232017123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Female,
                    Height = 63,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "M",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 3, 8, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "44224-2452",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1820123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 3, 1, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360231820123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = null,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            },
            new object[]
            {
                "OHMYCITY%5EDOE%24JOHN%24M%24%5E1234%20FAKE%20BLVD%5E6360231820123456789%3D18032010030810442242452%20%20D%20A%20%20%20%20%20%20%20%20%20%20%20%20%201601205BROHAZ&",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "M",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 3, 8, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "OH",
                    PostalCode = "44224-2452",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = null,
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "1820123456789",
                    EyeColor = EyeColor.Hazel,
                    ExpirationDate = new DateTimeOffset(2018, 3, 1, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = null,
                    HairColor = HairColor.Brown,
                    InventoryControl = "6360231820123456789",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Male,
                    Height = 73,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.UnknownVersion
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Ohio().ParseData(HttpUtility.UrlDecode(data));
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