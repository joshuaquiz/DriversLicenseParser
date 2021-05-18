using DLP.Core.Exceptions;
using DLP.Core.Helpers;
using System;
using Xunit;

namespace DLP.Tests.Exceptions
{
    public static class LicenseFormatExceptionTests
    {
        [Fact]
        public static void MessageIsCorrect()
        {
            // Setup.
            var licenseFormatException = new LicenseFormatException(null);

            // Assert.
            Assert.Equal(
                Constants.ErrorMessages.LicenseFormatExceptionMessage,
                licenseFormatException.Message);
        }

        [Fact]
        public static void HelpLinkIsCorrect()
        {
            // Setup.
            var licenseFormatException = new LicenseFormatException(null);

            // Assert.
            Assert.Equal(
                Constants.LicenseFormatExceptionHelpUrl.ToString(),
                licenseFormatException.HelpLink);
        }

        [Fact]
        public static void LicenseDataIsCorrect()
        {
            // Setup.
            var licenseData = Guid.NewGuid().ToString();
            var licenseFormatException = new LicenseFormatException(licenseData);

            // Assert.
            Assert.Equal(
                licenseData,
                licenseFormatException.LicenseData);
        }

        [Fact]
        public static void ToStringIsCorrect()
        {
            // Setup.
            var licenseData = Guid.NewGuid().ToString();
            var licenseFormatException = new LicenseFormatException(licenseData);

            // Act.
            var result = licenseFormatException.ToString();

            // Assert.
            Assert.Equal(
                $"{Constants.ErrorMessages.LicenseFormatExceptionMessage}{Environment.NewLine}License Data: {licenseData}{Environment.NewLine}",
                result);
        }
    }
}