﻿using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses;

public sealed class Delaware : IParseableLicense
{
    /// <inheritdoc />
    public string FullName => "Delaware";

    /// <inheritdoc />
    public string Abbreviation => "DE";

    /// <inheritdoc />
    public IssuingCountry Country => IssuingCountry.UnitedStates;

    /// <inheritdoc />
    public int IssuerIdentificationNumber => 636011;

    /// <inheritdoc />
    public bool IsDataFromEntity(string? data) =>
        data?.Contains(IssuerIdentificationNumber.ToString()) == true;

    /// <inheritdoc />
    public DriversLicenseData ParseData(string? data) =>
        ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);
}