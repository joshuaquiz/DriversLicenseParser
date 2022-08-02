using System;
using System.Collections.Generic;
using DLP.Core;
using DLP.Core.Exceptions;
using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Xunit;

namespace DLP.Tests;

public static class DriversLicenseParserTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public static void ThrowsArgumentNullExceptionIfNullDataProvided(string data)
    {
        // Arrange.
        var driversLicenseParser = new DriversLicenseParser(null);

        // Act.
        var act = () => driversLicenseParser.Parse(data);

        // Assert.
        using (new AssertionScope())
        {
            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'data')");
        }
    }

    [Fact]
    public static void ThrowsLicenseFormatExceptionIfNoProvidersFoundForData()
    {
        // Arrange.
        var data = Guid.NewGuid().ToString();
        var driversLicenseParser = new DriversLicenseParser(null);

        // Act.
        var act = () => driversLicenseParser.Parse(data);

        // Assert.
        using (new AssertionScope())
        {
            var exception = act.Should()
                .Throw<LicenseFormatException>()
                .WithMessage(Constants.ErrorMessages.LicenseFormatExceptionMessage)
                .And;
            exception.LicenseData.Should().Be(data);
            exception.HelpLink.Should().Be(Constants.LicenseFormatExceptionHelpUrl.ToString());
        }
    }

    [Fact]
    public static void ParsesDataCorrectly()
    {
        // Arrange.
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
        using (new AssertionScope())
        {
            result.DocumentId.Should().Be(id);
            notTheParser.VerifyAll();
            theParser.VerifyAll();
        }
    }
}