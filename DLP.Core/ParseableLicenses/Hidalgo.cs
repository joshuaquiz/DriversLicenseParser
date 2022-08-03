using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Hidalgo : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Hidalgo";

    /// <inheritdoc />
    public string Abbreviation => "HL";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Mexico;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636057;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}