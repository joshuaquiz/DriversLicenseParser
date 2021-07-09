using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using System.Web;
using Xunit;

namespace DLP.Tests.ParseableLicenses
{
    public static class NorthCarolinaTests
    {
        [Fact]
        public static void ValidateStateLicenseData()
        {
            // Setup.
            var state = new NorthCarolina();

            // Assert.
            Assert.Equal(
                "North Carolina",
                state.FullName);
            Assert.Equal(
                "NC",
                state.Abbreviation);
            Assert.Equal(
                IssuingCountry.UnitedStates,
                state.Country);
            Assert.Equal(
                636004,
                state.IssuerIdentificationNumber);
        }

        [Theory]
        [InlineData("636004", true)]
        [InlineData("ha636004ha", true)]
        [InlineData("636014", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            Assert.Equal(
                expected,
                new NorthCarolina().IsDataFromEntity(input));

        public static IEnumerable<object[]> GetDataSets() =>
            new List<object[]>
            {
                new object[]
                {
                    "%40%0A%1E%0DAAMVA36004001DL00280195DLDABDOE%0ADACJOHN%0ADADD%0ADAE%0ADAL1234%20FAKE%20CT%0ADAM%0ADANMYCITY%0ADAONC%0ADAP28451-7030%0ADAQ123456789%0ADARC%0ADASNone%0ADATNone%0ADAV5-10%0ADAYBLU%0ADAZBRO%0ADBA06-19-2023%0ADBB06-19-2010%0ADBCM%0ADBD06-22-2015%0ADBHY%0D&",
                    new DriversLicenseData
                    {
                        FirstName = "JOHN",
                        MiddleName = "D",
                        LastName = "DOE",
                        DateOfBirth = new DateTimeOffset(2010, 6, 19, 0, 0, 0, TimeSpan.Zero),
                        StreetAddress = "1234 FAKE CT",
                        SecondStreetAddress = null,
                        City = "MYCITY",
                        State = "NC",
                        PostalCode = "28451-7030",
                        IssuingCountry = IssuingCountry.UnitedStates,
                        DocumentId = "123456789",
                        AuditInformation = null,
                        FirstNameAlias = null,
                        LastNameAlias = null,
                        SuffixAlias = null,
                        PlaceOfBirth = null,
                        CustomerId = null,
                        EyeColor = EyeColor.Blue,
                        ExpirationDate = new DateTimeOffset(2023, 6, 19, 0, 0, 0, TimeSpan.Zero),
                        IssueDate = new DateTimeOffset(2015, 6, 22, 0, 0, 0, TimeSpan.Zero),
                        HairColor = HairColor.Brown,
                        InventoryControl = null,
                        FirstNameTruncated = Truncation.Unknown,
                        LastNameTruncated = Truncation.Unknown,
                        MiddleNameTruncated = Truncation.Unknown,
                        Gender = Gender.Unknown,
                        Height = 70,
                        NameSuffix = NameSuffix.Unknown,
                        LicenseVersion = LicenseVersion.Version1
                    }
                }
            };

        [Theory, MemberData(nameof(GetDataSets))]
        public static void ParseData(string data, DriversLicenseData expected)
        {
            var driversLicenseData = new NorthCarolina().ParseData(HttpUtility.UrlDecode(data));
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