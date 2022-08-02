using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using FluentAssertions;
using FluentAssertions.Execution;
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
            // Arrange.
            var state = new NorthCarolina();

            // Assert.
            using (new AssertionScope())
            {
                state.FullName.Should().Be("North Carolina");
                state.Abbreviation.Should().Be("NC");
                state.Country.Should().Be(IssuingCountry.UnitedStates);
                state.IssuerIdentificationNumber.Should().Be(636004);
            }
        }

        [Theory]
        [InlineData("636004", true)]
        [InlineData("ha636004ha", true)]
        [InlineData("636014", false)]
        public static void IsDataFromEntityCorrectlyDetectsEntitiesData(string input, bool expected) =>
            new NorthCarolina().IsDataFromEntity(input).Should().Be(expected);

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
}