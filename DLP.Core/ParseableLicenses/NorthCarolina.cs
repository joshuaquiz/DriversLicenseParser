﻿using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

/// <summary>
/// Represents a license from the US state of North Carolina.
/// </summary>
public sealed class NorthCarolina : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "North Carolina";

    /// <inheritdoc />
    public string Abbreviation => "NC";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636004;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    private const string StreetAddressMarkerBackup = "DAL";

    private const string CityMarkerBackup = "DAN";

    private const string StateMarkerBackup = "DAO";

    private const string PostalCodeMarkerBackup = "DAP";

    private const string DocumentIdMarkerBackup = "DAQ";

    private const string HeightMarkerBackup = "DAV";

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data)
    {
        var driversLicenseData = ParsingHelpers.BasicDriversLicenseParser(
            data,
            Country,
            out var splitUpData);
        if (driversLicenseData.LicenseVersion == LicenseVersion.Version1)
        {
            driversLicenseData.StreetAddress ??= splitUpData.TryGetValue(StreetAddressMarkerBackup);
            driversLicenseData.City ??= splitUpData.TryGetValue(CityMarkerBackup);
            driversLicenseData.State ??= splitUpData.TryGetValue(StateMarkerBackup);
            driversLicenseData.PostalCode ??= splitUpData.TryGetValue(PostalCodeMarkerBackup);
            driversLicenseData.DocumentId ??= splitUpData.TryGetValue(DocumentIdMarkerBackup);
            driversLicenseData.Height ??= splitUpData.TryGetValue(HeightMarkerBackup).ParseHeightInInches();
        }

        return driversLicenseData;
    }
}