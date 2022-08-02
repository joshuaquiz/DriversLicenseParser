using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of Michigan.
/// </summary>
public sealed class Michigan : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Michigan";

    /// <inheritdoc />
    public string Abbreviation => "MI";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636032;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}