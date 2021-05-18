using DLP.Core.Helpers;
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
    }
}