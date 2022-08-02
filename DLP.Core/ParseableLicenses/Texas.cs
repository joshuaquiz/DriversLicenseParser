using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Texas : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Texas";

    /// <inheritdoc />
    public string Abbreviation => "TX";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636015;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}