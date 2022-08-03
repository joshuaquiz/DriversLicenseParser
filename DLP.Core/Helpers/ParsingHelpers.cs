using DLP.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using DLP.Core.Models.Enums;
using DLP.Core.Parsers;
using System.Linq;

namespace DLP.Core.Helpers;

/// <summary>
/// Helper/extension methods.
/// </summary>
public static class ParsingHelpers
{
    /// <summary>
    /// Attempts to get the value of the record with the provided key.
    /// Returns null if nothing is found.
    /// </summary>
    /// <param name="data">The dictionary to look through.</param>
    /// <param name="key">The key to check the dictionary for.</param>
    /// <returns><see cref="string"/></returns>
    public static string? TryGetValue(this IReadOnlyDictionary<string, string?> data, string key) =>
        data.TryGetValue(key, out var value)
            ? value?.Trim()
            : null;

    /// <summary>
    /// Attempts to parse the part of the name defined.
    /// Returns null if unable to extract the data.
    /// </summary>
    /// <param name="data">The dictionary to look through.</param>
    /// <param name="dataKey">The key to check the dictionary for.</param>
    /// <param name="namePart">The part of the name to extract (valid values are firstName, middleName, lastName, suffix)</param>
    /// <returns><see cref="string"/></returns>
    /// <returns></returns>
    public static string? ParseDriverLicenseName(this IReadOnlyDictionary<string, string?> data, string dataKey, NamePart namePart) =>
        ParseDriverLicenseName(data.TryGetValue(dataKey), namePart);

    /// <summary>
    /// Attempts to parse the part of the name defined.
    /// Returns null if unable to extract the data.
    /// </summary>
    /// <param name="driverLicenseName">The name to try parsing.</param>
    /// <param name="namePart">The part of the name to extract (valid values are firstName, middleName, lastName, suffix)</param>
    /// <returns><see cref="string"/></returns>
    /// <returns></returns>
    public static string? ParseDriverLicenseName(this string? driverLicenseName, NamePart namePart)
    {
        if (!string.IsNullOrWhiteSpace(driverLicenseName) && driverLicenseName.Contains(' ') && !driverLicenseName.Contains(','))
        {
            var nameParts = driverLicenseName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return namePart switch
            {
                NamePart.FirstName => nameParts.Length >= 1 ? nameParts[0] : null,
                NamePart.MiddleName => nameParts.Length switch
                {
                    3 =>
                        nameParts[1],
                    >= 4 when nameParts.LastOrDefault()?.ParseNameSuffix() == NameSuffix.Unknown =>
                        string.Join(" ", nameParts[1..^1]),
                    >= 4 when nameParts.LastOrDefault()?.ParseNameSuffix() != NameSuffix.Unknown =>
                        string.Join(" ", nameParts[1..^2]),
                    _ => null
                },
                NamePart.LastName => nameParts.Length switch
                {
                    2 =>
                        nameParts[1],
                    3 when nameParts.LastOrDefault()?.ParseNameSuffix() == NameSuffix.Unknown =>
                        nameParts[2],
                    3 when nameParts.LastOrDefault()?.ParseNameSuffix() != NameSuffix.Unknown =>
                        nameParts[1],
                    >= 3 when nameParts.LastOrDefault()?.ParseNameSuffix() == NameSuffix.Unknown =>
                        nameParts.LastOrDefault(),
                    >= 3 when nameParts.LastOrDefault()?.ParseNameSuffix() != NameSuffix.Unknown =>
                        nameParts[^2],
                    _ => null
                },
                NamePart.Suffix => nameParts.Length switch
                {
                    >= 3 when nameParts.LastOrDefault()?.ParseNameSuffix() != NameSuffix.Unknown =>
                        nameParts.Last(),
                    _ => null
                },
                _ => null
            };
        }
        else
        {
            var nameParts = driverLicenseName?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            return namePart switch
            {
                NamePart.FirstName => nameParts?.Length >= 2 ? nameParts[1] : null,
                NamePart.ShortMiddleName => nameParts?.Length >= 2 ? nameParts[1] : null,
                NamePart.MiddleName => nameParts?.Length >= 3 ? nameParts[2] : null,
                NamePart.LastName => nameParts?.Length >= 1 ? nameParts[0] : null,
                NamePart.Suffix => nameParts?.Length >= 4 ? nameParts[3] : null,
                _ => null
            };
        }
    }

    /// <summary>
    /// Tries to parse the <see cref="LicenseVersion"/> from the license data provided.
    /// </summary>
    /// <param name="data">The license data.</param>
    /// <returns><see cref="LicenseVersion"/></returns>
    public static LicenseVersion GetLicenseVersion(string? data)
    {
        try
        {
            var versionInt = int.Parse(Regex.Match(data!, "\\d{6}(\\d{2})\\w+").Groups[1].Value);
            return (LicenseVersion) Enum.Parse(typeof(LicenseVersion), $"Version{versionInt}");
        }
        catch (Exception e)
            when (e is ArgumentException
                      or ArgumentNullException
                      or FormatException
                      or RegexMatchTimeoutException
                      or ArgumentOutOfRangeException
                      or NullReferenceException)
        {
            // If any exception is thrown related to parsing the version return that the version is unknown.
            return LicenseVersion.UnknownVersion;
        }
    }

    /// <summary>
    /// Trims the string to the length specified.
    /// If the length specified is longer than the string then the string value is returned.
    /// </summary>
    /// <param name="s">The string to trim.</param>
    /// <param name="length">The length to trim to.</param>
    /// <returns><see cref="string"/></returns>
    public static string TrimToLength(this string s, int length) =>
        s.Length <= length
            ? s
            : s[..length];

    /// <summary>
    /// Returns a substring with the length specified.
    /// If the length specified is longer than the string then the string value for as much as there is will be returned.
    /// </summary>
    /// <param name="s">The string to trim.</param>
    /// <param name="startingIndex">The index to start at.</param>
    /// <param name="length">The length to trim to.</param>
    /// <returns><see cref="string"/></returns>
    public static string SubstringSafe(this string? s, int startingIndex, int length) =>
        string.IsNullOrWhiteSpace(s)
            ? string.Empty
            : s.Length <= startingIndex + length
                ? s[startingIndex..]
                : s.Substring(startingIndex, length);

    /// <summary>
    /// Removes the first occurrence of the value.
    /// </summary>
    /// <param name="haystack">Data to search in.</param>
    /// <param name="needle">What to look for.</param>
    /// <returns><see cref="string"/></returns>
    public static string? RemoveFirstOccurrence(this string? haystack, string? needle)
    {
        if (string.IsNullOrEmpty(needle)
            || string.IsNullOrWhiteSpace(haystack))
        {
            return haystack;
        }

        var index = haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase);
        return index > -1
            ? haystack.Remove(index, needle.Length)
            : haystack;
    }

    /// <summary>
    /// Trims extra 0s from the end of the zip code.
    /// </summary>
    /// <remarks>
    /// This method will return "46789" from "467890000" and "46780" from "467800000".
    /// "00000" will remain "00000" and "000000001" will remain "000000001".
    /// </remarks>
    /// <param name="zip">The zip with possible trailing 0s.</param>
    /// <returns>string</returns>
    public static string? TrimTrailingZerosFromZipCode(this string? zip) =>
        zip is { Length: 9 } && zip.EndsWith("0000")
            ? zip[..5]
            : zip;

    /// <summary>
    /// Tries to parse as a <see cref="DateTimeOffset"/> using the format MMddyyyy.
    /// If the first attempt does not parse correctly, we try to parse using the format yyyyMMdd.
    /// Returns null if unable to parse.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="DateTimeOffset"/></returns>
    public static DateTimeOffset? ParseDateTimeMdyThenYmd(this string? s) =>
        DateTimeOffset.TryParseExact(
            s,
            new []
            {
                "MMddyyyy",
                "MM-dd-yyyy",
                "yyyyMMdd"
            },
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal,
            out var mdyResult)
            ? mdyResult
            : null;

    /// <summary>
    /// Tries to parse the issuing country.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="IssuingCountry"/></returns>
    public static IssuingCountry ParseIssuingCountry(this string? s) =>
        s switch
        {
            "USA" => IssuingCountry.UnitedStates,
            "CAN" => IssuingCountry.Canada,
            _ => IssuingCountry.Unknown
        };

    /// <summary>
    /// Tries to parse the truncation.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="Truncation"/></returns>
    public static Truncation ParseTruncation(this string? s) =>
        s switch
        {
            "T" => Truncation.Truncated,
            "N" => Truncation.None,
            _ => Truncation.Unknown
        };

    /// <summary>
    /// Tries to parse the gender.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="Gender"/></returns>
    public static Gender ParseGender(this string? s) =>
        s switch
        {
            "1" => Gender.Male,
            "2" => Gender.Female,
            _ => Gender.Unknown
        };

    /// <summary>
    /// Tries to parse the eye color.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="EyeColor"/></returns>
    public static EyeColor ParseEyeColor(this string? s) =>
        s switch
        {
            "BLK" => EyeColor.Black,
            "BLU" => EyeColor.Blue,
            "BRO" => EyeColor.Brown,
            "GRY" => EyeColor.Gray,
            "GRN" => EyeColor.Green,
            "HAZ" => EyeColor.Hazel,
            "MAR" => EyeColor.Maroon,
            "PNK" => EyeColor.Pink,
            "DIC" => EyeColor.Dichromatic,
            _ => EyeColor.Unknown
        };

    /// <summary>
    /// Tries to parse the name suffix.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="NameSuffix"/></returns>
    public static NameSuffix ParseNameSuffix(this string? s) =>
        s switch
        {
            "JR" => NameSuffix.Junior,
            "SR" => NameSuffix.Senior,
            "1ST" => NameSuffix.First,
            "I" => NameSuffix.First,
            "2ND" => NameSuffix.Second,
            "II" => NameSuffix.Second,
            "3RD" => NameSuffix.Third,
            "III" => NameSuffix.Third,
            "4TH" => NameSuffix.Fourth,
            "IV" => NameSuffix.Fourth,
            "5TH" => NameSuffix.Fifth,
            "V" => NameSuffix.Fifth,
            "6TH" => NameSuffix.Sixth,
            "VI" => NameSuffix.Sixth,
            "7TH" => NameSuffix.Seventh,
            "VII" => NameSuffix.Seventh,
            "8TH" => NameSuffix.Eighth,
            "VIII" => NameSuffix.Eighth,
            "9TH" => NameSuffix.Ninth,
            "iX" => NameSuffix.Ninth,
            _ => NameSuffix.Unknown
        };

    /// <summary>
    /// Tries to parse the hair color.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="HairColor"/></returns>
    public static HairColor ParseHairColor(this string? s) =>
        s switch
        {
            "BAL" => HairColor.Bald,
            "BLK" => HairColor.Black,
            "BLN" => HairColor.Blond,
            "BRO" => HairColor.Brown,
            "GRY" => HairColor.Grey,
            "RED" => HairColor.Red,
            "SDY" => HairColor.Sandy,
            "WHI" => HairColor.White,
            _ => HairColor.Unknown
        };

    /// <summary>
    /// Tries to parse the height in inches.
    /// Returns 0 if unable.
    /// </summary>
    /// <param name="s">The text to attempt to parse.</param>
    /// <returns><see cref="decimal"/></returns>
    public static decimal? ParseHeightInInches(this string? s)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            s = s.ToUpperInvariant().Trim();
            if (s.Contains("CM")
                && decimal.TryParse(s.RemoveFirstOccurrence("CM")?.Trim(), out var parsedCm))
            {
                return parsedCm * Constants.InchesPerCentimeter;
            }

            if (s.Contains("IN")
                && decimal.TryParse(s.RemoveFirstOccurrence("IN")?.Trim(), out var parsedId))
            {
                return parsedId;
            }

            var matches = Regex.Match(s, "^([1-9]{1})-?((?:0[0-9])|(?:1[012]))$");
            if (!matches.Success && matches.Groups.Count != 3)
            {
                return Regex.IsMatch(s, "^\\d{1,3}$")
                    ? decimal.Parse(s)
                    : null;
            }

            var inchesFromFeet = decimal.Parse(matches.Groups[1].Value) * 12;
            var inches = decimal.Parse(matches.Groups[2].Value);
            return inchesFromFeet + inches;
        }
        catch (Exception e)
            when (e is NullReferenceException
                      or ArgumentException
                      or ArgumentNullException
                      or FormatException
                      or RegexMatchTimeoutException)
        {
            return null;
        }
    }

    /// <summary>
    /// Parses the string into a <see cref="DriversLicenseData"/>.
    /// </summary>
    /// <param name="data">The license data.</param>
    /// <param name="defaultIssuingCountry">The default country to populate.</param>
    /// <param name="splitUpData">The raw data split per this versions rules.</param>
    /// <returns><see cref="DriversLicenseData"/></returns>
    public static DriversLicenseData BasicDriversLicenseParser(
        string? data,
        IssuingCountry defaultIssuingCountry,
        out IReadOnlyDictionary<string, string?> splitUpData)
    {
        var driversLicenseData = GetLicenseVersion(data) switch
        {
            LicenseVersion.Version1 => Version1StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version2 => Version2StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version3 => Version3StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version4 => Version4StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version5 => Version5StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version6 => Version6StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version7 => Version7StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version8 => Version8StandardParser.ParseDriversLicenseData(data, out splitUpData),
            LicenseVersion.Version9 => Version9StandardParser.ParseDriversLicenseData(data, out splitUpData),
            _ => UnknownVersionStandardParser.ParseDriversLicenseData(data, out splitUpData)
        };
        driversLicenseData.IssuingCountry = driversLicenseData.IssuingCountry == IssuingCountry.Unknown
            ? defaultIssuingCountry
            : driversLicenseData.IssuingCountry;
        return driversLicenseData;
    }

    /// <summary>
    /// Splits the license data string into the different parts.
    /// </summary>
    /// <param name="s">The string pulled from the barcode.</param>
    /// <returns><see cref="IReadOnlyDictionary{TKey,TValue}"/></returns>
    public static IReadOnlyDictionary<string, string?> SplitLicenseString(string? s)
    {
        var data = new Dictionary<string, string?>();
        if (string.IsNullOrWhiteSpace(s))
        {
            return data;
        }

        var dl = Regex.Match(s, "DL([a-zA-Z0-9]+)(DL[a-zA-Z0-9]+(?:\r|\n)?|D\\w{2}[a-zA-Z0-9]+)");
        if (dl.Success)
        {
            var ending = dl.Groups[2].Value.Trim() == "DL"
                ? "DL"
                : null;
            var dlValue = dl.Groups[1].Value.EndsWith("DL")
                ? dl.Groups[1].Value[..^2]
                : dl.Groups[1].Value;
            s = s.Replace(
                "DL" + dl.Groups[1].Value + ending,
                Environment.NewLine + "DL_" + dlValue + Environment.NewLine);
        }

        return s
            .Split('\r', '\n')
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x =>
                new
                {
                    Key = x.StartsWith("ANSI")
                    ? "ANSI"
                    : x.StartsWith("AAMVA")
                        ? "AAMVA"
                        : x.SubstringSafe(0, 3),
                    Value = x
                })
            .ToDictionary(x => x.Key, x => x.Value.RemoveFirstOccurrence(x.Key)?.Trim());
    }
}