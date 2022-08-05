using DLP.Core.Exceptions;
using DLP.Core.Models;
using System;

namespace DLP.Core.Interfaces;

/// <summary>
/// Drivers license parser.
/// </summary>
public interface IDriversLicenseParser
{
    /// <summary>
    /// Attempts to parse the license data.
    /// </summary>
    /// <param name="data">The license data.</param>
    /// <exception cref="ArgumentNullException">Thrown if the provided data is empty or null.</exception>
    /// <exception cref="LicenseFormatException">Thrown if the data could not be matched to any known format.</exception>
    /// <returns><see cref="DriversLicenseData"/></returns>
    public DriversLicenseData Parse(string? data);
}