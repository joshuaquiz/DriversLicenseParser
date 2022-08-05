using System;
using System.Collections.Generic;
using System.Linq;
using DLP.Core.Exceptions;
using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core;

/// <summary>
/// Drivers license parser entry point.
/// </summary>
public sealed class DriversLicenseParser : IDriversLicenseParser
{
    private readonly IReadOnlyCollection<IParseableLicense>? _parseableLicenses;

    /// <summary>
    /// Drivers license parser entry ctor.
    /// </summary>
    /// <param name="parseableLicenses">All parseable licenses.</param>
    public DriversLicenseParser(IEnumerable<IParseableLicense>? parseableLicenses)
    {
        _parseableLicenses = parseableLicenses?.ToList();
    }

    /// <inheritdoc />
    public DriversLicenseData Parse(string? data)
    {
        if (string.IsNullOrWhiteSpace(data))
        {
            throw new ArgumentNullException(nameof(data));
        }

        var license = _parseableLicenses?.FirstOrDefault(x => x.IsDataFromEntity(data))
            ?? throw new LicenseFormatException(data);
        return license.ParseData(data);
    }
}