using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class ValidateStateLicenseData
    {
        [Fact]
        public static void ValidateOhioLicenseData()
        {
            // Setup.
            var state = new Pennsylvania();

            // Assert.
            Assert.Equal(
                "Pennsylvania",
                state.FullName);
            Assert.Equal(
                "PA",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636025,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636025", true)]
        [InlineData("ha636025ha", true)]
        [InlineData("636125", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new Pennsylvania().IsDataFromEntity(input));

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
            Assert.Equal(expected.FirstName, driversLicenseData.FirstName);
            Assert.Equal(expected.MiddleName, driversLicenseData.MiddleName);
            Assert.Equal(expected.LastName, driversLicenseData.LastName);
            Assert.Equal(expected.DateOfBirth, driversLicenseData.DateOfBirth);
            Assert.Equal(expected.StreetAddress, driversLicenseData.StreetAddress);
            Assert.Equal(expected.SecondStreetAddress, driversLicenseData.SecondStreetAddress);
            Assert.Equal(expected.City, driversLicenseData.City);
            Assert.Equal(expected.State, driversLicenseData.State);
            Assert.Equal(expected.PostalCode, driversLicenseData.PostalCode);
            Assert.Equal(expected.IssuingCountry, driversLicenseData.IssuingCountry);
            Assert.Equal(expected.DocumentId, driversLicenseData.DocumentId);
            Assert.Equal(expected.AuditInformation, driversLicenseData.AuditInformation);
            Assert.Equal(expected.FirstNameAlias, driversLicenseData.FirstNameAlias);
            Assert.Equal(expected.LastNameAlias, driversLicenseData.LastNameAlias);
            Assert.Equal(expected.SuffixAlias, driversLicenseData.SuffixAlias);
            Assert.Equal(expected.PlaceOfBirth, driversLicenseData.PlaceOfBirth);
            Assert.Equal(expected.CustomerId, driversLicenseData.CustomerId);
            Assert.Equal(expected.EyeColor, driversLicenseData.EyeColor);
            Assert.Equal(expected.ExpirationDate, driversLicenseData.ExpirationDate);
            Assert.Equal(expected.IssueDate, driversLicenseData.IssueDate);
            Assert.Equal(expected.HairColor, driversLicenseData.HairColor);
            Assert.Equal(expected.InventoryControl, driversLicenseData.InventoryControl);
            Assert.Equal(expected.FirstNameTruncated, driversLicenseData.FirstNameTruncated);
            Assert.Equal(expected.LastNameTruncated, driversLicenseData.LastNameTruncated);
            Assert.Equal(expected.MiddleNameTruncated, driversLicenseData.MiddleNameTruncated);
            Assert.Equal(expected.Gender, driversLicenseData.Gender);
            Assert.Equal(expected.Height, driversLicenseData.Height);
            Assert.Equal(expected.NameSuffix, driversLicenseData.NameSuffix);
            Assert.Equal(expected.LicenseVersion, driversLicenseData.LicenseVersion);
        }
    }
}