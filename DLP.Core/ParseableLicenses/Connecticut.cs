using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Connecticut : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Connecticut";

    /// <inheritdoc />
    public string Abbreviation => "CT";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636006;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}