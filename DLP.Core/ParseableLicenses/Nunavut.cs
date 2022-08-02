using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Nunavut : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Nunavut";

    /// <inheritdoc />
    public string Abbreviation => "NU";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Canada;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 604433;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}