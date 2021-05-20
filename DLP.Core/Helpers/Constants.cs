using System;

namespace DLP.Core.Helpers
{
    /// <summary>
    /// Constants for this project.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The project wiki URL.
        /// </summary>
        public static readonly Uri LicenseFormatExceptionHelpUrl =
            new("https://github.com/joshuaquiz/DriversLicenseParser/wiki/License-Data-Formatting", UriKind.Absolute);

        /// <summary>
        /// A double that represents how man inches are in a centimeter.
        /// </summary>
        public const decimal InchesPerCentimeter = 0.393701M;

        /// <summary>
        /// All Error messages should be here.
        /// </summary>
        public static class ErrorMessages
        {
            /// <summary>
            /// The provided data could not be matched to a known format.
            /// </summary>
            public const string LicenseFormatExceptionMessage =
                "The provided data could not be matched to a known format.";
        }
    }
}