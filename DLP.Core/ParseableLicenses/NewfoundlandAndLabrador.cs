using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class NewfoundlandAndLabrador : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Newfoundland and Labrador";

    /// <inheritdoc />
    public string Abbreviation => "NL";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Canada;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636016;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}