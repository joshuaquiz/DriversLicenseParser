using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of Wyoming.
/// </summary>
public sealed class Wyoming : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Wyoming";

    /// <inheritdoc />
    public string Abbreviation => "WY";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636060;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data)
    {
        var driversLicenseData = ParsingHelpers.BasicDriversLicenseParser(
            data,
            Country,
            out _);
        if (driversLicenseData.LicenseVersion == LicenseVersion.Version4)
        {
            if (driversLicenseData.FirstName?.Contains(' ') == true
                && string.IsNullOrWhiteSpace(driversLicenseData.MiddleName))
            {
                var firstSpaceIndex = driversLicenseData.FirstName.IndexOf(' ', StringComparison.InvariantCultureIgnoreCase);
                driversLicenseData.MiddleName = driversLicenseData.FirstName[firstSpaceIndex..].Trim();
                driversLicenseData.FirstName = driversLicenseData.FirstName.Remove(firstSpaceIndex);
            }
        }

        return driversLicenseData;
    }
}