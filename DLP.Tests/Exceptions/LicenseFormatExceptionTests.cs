using DLP.Core.Exceptions;
using DLP.Core.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using Xunit;

namespace DLP.Tests.Exceptions;

public static class LicenseFormatExceptionTests
{
    [Fact]
    public static void MessageIsCorrect()
    {
        // Arrange.
        var licenseFormatException = new LicenseFormatException(null);

        // Assert.
        using (new AssertionScope())
        {
            Constants.ErrorMessages.LicenseFormatExceptionMessage
                .Should()
                .Be(licenseFormatException.Message);
        }
    }

    [Fact]
    public static void HelpLinkIsCorrect()
    {
        // Arrange.
        var licenseFormatException = new LicenseFormatException(null);

        // Assert.
        using (new AssertionScope())
        {
            Constants.LicenseFormatExceptionHelpUrl.ToString()
                .Should()
                .Be(licenseFormatException.HelpLink);
        }
    }

    [Fact]
    public static void LicenseDataIsCorrect()
    {
        // Arrange.
        var licenseData = Guid.NewGuid().ToString();
        var licenseFormatException = new LicenseFormatException(licenseData);

        // Assert.
        using (new AssertionScope())
        {
            licenseFormatException.LicenseData
                .Should()
                .Be(licenseData);
        }
    }

    [Fact]
    public static void ToStringIsCorrect()
    {
        // Arrange.
        var licenseData = Guid.NewGuid().ToString();
        var licenseFormatException = new LicenseFormatException(licenseData);

        // Act.
        var result = licenseFormatException.ToString();

        // Assert.
        using (new AssertionScope())
        {
            result
                .Should()
                .Be($"{Constants.ErrorMessages.LicenseFormatExceptionMessage}{Environment.NewLine}License Data: {licenseData}{Environment.NewLine}");
        }
    }
}