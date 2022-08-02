using System;
using DLP.Core.Helpers;

namespace DLP.Core.Exceptions;

[Serializable]
public sealed class LicenseFormatException : Exception
{
    public string LicenseData { get; }

    public LicenseFormatException(string data)
        : base(Constants.ErrorMessages.LicenseFormatExceptionMessage)
    {
        LicenseData = data;
        HelpLink = Constants.LicenseFormatExceptionHelpUrl.ToString();
    }

    public override string ToString() =>
        $"{Message}{Environment.NewLine}License Data: {LicenseData}{Environment.NewLine}{StackTrace}";
}