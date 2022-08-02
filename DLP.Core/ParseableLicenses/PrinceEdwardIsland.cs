using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class PrinceEdwardIsland : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Prince Edward Island ";

    /// <inheritdoc />
    public string Abbreviation => "PE";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Canada;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 604426;

    /// <inheritdoc />
    public bool IsDataFromEntity(string data) =>
        data.Contains(IssuerIdentificationNumber.ToString());

    /// <inheritdoc />
    public DriversLicenseData ParseData(string data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}