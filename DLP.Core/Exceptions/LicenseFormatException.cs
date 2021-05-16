using System;
using DLP.Core.Helpers;

namespace DLP.Core.Exceptions
{
    [Serializable]
    public sealed class LicenseFormatException : Exception
    {
        public const string ErrorMessage =
            "The provided data could not be matched to a known format.";

        public string LicenseData { get; }

        public LicenseFormatException(string data)
            : base(ErrorMessage)
        {
            LicenseData = data;
            HelpLink = Constants.ProjectWikiUri.ToString();
        }
    }
}