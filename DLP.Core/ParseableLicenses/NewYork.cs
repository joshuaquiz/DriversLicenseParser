using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class NewYork : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "New York";

    /// <inheritdoc />
    public string Abbreviation => "NY";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636001;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}