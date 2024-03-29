﻿using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Ontario : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Ontario";

    /// <inheritdoc />
    public string Abbreviation => "ON";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.Canada;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636012;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}