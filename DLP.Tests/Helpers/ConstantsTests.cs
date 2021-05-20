using DLP.Core.Helpers;
using Xunit;

namespace DLP.Tests.Helpers
{
    public static class ConstantsTests
    {
        [Fact]
        public static void LicenseFormatExceptionHelpUrlIsCorrect() =>
            Assert.Equal(
                "https://github.com/joshuaquiz/DriversLicenseParser/wiki/License-Data-Formatting",
                Constants.LicenseFormatExceptionHelpUrl.ToString());

        [Fact]
        public static void InchesPerCentimeterIsCorrect() =>
            Assert.Equal(
                0.393701M,
                Constants.InchesPerCentimeter);

        [Fact]
        public static void ErrorMessagesLicenseFormatExceptionMessageIsCorrect() =>
            Assert.Equal(
                "The provided data could not be matched to a known format.",
                Constants.ErrorMessages.LicenseFormatExceptionMessage);
    }
}