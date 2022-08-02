using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class AmericanSamoa : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "American Samoa";

    /// <inheritdoc />
    public string Abbreviation => "AS";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 604427;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}