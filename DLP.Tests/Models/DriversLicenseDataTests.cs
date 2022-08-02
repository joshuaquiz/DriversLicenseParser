using DLP.Core.Models;
using DLP.Core.Models.Enums;
using FluentAssertions;
using FluentAssertions.Execution;
using Newtonsoft.Json;
using System;
using Xunit;

namespace DLP.Tests.Models
{
    public static class DriversLicenseDataTests
    {
        [Fact]
        public static void PropertiesSetAndGetCorrectly()
        {
            // Arrange.
            var firstName = Guid.NewGuid().ToString();
            var lastName = Guid.NewGuid().ToString();
            var middleName = Guid.NewGuid().ToString();
            var expirationDate = DateTimeOffset.UtcNow.AddYears(2);
            var issueDate = DateTimeOffset.UtcNow.AddYears(-2);
            var dateOfBirth = DateTimeOffset.UtcNow.AddYears(-18);
            const Gender gender = Gender.Male;
            const EyeColor eyeColor = EyeColor.Black;
            const HairColor hairColor = HairColor.Blond;
            const decimal height = 50.5M;
            var streetAddress = Guid.NewGuid().ToString();
            var secondStreetAddress = Guid.NewGuid().ToString();
            var city = Guid.NewGuid().ToString();
            var state = Guid.NewGuid().ToString();
            var postalCode = Guid.NewGuid().ToString();
            var customerId = Guid.NewGuid().ToString();
            var documentId = Guid.NewGuid().ToString();
            const IssuingCountry issuingCountry = IssuingCountry.Canada;
            const Truncation middleNameTruncated = Truncation.None;
            const Truncation firstNameTruncated = Truncation.None;
            const Truncation lastNameTruncated = Truncation.None;
            var placeOfBirth = Guid.NewGuid().ToString();
            var auditInformation = Guid.NewGuid().ToString();
            var inventoryControl = Guid.NewGuid().ToString();
            var lastNameAlias = Guid.NewGuid().ToString();
            var firstNameAlias = Guid.NewGuid().ToString();
            var suffixAlias = Guid.NewGuid().ToString();
            const NameSuffix nameSuffix = NameSuffix.Junior;
            const LicenseVersion licenseVersion = LicenseVersion.Version6;

            // Act.
            var driversLicenseData = new DriversLicenseData
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                ExpirationDate = expirationDate,
                IssueDate = issueDate,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                EyeColor = eyeColor,
                HairColor = hairColor,
                Height = height,
                StreetAddress = streetAddress,
                SecondStreetAddress = secondStreetAddress,
                City = city,
                State = state,
                PostalCode = postalCode,
                CustomerId = customerId,
                DocumentId = documentId,
                IssuingCountry = issuingCountry,
                MiddleNameTruncated = middleNameTruncated,
                FirstNameTruncated = firstNameTruncated,
                LastNameTruncated = lastNameTruncated,
                PlaceOfBirth = placeOfBirth,
                AuditInformation = auditInformation,
                InventoryControl = inventoryControl,
                LastNameAlias = lastNameAlias,
                FirstNameAlias = firstNameAlias,
                SuffixAlias = suffixAlias,
                NameSuffix = nameSuffix,
                LicenseVersion = licenseVersion
            };

            // Assert.
            using (new AssertionScope())
            {
                driversLicenseData.FirstName.Should().Be(firstName);
                driversLicenseData.LastName.Should().Be(lastName);
                driversLicenseData.MiddleName.Should().Be(middleName);
                driversLicenseData.ExpirationDate.Should().Be(expirationDate);
                driversLicenseData.IssueDate.Should().Be(issueDate);
                driversLicenseData.DateOfBirth.Should().Be(dateOfBirth);
                driversLicenseData.Gender.Should().Be(gender);
                driversLicenseData.EyeColor.Should().Be(eyeColor);
                driversLicenseData.HairColor.Should().Be(hairColor);
                driversLicenseData.Height.Should().Be(height);
                driversLicenseData.StreetAddress.Should().Be(streetAddress);
                driversLicenseData.SecondStreetAddress.Should().Be(secondStreetAddress);
                driversLicenseData.City.Should().Be(city);
                driversLicenseData.State.Should().Be(state);
                driversLicenseData.PostalCode.Should().Be(postalCode);
                driversLicenseData.CustomerId.Should().Be(customerId);
                driversLicenseData.DocumentId.Should().Be(documentId);
                driversLicenseData.IssuingCountry.Should().Be(issuingCountry);
                driversLicenseData.MiddleNameTruncated.Should().Be(middleNameTruncated);
                driversLicenseData.FirstNameTruncated.Should().Be(firstNameTruncated);
                driversLicenseData.LastNameTruncated.Should().Be(lastNameTruncated);
                driversLicenseData.PlaceOfBirth.Should().Be(placeOfBirth);
                driversLicenseData.AuditInformation.Should().Be(auditInformation);
                driversLicenseData.InventoryControl.Should().Be(inventoryControl);
                driversLicenseData.LastNameAlias.Should().Be(lastNameAlias);
                driversLicenseData.FirstNameAlias.Should().Be(firstNameAlias);
                driversLicenseData.SuffixAlias.Should().Be(suffixAlias);
                driversLicenseData.NameSuffix.Should().Be(nameSuffix);
                driversLicenseData.LicenseVersion.Should().Be(licenseVersion);
            }
        }

        [Fact]
        public static void ToJsonWorksCorrectly()
        {
            var firstName = Guid.NewGuid().ToString();
            var lastName = Guid.NewGuid().ToString();
            var middleName = Guid.NewGuid().ToString();
            var expirationDate = DateTimeOffset.UtcNow.AddYears(2);
            var issueDate = DateTimeOffset.UtcNow.AddYears(-2);
            var dateOfBirth = DateTimeOffset.UtcNow.AddYears(-18);
            const Gender gender = Gender.Male;
            const EyeColor eyeColor = EyeColor.Black;
            const HairColor hairColor = HairColor.Blond;
            const decimal height = 50.5M;
            var streetAddress = Guid.NewGuid().ToString();
            var secondStreetAddress = Guid.NewGuid().ToString();
            var city = Guid.NewGuid().ToString();
            var state = Guid.NewGuid().ToString();
            var postalCode = Guid.NewGuid().ToString();
            var customerId = Guid.NewGuid().ToString();
            var documentId = Guid.NewGuid().ToString();
            const IssuingCountry issuingCountry = IssuingCountry.Canada;
            const Truncation middleNameTruncated = Truncation.None;
            const Truncation firstNameTruncated = Truncation.None;
            const Truncation lastNameTruncated = Truncation.None;
            var placeOfBirth = Guid.NewGuid().ToString();
            var auditInformation = Guid.NewGuid().ToString();
            var inventoryControl = Guid.NewGuid().ToString();
            var lastNameAlias = Guid.NewGuid().ToString();
            var firstNameAlias = Guid.NewGuid().ToString();
            var suffixAlias = Guid.NewGuid().ToString();
            const NameSuffix nameSuffix = NameSuffix.Junior;
            const LicenseVersion licenseVersion = LicenseVersion.Version6;
            var driversLicenseData = new DriversLicenseData
            {
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                ExpirationDate = expirationDate,
                IssueDate = issueDate,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                EyeColor = eyeColor,
                HairColor = hairColor,
                Height = height,
                StreetAddress = streetAddress,
                SecondStreetAddress = secondStreetAddress,
                City = city,
                State = state,
                PostalCode = postalCode,
                CustomerId = customerId,
                DocumentId = documentId,
                IssuingCountry = issuingCountry,
                MiddleNameTruncated = middleNameTruncated,
                FirstNameTruncated = firstNameTruncated,
                LastNameTruncated = lastNameTruncated,
                PlaceOfBirth = placeOfBirth,
                AuditInformation = auditInformation,
                InventoryControl = inventoryControl,
                LastNameAlias = lastNameAlias,
                FirstNameAlias = firstNameAlias,
                SuffixAlias = suffixAlias,
                NameSuffix = nameSuffix,
                LicenseVersion = licenseVersion
            };

            // Act.
            var json = JsonConvert.SerializeObject(driversLicenseData);

            // Assert.
            using (new AssertionScope())
            {
                json.Should().Be($"{{\"FirstName\":\"{firstName}\",\"LastName\":\"{lastName}\",\"MiddleName\":\"{middleName}\",\"ExpirationDate\":\"{expirationDate:O}\",\"IssueDate\":\"{issueDate:O}\",\"DateOfBirth\":\"{dateOfBirth:O}\",\"Gender\":{gender:D},\"EyeColor\":{eyeColor:D},\"HairColor\":{hairColor:D},\"Height\":{height},\"StreetAddress\":\"{streetAddress}\",\"SecondStreetAddress\":\"{secondStreetAddress}\",\"City\":\"{city}\",\"State\":\"{state}\",\"PostalCode\":\"{postalCode}\",\"CustomerId\":\"{customerId}\",\"DocumentId\":\"{documentId}\",\"IssuingCountry\":{issuingCountry:D},\"MiddleNameTruncated\":{middleNameTruncated:D},\"FirstNameTruncated\":{firstNameTruncated:D},\"LastNameTruncated\":{lastNameTruncated:D},\"PlaceOfBirth\":\"{placeOfBirth}\",\"AuditInformation\":\"{auditInformation}\",\"InventoryControl\":\"{inventoryControl}\",\"LastNameAlias\":\"{lastNameAlias}\",\"FirstNameAlias\":\"{firstNameAlias}\",\"SuffixAlias\":\"{suffixAlias}\",\"NameSuffix\":{nameSuffix:D},\"LicenseVersion\":{licenseVersion:D}}}");
            }
        }

        [Fact]
        public static void FromJsonWorksCorrectly()
        {
            // Arrange.
            var firstName = Guid.NewGuid().ToString();
            var lastName = Guid.NewGuid().ToString();
            var middleName = Guid.NewGuid().ToString();
            var expirationDate = DateTimeOffset.UtcNow.AddYears(2);
            var issueDate = DateTimeOffset.UtcNow.AddYears(-2);
            var dateOfBirth = DateTimeOffset.UtcNow.AddYears(-18);
            const Gender gender = Gender.Male;
            const EyeColor eyeColor = EyeColor.Black;
            const HairColor hairColor = HairColor.Blond;
            const decimal height = 50.5M;
            var streetAddress = Guid.NewGuid().ToString();
            var secondStreetAddress = Guid.NewGuid().ToString();
            var city = Guid.NewGuid().ToString();
            var state = Guid.NewGuid().ToString();
            var postalCode = Guid.NewGuid().ToString();
            var customerId = Guid.NewGuid().ToString();
            var documentId = Guid.NewGuid().ToString();
            const IssuingCountry issuingCountry = IssuingCountry.Canada;
            const Truncation middleNameTruncated = Truncation.None;
            const Truncation firstNameTruncated = Truncation.None;
            const Truncation lastNameTruncated = Truncation.None;
            var placeOfBirth = Guid.NewGuid().ToString();
            var auditInformation = Guid.NewGuid().ToString();
            var inventoryControl = Guid.NewGuid().ToString();
            var lastNameAlias = Guid.NewGuid().ToString();
            var firstNameAlias = Guid.NewGuid().ToString();
            var suffixAlias = Guid.NewGuid().ToString();
            const NameSuffix nameSuffix = NameSuffix.Junior;
            const LicenseVersion licenseVersion = LicenseVersion.Version6;
            var json = $"{{\"FirstName\":\"{firstName}\",\"LastName\":\"{lastName}\",\"MiddleName\":\"{middleName}\",\"ExpirationDate\":\"{expirationDate:O}\",\"IssueDate\":\"{issueDate:O}\",\"DateOfBirth\":\"{dateOfBirth:O}\",\"Gender\":{gender:D},\"EyeColor\":{eyeColor:D},\"HairColor\":{hairColor:D},\"Height\":{height},\"StreetAddress\":\"{streetAddress}\",\"SecondStreetAddress\":\"{secondStreetAddress}\",\"City\":\"{city}\",\"State\":\"{state}\",\"PostalCode\":\"{postalCode}\",\"CustomerId\":\"{customerId}\",\"DocumentId\":\"{documentId}\",\"IssuingCountry\":{issuingCountry:D},\"MiddleNameTruncated\":{middleNameTruncated:D},\"FirstNameTruncated\":{firstNameTruncated:D},\"LastNameTruncated\":{lastNameTruncated:D},\"PlaceOfBirth\":\"{placeOfBirth}\",\"AuditInformation\":\"{auditInformation}\",\"InventoryControl\":\"{inventoryControl}\",\"LastNameAlias\":\"{lastNameAlias}\",\"FirstNameAlias\":\"{firstNameAlias}\",\"SuffixAlias\":\"{suffixAlias}\",\"NameSuffix\":{nameSuffix:D},\"LicenseVersion\":{licenseVersion:D}}}";

            // Act.
            var driversLicenseData = JsonConvert.DeserializeObject<DriversLicenseData>(json);

            // Assert.
            using (new AssertionScope())
            {
                driversLicenseData.FirstName.Should().Be(firstName);
                driversLicenseData.LastName.Should().Be(lastName);
                driversLicenseData.MiddleName.Should().Be(middleName);
                driversLicenseData.ExpirationDate.Should().Be(expirationDate);
                driversLicenseData.IssueDate.Should().Be(issueDate);
                driversLicenseData.DateOfBirth.Should().Be(dateOfBirth);
                driversLicenseData.Gender.Should().Be(gender);
                driversLicenseData.EyeColor.Should().Be(eyeColor);
                driversLicenseData.HairColor.Should().Be(hairColor);
                driversLicenseData.Height.Should().Be(height);
                driversLicenseData.StreetAddress.Should().Be(streetAddress);
                driversLicenseData.SecondStreetAddress.Should().Be(secondStreetAddress);
                driversLicenseData.City.Should().Be(city);
                driversLicenseData.State.Should().Be(state);
                driversLicenseData.PostalCode.Should().Be(postalCode);
                driversLicenseData.CustomerId.Should().Be(customerId);
                driversLicenseData.DocumentId.Should().Be(documentId);
                driversLicenseData.IssuingCountry.Should().Be(issuingCountry);
                driversLicenseData.MiddleNameTruncated.Should().Be(middleNameTruncated);
                driversLicenseData.FirstNameTruncated.Should().Be(firstNameTruncated);
                driversLicenseData.LastNameTruncated.Should().Be(lastNameTruncated);
                driversLicenseData.PlaceOfBirth.Should().Be(placeOfBirth);
                driversLicenseData.AuditInformation.Should().Be(auditInformation);
                driversLicenseData.InventoryControl.Should().Be(inventoryControl);
                driversLicenseData.LastNameAlias.Should().Be(lastNameAlias);
                driversLicenseData.FirstNameAlias.Should().Be(firstNameAlias);
                driversLicenseData.SuffixAlias.Should().Be(suffixAlias);
                driversLicenseData.NameSuffix.Should().Be(nameSuffix);
                driversLicenseData.LicenseVersion.Should().Be(licenseVersion);
            }
        }
    }
}