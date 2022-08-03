using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Quebec : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Quebec";

    /// <inheritdoc />
    public string Abbreviation => "QC";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Canada;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 604428;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}