using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.Parsers;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of Washington.
/// </summary>
public sealed class Washington : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Washington";

    /// <inheritdoc />
    public string Abbreviation => "WA";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636045;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data)
    {
        var driversLicenseData = ParsingHelpers.BasicDriversLicenseParser(
            data,
            Country,
            out var splitUpData);
        if (driversLicenseData.LicenseVersion == LicenseVersion.Version3)
        {
            if (splitUpData.TryGetValue(Version3StandardParser.Version3StandardMarkers.FirstNameMarker, out var firstName))
            {
                var nameParts = firstName?.Split(' ');
                if (nameParts?.Length == 2)
                {
                    driversLicenseData.FirstName = nameParts[0];
                    driversLicenseData.MiddleName = nameParts[1];
                }
            }
        }

        return driversLicenseData;
    }
}