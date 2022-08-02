using DLP.Core.Helpers;
using FluentAssertions;
using Xunit;

namespace DLP.Tests.Helpers
{
    public static class ConstantsTests
    {
        [Fact]
        public static void LicenseFormatExceptionHelpUrlIsCorrect() =>
            Constants.LicenseFormatExceptionHelpUrl
                .ToString()
                .Should()
                .Be("https://github.com/joshuaquiz/DriversLicenseParser/wiki/License-Data-Formatting");

        [Fact]
        public static void InchesPerCentimeterIsCorrect() =>
            Constants.InchesPerCentimeter
                .Should()
                .Be(0.393701M);

        [Fact]
        public static void ErrorMessagesLicenseFormatExceptionMessageIsCorrect() =>
            Constants.ErrorMessages.LicenseFormatExceptionMessage
                .Should()
                .Be("The provided data could not be matched to a known format.");
    }
}