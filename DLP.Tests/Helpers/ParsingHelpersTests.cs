using DLP.Core.Helpers;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using System;
using System.Collections.Generic;
using Xunit;

namespace DLP.Tests.Helpers
{
    public static class ParsingHelpersTests
    {
        [Fact]
        public static void TryGetValueWorksWhenValueIsThere()
        {
            // Setup.
            var key = Guid.NewGuid().ToString();
            var value = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>
            {
                {
                    key,
                    value
                }
            };

            // Act.
            var result = data.TryGetValue(key);

            // Assert.
            Assert.Equal(value, result);
        }

        [Fact]
        public static void TryGetValueWorksWhenValueIsNotThere()
        {
            // Setup.
            var key = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>();

            // Act.
            var result = data.TryGetValue(key);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndLastNameIsThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "lastName";
            var value = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    value
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Equal(value, result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndLastNameIsNotThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "lastName";
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    string.Empty
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndFirstNameIsThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "firstName";
            var value = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA," + value
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Equal(value, result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndFirstNameIsNotThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "firstName";
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA"
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndMiddleNameIsThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "middleName";
            var value = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA,NA," + value
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Equal(value, result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndMiddleNameIsNotThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "middleName";
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA,NA"
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndSuffixIsThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "suffix";
            var value = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA,NA,NA," + value
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Equal(value, result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndSuffixIsNotThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "suffix";
            var data = new Dictionary<string, string>
            {
                {
                    dataKey,
                    "NA,NA,NA"
                }
            };

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsNotThere()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            const string namePart = "suffix";
            var data = new Dictionary<string, string>();

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenUnknownNamePartIsProvided()
        {
            // Setup.
            var dataKey = Guid.NewGuid().ToString();
            var namePart = Guid.NewGuid().ToString();
            var data = new Dictionary<string, string>();

            // Act.
            var result = data.ParseDriverLicenseName(dataKey, namePart);

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void GetLicenseVersionParsesCorrectlyWhenKnownVersionProvided()
        {
            // Setup.
            var versionString = new Michigan().IssuerIdentificationNumber + "01Data";

            // Act.
            var result = ParsingHelpers.GetLicenseVersion(versionString);

            // Assert.
            Assert.Equal(LicenseVersion.Version1, result);
        }

        [Fact]
        public static void GetLicenseVersionParsesCorrectlyWhenUnknownVersionProvided()
        {
            // Setup.
            var versionString = new Michigan().IssuerIdentificationNumber + "10Data";

            // Act.
            var result = ParsingHelpers.GetLicenseVersion(versionString);

            // Assert.
            Assert.Equal(LicenseVersion.UnknownVersion, result);
        }

        [Fact]
        public static void GetLicenseVersionParsesCorrectlyWhenInvalidDataIsProvided()
        {
            // Setup.
            var versionString = Guid.NewGuid().ToString();

            // Act.
            var result = ParsingHelpers.GetLicenseVersion(versionString);

            // Assert.
            Assert.Equal(LicenseVersion.UnknownVersion, result);
        }

        [Fact]
        public static void TrimToLengthTrimsCorrectlyWhenStringIsLongerThanTrimLength()
        {
            // Setup.
            var data = Guid.NewGuid().ToString();

            // Act.
            var result = data.TrimToLength(5);

            // Assert.
            Assert.Equal(data[..5], result);
        }

        [Fact]
        public static void TrimToLengthTrimsCorrectlyWhenStringIsShorterThanTrimLength()
        {
            // Setup.
            var data = Guid.NewGuid().ToString();

            // Act.
            var result = data.TrimToLength(500);

            // Assert.
            Assert.Equal(data, result);
        }

        [Fact]
        public static void RemoveFirstOccurrenceWorksCorrectlyWhenNullIsProvided()
        {
            // Setup.
            const string data = "data";

            // Act.
            var result = data.RemoveFirstOccurrence(null);

            // Assert.
            Assert.Equal(data, result);
        }

        [Fact]
        public static void RemoveFirstOccurrenceWorksCorrectlyWhenEmptyStringIsProvided()
        {
            // Setup.
            const string data = "data";

            // Act.
            var result = data.RemoveFirstOccurrence(string.Empty);

            // Assert.
            Assert.Equal(data, result);
        }

        [Fact]
        public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereAreNoOccurrences()
        {
            // Setup.
            const string data = "data";

            // Act.
            var result = data.RemoveFirstOccurrence("5");

            // Assert.
            Assert.Equal(data, result);
        }

        [Fact]
        public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereIsOneOccurrence()
        {
            // Setup.
            const string data = "d5ata";

            // Act.
            var result = data.RemoveFirstOccurrence("5");

            // Assert.
            Assert.Equal("data", result);
        }

        [Fact]
        public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereAreSeveralOccurrences()
        {
            // Setup.
            const string data = "5d5a5t5a5";

            // Act.
            var result = data.RemoveFirstOccurrence("5");

            // Assert.
            Assert.Equal("d5a5t5a5", result);
        }

        [Fact]
        public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenNoValidDataIsGiven()
        {
            // Setup.
            var data = Guid.NewGuid().ToString();

            // Act.
            var result = data.ParseDateTimeMdyThenYmd();

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenValidButBadlyFormattedDataIsGiven()
        {
            // Setup.
            const string data = "31012020";

            // Act.
            var result = data.ParseDateTimeMdyThenYmd();

            // Assert.
            Assert.Null(result);
        }

        [Fact]
        public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenValidFormattedDataIsGiven()
        {
            // Setup.
            const string data = "05202021";

            // Act.
            var result = data.ParseDateTimeMdyThenYmd();

            // Assert.
            Assert.Equal(new DateTimeOffset(2021, 05, 20,0, 0, 0, new TimeSpan()), result);
        }

        [Theory]
        [InlineData("USA", IssuingCountry.UnitedStates)]
        [InlineData("CAN", IssuingCountry.Canada)]
        [InlineData("", IssuingCountry.Unknown)]
        [InlineData(null, IssuingCountry.Unknown)]
        [InlineData("lol", IssuingCountry.Unknown)]
        public static void ParseIssuingCountryWorksCorrectly(string input, IssuingCountry expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseIssuingCountry());

        [Theory]
        [InlineData("T", Truncation.Truncated)]
        [InlineData("N", Truncation.None)]
        [InlineData("", Truncation.Unknown)]
        [InlineData(null, Truncation.Unknown)]
        [InlineData("lol", Truncation.Unknown)]
        public static void ParseTruncationWorksCorrectly(string input, Truncation expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseTruncation());

        [Theory]
        [InlineData("1", Gender.Male)]
        [InlineData("2", Gender.Female)]
        [InlineData("", Gender.Unknown)]
        [InlineData(null, Gender.Unknown)]
        [InlineData("lol", Gender.Unknown)]
        public static void ParseGenderWorksCorrectly(string input, Gender expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseGender());

        [Theory]
        [InlineData("BLK", EyeColor.Black)]
        [InlineData("BLU", EyeColor.Blue)]
        [InlineData("BRO", EyeColor.Brown)]
        [InlineData("GRY", EyeColor.Gray)]
        [InlineData("GRN", EyeColor.Green)]
        [InlineData("HAZ", EyeColor.Hazel)]
        [InlineData("MAR", EyeColor.Maroon)]
        [InlineData("PNK", EyeColor.Pink)]
        [InlineData("DIC", EyeColor.Dichromatic)]
        [InlineData("", EyeColor.Unknown)]
        [InlineData(null, EyeColor.Unknown)]
        [InlineData("lol", EyeColor.Unknown)]
        public static void ParseEyeColorWorksCorrectly(string input, EyeColor expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseEyeColor());

        [Theory]
        [InlineData("JR", NameSuffix.Junior)]
        [InlineData("SR", NameSuffix.Senior)]
        [InlineData("1ST", NameSuffix.First)]
        [InlineData("I", NameSuffix.First)]
        [InlineData("2ND", NameSuffix.Second)]
        [InlineData("II", NameSuffix.Second)]
        [InlineData("3RD", NameSuffix.Third)]
        [InlineData("III", NameSuffix.Third)]
        [InlineData("4TH", NameSuffix.Fourth)]
        [InlineData("IV", NameSuffix.Fourth)]
        [InlineData("5TH", NameSuffix.Fifth)]
        [InlineData("V", NameSuffix.Fifth)]
        [InlineData("6TH", NameSuffix.Sixth)]
        [InlineData("VI", NameSuffix.Sixth)]
        [InlineData("7TH", NameSuffix.Seventh)]
        [InlineData("VII", NameSuffix.Seventh)]
        [InlineData("8TH", NameSuffix.Eighth)]
        [InlineData("VIII", NameSuffix.Eighth)]
        [InlineData("9TH", NameSuffix.Ninth)]
        [InlineData("iX", NameSuffix.Ninth)]
        [InlineData("", NameSuffix.Unknown)]
        [InlineData(null, NameSuffix.Unknown)]
        [InlineData("lol", NameSuffix.Unknown)]
        public static void ParseNameSuffixWorksCorrectly(string input, NameSuffix expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseNameSuffix());

        [Theory]
        [InlineData("BAL", HairColor.Bald)]
        [InlineData("BLK", HairColor.Black)]
        [InlineData("BLN", HairColor.Blond)]
        [InlineData("BRO", HairColor.Brown)]
        [InlineData("GRY", HairColor.Grey)]
        [InlineData("RED", HairColor.Red)]
        [InlineData("SDY", HairColor.Sandy)]
        [InlineData("WHI", HairColor.White)]
        [InlineData("", HairColor.Unknown)]
        [InlineData(null, HairColor.Unknown)]
        [InlineData("lol", HairColor.Unknown)]
        public static void ParseHairColorWorksCorrectly(string input, HairColor expectedResult) =>
            Assert.Equal(
                expectedResult,
                input.ParseHairColor());

        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData("   ", null)]
        [InlineData("lol", null)]
        [InlineData("80", 80)]
        [InlineData("80 in", 80)]
        [InlineData("80IN", 80)]
        [InlineData("80cm", 31.49608)]
        [InlineData("80 CM", 31.49608)]
        [InlineData("506", 66)]
        public static void ParseHeightInInchesWorksCorrectly(string input, double? expectedResult) =>
            Assert.Equal(
                expectedResult == null
                    ? (decimal?)null
                    : Convert.ToDecimal(expectedResult),
                input.ParseHeightInInches());
    }
}