using System;
using DLP.Core.Helpers;

namespace DLP.Core.Exceptions;

/// <summary>
/// Exception: The provided data could not be matched to a known format.
/// </summary>
[Serializable]
public sealed class LicenseFormatException : Exception
{
    /// <summary>
    /// The raw string that was trying to be parsed.
    /// </summary>
    public string? LicenseData { get; }

    /// <summary>
    /// The provided data could not be matched to a known format.
    /// </summary>
    /// <param name="data">The raw string that was trying to be parsed.</param>
    public LicenseFormatException(string? data)
        : base(Constants.ErrorMessages.LicenseFormatExceptionMessage)
    {
        LicenseData = data;
        HelpLink = Constants.LicenseFormatExceptionHelpUrl.ToString();
    }

    /// <inheritdoc />
    public override string ToString() =>
        $"{Message}{Environment.NewLine}License Data: {LicenseData}{Environment.NewLine}{StackTrace}";
}