using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of Pennsylvania.
/// </summary>
public sealed class Pennsylvania : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Pennsylvania";

    /// <inheritdoc />
    public string Abbreviation => "PA";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636025;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data)
    {
        var licenseData = ParsingHelpers.BasicDriversLicenseParser(
            data,
            Country,
            out var splitUpData);
        licenseData.CustomerId = splitUpData["DAQ"];
        licenseData.AuditInformation = splitUpData["DL_"];
        licenseData.InventoryControl = splitUpData.ContainsKey("ANSI")
            ? splitUpData["ANSI"]
            : splitUpData["AAMVA"];
        return licenseData;
    }
}