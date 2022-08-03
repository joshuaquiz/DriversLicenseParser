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

public static class PennsylvaniaTests
{
    [Fact]
    public static void ValidateOhioLicenseData()
    {
        // Arrange.
        var state = new Pennsylvania();

        // Assert.
        using (new AssertionScope())
        {
            state.FullName.Should().Be("Pennsylvania");
            state.Abbreviation.Should().Be("PA");
            state.Country.Should().Be(IssuingCountry.UnitedStates);
            state.IssuerIdentificationNumber.Should().Be(636025);
        }
    }

    [Theory]
    [InlineData("636025", true)]
    [InlineData("ha636025ha", true)]
    [InlineData("636125", false)]
    public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string? input, bool expected) =>
        new Pennsylvania().IsDataFromEntity(input).Should().Be(expected);

    public static IEnumerable<object[]> GetDataSets() =>
        new List<object[]>
        {
            new object[]
            {
                "%40%0A%0DANSI%206360250101DL00290191DLDAQ123456789%0ADAAJOHN%20CHESTER%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F*%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU600%0ADAYBRO%0ADBA20210305%0ADBB20100428%0ADBCM%0ADBD20170304%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290191",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2021, 3, 5, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 3, 4, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 72,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+6360250101DL00290197DLDAQ123456789%0ADAAJOHN+CHESTER+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224+++++%0ADARC+%0ADAS*%2F*+++++++++++%0ADAT----%0ADAU508%0ADAYBRO%0ADBA20200626%0ADBB20100428%0ADBCM%0ADBD20170328%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290197",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2020, 6, 26, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 3, 28, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 68,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1E%0DANSI+6360250101DL00290191DLDAQ123456789%0ADAAJOHN+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224+++++%0ADARC+%0ADAS*%2F1+++++++++++%0ADAT----%0ADAU509%0ADAYBLU%0ADBA20210612%0ADBB20100428%0ADBCF%0ADBD20170607%0ADBF00%0ADBHY%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290191",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Blue,
                    ExpirationDate = new DateTimeOffset(2021, 6, 12, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 6, 7, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DANSI%206360250101DL00290191DLDAQ123456789%0ADAAJOHN%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU509%0ADAYBLU%0ADBA20210612%0ADBB20100428%0ADBCF%0ADBD20170607%0ADBF00%0ADBHY%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290191",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Blue,
                    ExpirationDate = new DateTimeOffset(2021, 6, 12, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 6, 7, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 69,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DAAMVA6360250101DL00290181DAQ123456789%0ADAAJOHN%20CHESTER%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU603%0ADAYBRO%0ADBA20171022%0ADBB20100428%0ADBCM%0ADBD20131030%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290181",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2017, 10, 22, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2013, 10, 30, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 75,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290181DAQ123456789%0ADAAJOHN+CHESTER+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU603%0ADAYBRO%0ADBA20171022%0ADBB20100428%0ADBCM%0ADBD20131030%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290181",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2017, 10, 22, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2013, 10, 30, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 75,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DAAMVA6360250101DL00290184DAQ123456789%0ADAAJOHN%20DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU508%0ADAYBLK%0ADBA20181009%0ADBB20100428%0ADBCM%0ADBD20141028%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290184",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Black,
                    ExpirationDate = new DateTimeOffset(2018, 10, 09, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2014, 10, 28, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 68,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290184DAQ123456789%0ADAAJOHN+DOE%0ADAG1234 FAKE BLVD%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU508%0ADAYBLK%0ADBA20181009%0ADBB20100428%0ADBCM%0ADBD20141028%0ADBF00%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = null,
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290184",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Black,
                    ExpirationDate = new DateTimeOffset(2018, 10, 9, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2014, 10, 28, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 68,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN%20CHESTER%20DOE%20JR%20%20%20%20%20%20%20%20%20%20%20%0ADAG1234 FAKE BLVD%20%20%20%20%20%20%20%20%0ADAIMYCITY%0ADAJPA%0ADAK44224%20%20%20%20%20%20%0ADARC%20%20%20%0ADAS*%2F1%20%20%20%20%20%20%20%20%20%20%20%20%20%0ADAT----%20%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Junior,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Junior,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+DOE+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Junior,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+PHILLIP+DOE+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD PHILLIP",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%1C%0DAAMVA6360250101DL00290219DAQ123456789%0ADAAJOHN+CHESTER+LAUD+PHILLIP+DOE+JR+++++++++++%0ADAG1234 FAKE BLVD++++++++%0ADAIMYCITY%0ADAJPA%0ADAK44224++++++%0ADARC+++%0ADAS*%2F1+++++++++++++%0ADAT----+%0ADAU507%0ADAYHZ%0ADBA20180529%0ADBB20100428%0ADBCM%0ADBD20150408%0ADBF01%0ADBHN%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD PHILLIP",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = null,
                    AuditInformation = "00290219",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Unknown,
                    ExpirationDate = new DateTimeOffset(2018, 5, 29, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2015, 4, 8, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "6360250101",
                    FirstNameTruncated = Truncation.Unknown,
                    LastNameTruncated = Truncation.Unknown,
                    MiddleNameTruncated = Truncation.Unknown,
                    Gender = Gender.Unknown,
                    Height = 67,
                    NameSuffix = NameSuffix.Junior,
                    LicenseVersion = LicenseVersion.Version1
                }
            },
            new object[]
            {
                "%40%0A%0DANSI%20636025080002DL00410259ZP03000027DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%0ADDGN%0ADCACM%0ADCBNONE%0ADCDNONE%0ADBD10052017%0ADBB04282010%0ADBA10022021%0ADBC1%0ADAU072%20IN%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJPA%0ADAK442240000%20%20%0ADCF1727801202705000000006734%0ADCGUSA%0ADCK0250094436817163%0ADDB06072016%0DZPZPA%0AZPB00%0AZPC019%0AZPDNONE%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "1727801202705000000006734",
                    AuditInformation = "00410259ZP03000027",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2021, 10, 2, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "636025080002",
                    FirstNameTruncated = Truncation.None,
                    LastNameTruncated = Truncation.None,
                    MiddleNameTruncated = Truncation.None,
                    Gender = Gender.Male,
                    Height = 72,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version8
                }
            },
            new object[]
            {
                "%40%0A%0DANSI%20636025080002DL00410259ZP03000027DLDAQ123456789%0ADCSDOE%0ADDEN%0ADACJOHN%0ADDFN%0ADADCHESTER%20LAUD%0ADDGN%0ADCACM%0ADCBNONE%0ADCDNONE%0ADBD10052017%0ADBB04282010%0ADBA10022021%0ADBC1%0ADAU072%20IN%0ADAYBRO%0ADAG1234%20FAKE%20BLVD%0ADAIMYCITY%0ADAJPA%0ADAK442240000%20%20%0ADCF1727801202705000000006734%0ADCGUSA%0ADCK0250094436817163%0ADDB06072016%0DZPZPA%0AZPB00%0AZPC019%0AZPDNONE%0D",
                new DriversLicenseData
                {
                    FirstName = "JOHN",
                    MiddleName = "CHESTER LAUD",
                    LastName = "DOE",
                    DateOfBirth = new DateTimeOffset(2010, 4, 28, 0, 0, 0, TimeSpan.Zero),
                    StreetAddress = "1234 FAKE BLVD",
                    SecondStreetAddress = null,
                    City = "MYCITY",
                    State = "PA",
                    PostalCode = "44224",
                    IssuingCountry = IssuingCountry.UnitedStates,
                    DocumentId = "1727801202705000000006734",
                    AuditInformation = "00410259ZP03000027",
                    FirstNameAlias = null,
                    LastNameAlias = null,
                    SuffixAlias = null,
                    PlaceOfBirth = null,
                    CustomerId = "123456789",
                    EyeColor = EyeColor.Brown,
                    ExpirationDate = new DateTimeOffset(2021, 10, 2, 0, 0, 0, TimeSpan.Zero),
                    IssueDate = new DateTimeOffset(2017, 10, 5, 0, 0, 0, TimeSpan.Zero),
                    HairColor = HairColor.Unknown,
                    InventoryControl = "636025080002",
                    FirstNameTruncated = Truncation.None,
                    LastNameTruncated = Truncation.None,
                    MiddleNameTruncated = Truncation.None,
                    Gender = Gender.Male,
                    Height = 72,
                    NameSuffix = NameSuffix.Unknown,
                    LicenseVersion = LicenseVersion.Version8
                }
            }
        };

    [Theory, MemberData(nameof(GetDataSets))]
    public static void ParseData(string data, DriversLicenseData expected)
    {
        var driversLicenseData = new Pennsylvania().ParseData(HttpUtility.UrlDecode(data));
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