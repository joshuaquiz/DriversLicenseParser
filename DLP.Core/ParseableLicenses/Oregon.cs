using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of Oregon.
/// </summary>
public sealed class Oregon : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Oregon";

    /// <inheritdoc />
    public string Abbreviation => "OR";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636029;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    private const string StreetAddressMarkerBackup = "DAL";

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data)
    {
        var driversLicenseData = ParsingHelpers.BasicDriversLicenseParser(
            data,
            Country,
            out var splitUpData);
        if (driversLicenseData.LicenseVersion == LicenseVersion.Version1)
        {
            if (string.IsNullOrWhiteSpace(driversLicenseData.StreetAddress))
            {
                driversLicenseData.StreetAddress = splitUpData.TryGetValue(StreetAddressMarkerBackup);
            }
        }

        return driversLicenseData;
    }
}