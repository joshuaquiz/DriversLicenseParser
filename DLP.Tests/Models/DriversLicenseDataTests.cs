using DLP.Core.Models;
using DLP.Core.Models.Enums;
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
            // Setup.
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
                NameSuffix = nameSuffix
            };

            // Assert.
            Assert.Equal(
                firstName,
                driversLicenseData.FirstName);
            Assert.Equal(
                lastName,
                driversLicenseData.LastName);
            Assert.Equal(
                middleName,
                driversLicenseData.MiddleName);
            Assert.Equal(
                expirationDate,
                driversLicenseData.ExpirationDate);
            Assert.Equal(
                issueDate,
                driversLicenseData.IssueDate);
            Assert.Equal(
                dateOfBirth,
                driversLicenseData.DateOfBirth);
            Assert.Equal(
                gender,
                driversLicenseData.Gender);
            Assert.Equal(
                eyeColor,
                driversLicenseData.EyeColor);
            Assert.Equal(
                hairColor,
                driversLicenseData.HairColor);
            Assert.Equal(
                height,
                driversLicenseData.Height);
            Assert.Equal(
                streetAddress,
                driversLicenseData.StreetAddress);
            Assert.Equal(
                secondStreetAddress,
                driversLicenseData.SecondStreetAddress);
            Assert.Equal(
                city,
                driversLicenseData.City);
            Assert.Equal(
                state,
                driversLicenseData.State);
            Assert.Equal(
                postalCode,
                driversLicenseData.PostalCode);
            Assert.Equal(
                customerId,
                driversLicenseData.CustomerId);
            Assert.Equal(
                documentId,
                driversLicenseData.DocumentId);
            Assert.Equal(
                issuingCountry,
                driversLicenseData.IssuingCountry);
            Assert.Equal(
                middleNameTruncated,
                driversLicenseData.MiddleNameTruncated);
            Assert.Equal(
                firstNameTruncated,
                driversLicenseData.FirstNameTruncated);
            Assert.Equal(
                lastNameTruncated,
                driversLicenseData.LastNameTruncated);
            Assert.Equal(
                placeOfBirth,
                driversLicenseData.PlaceOfBirth);
            Assert.Equal(
                auditInformation,
                driversLicenseData.AuditInformation);
            Assert.Equal(
                inventoryControl,
                driversLicenseData.InventoryControl);
            Assert.Equal(
                lastNameAlias,
                driversLicenseData.LastNameAlias);
            Assert.Equal(
                firstNameAlias,
                driversLicenseData.FirstNameAlias);
            Assert.Equal(
                suffixAlias,
                driversLicenseData.SuffixAlias);
            Assert.Equal(
                nameSuffix,
                driversLicenseData.NameSuffix);
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
                NameSuffix = nameSuffix
            };

            // Act.
            var json = JsonConvert.SerializeObject(driversLicenseData);

            // Assert.
            Assert.Equal(
                $"{{\"FirstName\":\"{firstName}\",\"LastName\":\"{lastName}\",\"MiddleName\":\"{middleName}\",\"ExpirationDate\":\"{expirationDate:O}\",\"IssueDate\":\"{issueDate:O}\",\"DateOfBirth\":\"{dateOfBirth:O}\",\"Gender\":{gender:D},\"EyeColor\":{eyeColor:D},\"HairColor\":{hairColor:D},\"Height\":{height},\"StreetAddress\":\"{streetAddress}\",\"SecondStreetAddress\":\"{secondStreetAddress}\",\"City\":\"{city}\",\"State\":\"{state}\",\"PostalCode\":\"{postalCode}\",\"CustomerId\":\"{customerId}\",\"DocumentId\":\"{documentId}\",\"IssuingCountry\":{issuingCountry:D},\"MiddleNameTruncated\":{middleNameTruncated:D},\"FirstNameTruncated\":{firstNameTruncated:D},\"LastNameTruncated\":{lastNameTruncated:D},\"PlaceOfBirth\":\"{placeOfBirth}\",\"AuditInformation\":\"{auditInformation}\",\"InventoryControl\":\"{inventoryControl}\",\"LastNameAlias\":\"{lastNameAlias}\",\"FirstNameAlias\":\"{firstNameAlias}\",\"SuffixAlias\":\"{suffixAlias}\",\"NameSuffix\":{nameSuffix:D}}}",
                json);
        }

        [Fact]
        public static void FromJsonWorksCorrectly()
        {
            // Setup.
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
            var json = $"{{\"FirstName\":\"{firstName}\",\"LastName\":\"{lastName}\",\"MiddleName\":\"{middleName}\",\"ExpirationDate\":\"{expirationDate:O}\",\"IssueDate\":\"{issueDate:O}\",\"DateOfBirth\":\"{dateOfBirth:O}\",\"Gender\":{gender:D},\"EyeColor\":{eyeColor:D},\"HairColor\":{hairColor:D},\"Height\":{height},\"StreetAddress\":\"{streetAddress}\",\"SecondStreetAddress\":\"{secondStreetAddress}\",\"City\":\"{city}\",\"State\":\"{state}\",\"PostalCode\":\"{postalCode}\",\"CustomerId\":\"{customerId}\",\"DocumentId\":\"{documentId}\",\"IssuingCountry\":{issuingCountry:D},\"MiddleNameTruncated\":{middleNameTruncated:D},\"FirstNameTruncated\":{firstNameTruncated:D},\"LastNameTruncated\":{lastNameTruncated:D},\"PlaceOfBirth\":\"{placeOfBirth}\",\"AuditInformation\":\"{auditInformation}\",\"InventoryControl\":\"{inventoryControl}\",\"LastNameAlias\":\"{lastNameAlias}\",\"FirstNameAlias\":\"{firstNameAlias}\",\"SuffixAlias\":\"{suffixAlias}\",\"NameSuffix\":{nameSuffix:D}}}";

            // Act.
            var driversLicenseData = JsonConvert.DeserializeObject<DriversLicenseData>(json);

            // Assert.
            Assert.Equal(
                firstName,
                driversLicenseData.FirstName);
            Assert.Equal(
                lastName,
                driversLicenseData.LastName);
            Assert.Equal(
                middleName,
                driversLicenseData.MiddleName);
            Assert.Equal(
                expirationDate,
                driversLicenseData.ExpirationDate);
            Assert.Equal(
                issueDate,
                driversLicenseData.IssueDate);
            Assert.Equal(
                dateOfBirth,
                driversLicenseData.DateOfBirth);
            Assert.Equal(
                gender,
                driversLicenseData.Gender);
            Assert.Equal(
                eyeColor,
                driversLicenseData.EyeColor);
            Assert.Equal(
                hairColor,
                driversLicenseData.HairColor);
            Assert.Equal(
                height,
                driversLicenseData.Height);
            Assert.Equal(
                streetAddress,
                driversLicenseData.StreetAddress);
            Assert.Equal(
                secondStreetAddress,
                driversLicenseData.SecondStreetAddress);
            Assert.Equal(
                city,
                driversLicenseData.City);
            Assert.Equal(
                state,
                driversLicenseData.State);
            Assert.Equal(
                postalCode,
                driversLicenseData.PostalCode);
            Assert.Equal(
                customerId,
                driversLicenseData.CustomerId);
            Assert.Equal(
                documentId,
                driversLicenseData.DocumentId);
            Assert.Equal(
                issuingCountry,
                driversLicenseData.IssuingCountry);
            Assert.Equal(
                middleNameTruncated,
                driversLicenseData.MiddleNameTruncated);
            Assert.Equal(
                firstNameTruncated,
                driversLicenseData.FirstNameTruncated);
            Assert.Equal(
                lastNameTruncated,
                driversLicenseData.LastNameTruncated);
            Assert.Equal(
                placeOfBirth,
                driversLicenseData.PlaceOfBirth);
            Assert.Equal(
                auditInformation,
                driversLicenseData.AuditInformation);
            Assert.Equal(
                inventoryControl,
                driversLicenseData.InventoryControl);
            Assert.Equal(
                lastNameAlias,
                driversLicenseData.LastNameAlias);
            Assert.Equal(
                firstNameAlias,
                driversLicenseData.FirstNameAlias);
            Assert.Equal(
                suffixAlias,
                driversLicenseData.SuffixAlias);
            Assert.Equal(
                nameSuffix,
                driversLicenseData.NameSuffix);
        }
    }
}