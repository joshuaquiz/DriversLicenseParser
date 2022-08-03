using DLP.Core.Helpers;
using DLP.Core.Models.Enums;
using DLP.Core.ParseableLicenses;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using Xunit;

namespace DLP.Tests.Helpers;

public static class ParsingHelpersTests
{
    [Fact]
    public static void TryGetValueWorksWhenValueIsThere()
    {
        // Arrange.
        var key = Guid.NewGuid().ToString();
        var value = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>
        {
            {
                key,
                value
            }
        };

        // Act.
        var result = data.TryGetValue(key);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(value);
        }
    }

    [Fact]
    public static void TryGetValueWorksWhenValueIsNotThere()
    {
        // Arrange.
        var key = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>();

        // Act.
        var result = data.TryGetValue(key);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueHasSpaceInvalidNameTypeProvided()
    {
        // Arrange.
        const NamePart namePart = NamePart.Undefined;
        const string value = "Jones ";

        // Act.
        var result = value.ParseDriverLicenseName(namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueHasCommaInvalidNameTypeProvided()
    {
        // Arrange.
        const NamePart namePart = NamePart.Undefined;
        const string value = "Jones,";

        // Act.
        var result = value.ParseDriverLicenseName(namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndLastNameIsThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.LastName;
        var value = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                value
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(value);
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndLastNameIsThereAndSuffixExists()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.LastName;
        const string lastName = "Jones";
        const string value = "Jim " + lastName + " II";
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                value
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(lastName);
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndOnlyLastNameIsThere()
    {
        // Arrange.
        const NamePart namePart = NamePart.LastName;
        const string value = "Jones ";

        // Act.
        var result = value.ParseDriverLicenseName(namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndLastNameIsNotThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.LastName;
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                string.Empty
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndFirstNameIsThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.FirstName;
        var value = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA," + value
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(value);
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndFirstNameIsNotThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.FirstName;
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA"
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndMiddleNameIsThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.MiddleName;
        var value = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA,NA," + value
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(value);
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndMiddleNameIsNotThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.MiddleName;
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA,NA"
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndSuffixIsThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.Suffix;
        var value = Guid.NewGuid().ToString();
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA,NA,NA," + value
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(value);
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsThereAndSuffixIsNotThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.Suffix;
        var data = new Dictionary<string, string?>
        {
            {
                dataKey,
                "NA,NA,NA"
            }
        };

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenValueIsNotThere()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.Suffix;
        var data = new Dictionary<string, string?>();

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDriverLicenseNameParsesNamePartCorrectlyWhenUnknownNamePartIsProvided()
    {
        // Arrange.
        var dataKey = Guid.NewGuid().ToString();
        const NamePart namePart = NamePart.Undefined;
        var data = new Dictionary<string, string?>();

        // Act.
        var result = data.ParseDriverLicenseName(dataKey, namePart);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void GetLicenseVersionParsesCorrectlyWhenKnownVersionProvided()
    {
        // Arrange.
        var versionString = new Michigan().IssuerIdentificationNumber + "01Data";

        // Act.
        var result = ParsingHelpers.GetLicenseVersion(versionString);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(LicenseVersion.Version1);
        }
    }

    [Fact]
    public static void GetLicenseVersionParsesCorrectlyWhenUnknownVersionProvided()
    {
        // Arrange.
        var versionString = new Michigan().IssuerIdentificationNumber + "10Data";

        // Act.
        var result = ParsingHelpers.GetLicenseVersion(versionString);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(LicenseVersion.UnknownVersion);
        }
    }

    [Fact]
    public static void GetLicenseVersionParsesCorrectlyWhenInvalidDataIsProvided()
    {
        // Arrange.
        var versionString = Guid.NewGuid().ToString();

        // Act.
        var result = ParsingHelpers.GetLicenseVersion(versionString);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(LicenseVersion.UnknownVersion);
        }
    }

    [Fact]
    public static void TrimToLengthTrimsCorrectlyWhenStringIsLongerThanTrimLength()
    {
        // Arrange.
        var data = Guid.NewGuid().ToString();

        // Act.
        var result = data.TrimToLength(5);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(data[..5]);
        }
    }

    [Fact]
    public static void TrimToLengthTrimsCorrectlyWhenStringIsShorterThanTrimLength()
    {
        // Arrange.
        var data = Guid.NewGuid().ToString();

        // Act.
        var result = data.TrimToLength(500);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(data);
        }
    }

    [Fact]
    public static void RemoveFirstOccurrenceWorksCorrectlyWhenNullIsProvided()
    {
        // Arrange.
        const string data = "data";

        // Act.
        var result = data.RemoveFirstOccurrence(null);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(data);
        }
    }

    [Fact]
    public static void RemoveFirstOccurrenceWorksCorrectlyWhenEmptyStringIsProvided()
    {
        // Arrange.
        const string data = "data";

        // Act.
        var result = data.RemoveFirstOccurrence(string.Empty);

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(data);
        }
    }

    [Fact]
    public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereAreNoOccurrences()
    {
        // Arrange.
        const string data = "data";

        // Act.
        var result = data.RemoveFirstOccurrence("5");

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(data);
        }
    }

    [Fact]
    public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereIsOneOccurrence()
    {
        // Arrange.
        const string data = "d5ata";

        // Act.
        var result = data.RemoveFirstOccurrence("5");

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be("data");
        }
    }

    [Fact]
    public static void RemoveFirstOccurrenceWorksCorrectlyWhenThereAreSeveralOccurrences()
    {
        // Arrange.
        const string data = "5d5a5t5a5";

        // Act.
        var result = data.RemoveFirstOccurrence("5");

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be("d5a5t5a5");
        }
    }

    [Fact]
    public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenNoValidDataIsGiven()
    {
        // Arrange.
        var data = Guid.NewGuid().ToString();

        // Act.
        var result = data.ParseDateTimeMdyThenYmd();

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenValidButBadlyFormattedDataIsGiven()
    {
        // Arrange.
        const string data = "31012020";

        // Act.
        var result = data.ParseDateTimeMdyThenYmd();

        // Assert.
        using (new AssertionScope())
        {
            result.Should().BeNull();
        }
    }

    [Fact]
    public static void ParseDateTimeMonthDayYearWorksCorrectlyWhenValidFormattedDataIsGiven()
    {
        // Arrange.
        const string data = "05202021";

        // Act.
        var result = data.ParseDateTimeMdyThenYmd();

        // Assert.
        using (new AssertionScope())
        {
            result.Should().Be(new DateTimeOffset(2021, 05, 20, 0, 0, 0, new TimeSpan()));
        }
    }

    [Theory]
    [InlineData("USA", IssuingCountry.UnitedStates)]
    [InlineData("CAN", IssuingCountry.Canada)]
    [InlineData("", IssuingCountry.Unknown)]
    [InlineData(null, IssuingCountry.Unknown)]
    [InlineData("lol", IssuingCountry.Unknown)]
    public static void ParseIssuingCountryWorksCorrectly(string input, IssuingCountry expectedResult) =>
        input.ParseIssuingCountry().Should().Be(expectedResult);

    [Theory]
    [InlineData("T", Truncation.Truncated)]
    [InlineData("N", Truncation.None)]
    [InlineData("", Truncation.Unknown)]
    [InlineData(null, Truncation.Unknown)]
    [InlineData("lol", Truncation.Unknown)]
    public static void ParseTruncationWorksCorrectly(string input, Truncation expectedResult) =>
        input.ParseTruncation().Should().Be(expectedResult);

    [Theory]
    [InlineData("1", Gender.Male)]
    [InlineData("2", Gender.Female)]
    [InlineData("", Gender.Unknown)]
    [InlineData(null, Gender.Unknown)]
    [InlineData("lol", Gender.Unknown)]
    public static void ParseGenderWorksCorrectly(string input, Gender expectedResult) =>
        input.ParseGender().Should().Be(expectedResult);

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
        input.ParseEyeColor().Should().Be(expectedResult);

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
        input.ParseNameSuffix().Should().Be(expectedResult);

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
        input.ParseHairColor().Should().Be(expectedResult);

    [Theory]
    [InlineData(null, null)]
    [InlineData("", null)]
    [InlineData("   ", null)]
    [InlineData("lol", null)]
    [InlineData("80", 80D)]
    [InlineData("80 in", 80D)]
    [InlineData("80IN", 80D)]
    [InlineData("80cm", 31.49608D)]
    [InlineData("80 CM", 31.49608D)]
    [InlineData("506", 66D)]
    [InlineData("5-10", 70D)]
    public static void ParseHeightInInchesWorksCorrectly(string input, double? expectedResult) =>
        input.ParseHeightInInches()
            .Should()
            .Be(
                expectedResult == null
                    ? null
                    : Convert.ToDecimal(expectedResult));
}