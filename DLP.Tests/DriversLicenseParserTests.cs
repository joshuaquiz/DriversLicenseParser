using System;
using System.Collections.Generic;
using DLP.Core;
using DLP.Core.Exceptions;
using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using Moq;
using Xunit;

namespace DLP.Tests
{
    public static class DriversLicenseParserTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void ThrowsArgumentNullExceptionIfNullDataProvided(string data)
        {
            // Setup.
            var driversLicenseParser = new DriversLicenseParser(null);

            // Act.
            var exception = Assert.Throws<ArgumentNullException>(() => driversLicenseParser.Parse(data));

            // Assert.
            Assert.Equal("Value cannot be null. (Parameter 'data')", exception.Message);
        }

        [Fact]
        public static void ThrowsLicenseFormatExceptionIfNoProvidersFoundForData()
        {
            // Setup.
            var data = Guid.NewGuid().ToString();
            var driversLicenseParser = new DriversLicenseParser(null);

            // Act.
            var exception = Assert.Throws<LicenseFormatException>(
                () => driversLicenseParser.Parse(data));

            // Assert.
            Assert.Equal(LicenseFormatException.ErrorMessage, exception.Message);
            Assert.Equal(data, exception.LicenseData);
            Assert.Equal(Constants.ProjectWikiUri.ToString(), exception.HelpLink);
        }

        [Fact]
        public static void ParsesDataCorrectly()
        {
            // Setup.
            var data = Guid.NewGuid().ToString();
            var id = Guid.NewGuid().ToString();
            var notTheParser = new Mock<IParseableLicense>(MockBehavior.Strict);
            notTheParser
                .Setup(x => x.IsDataFromEntity(data))
                .Returns(false);
            var theParser = new Mock<IParseableLicense>(MockBehavior.Strict);
            theParser
                .Setup(x => x.IsDataFromEntity(data))
                .Returns(true);
            theParser
                .Setup(x => x.ParseData(data))
                .Returns(
                    new DriversLicenseData
                    {
                        DocumentId = id
                    });
            var parsers = new List<IParseableLicense>
            {
                notTheParser.Object,
                theParser.Object
            };
            var driversLicenseParser = new DriversLicenseParser(parsers);

            // Act.
            var result = driversLicenseParser.Parse(data);

            // Assert.
            notTheParser.VerifyAll();
            theParser.VerifyAll();
            Assert.Equal(id, result.DocumentId);
        }
    }
}