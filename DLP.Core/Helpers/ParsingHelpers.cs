using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using DLP.Core.Models.Enums;

namespace DLP.Core.Helpers
{
    public static class ParsingHelpers
    {
        /// <summary>
        /// Attempts to get the value of the record with the provided key
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string TryGetValue(this IReadOnlyDictionary<string, string> data, string key) =>
            data.TryGetValue(key, out var value)
                ? value
                : null;

        public static string ParseDriverLicenseName(this IReadOnlyDictionary<string, string> data, string dataKey, string namePart)
        {
            var driverLicenseName = data.TryGetValue(dataKey);
            var nameParts = driverLicenseName.Split(',');
            return namePart switch
            {
                "lastName" => nameParts.Length >= 1 ? nameParts[0] : null,
                "firstName" => nameParts.Length >= 2 ? nameParts[1] : null,
                "middleName" => nameParts.Length >= 3 ? nameParts[2] : null,
                "suffix" => nameParts.Length >= 4 ? nameParts[3] : null,
                _ => null
            };
        }

        /// <summary>
        /// Tries to parse the <see cref="LicenseVersion"/> from the license data provided.
        /// </summary>
        /// <param name="data">The license data.</param>
        /// <returns><see cref="LicenseVersion"/></returns>
        public static LicenseVersion GetLicenseVersion(string data)
        {
            try
            {
                var versionInt = int.Parse(Regex.Match(data, "\\d{6}(\\d{2})\\w+").Captures[0].Value);
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
                : s.Substring(0, length);

        /// <summary>
        /// Removes the first occurrence of the value.
        /// </summary>
        /// <param name="haystack">Data to search in.</param>
        /// <param name="needle">What to look for.</param>
        /// <returns><see cref="string"/></returns>
        public static string RemoveFirstOccurrence(this string haystack, string needle)
        {
            var index = haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase);
            return index > -1
                ? haystack.Remove(index, needle.Length)
                : haystack;
        }

        /// <summary>
        /// Tries to parse as a <see cref="DateTimeOffset"/> using the format MMddyyyy.
        /// </summary>
        /// <param name="s">The text to attempt to parse.</param>
        /// <returns><see cref="DateTimeOffset"/></returns>
        public static DateTimeOffset ParseDateTimeMonthDayYear(this string s) =>
            DateTimeOffset.ParseExact(
                s,
                "MMddyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal);

        /// <summary>
        /// Tries to parse the issuing country.
        /// </summary>
        /// <param name="s">The text to attempt to parse.</param>
        /// <returns><see cref="IssuingCountry"/></returns>
        public static IssuingCountry ParseIssuingCountry(this string s) =>
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
        public static Truncation ParseTruncation(this string s) =>
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
        public static Gender ParseGender(this string s) =>
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
        public static EyeColor ParseEyeColor(this string s) =>
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
        public static NameSuffix ParseNameSuffix(this string s) =>
            s switch
            {
                "JR" => NameSuffix.Junior,
                "SR" => NameSuffix.Senior,
                "1ST"=> NameSuffix.First,
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
        public static HairColor ParseHairColor(this string s) =>
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
        /// <returns><see cref="double"/></returns>
        public static double ParseHeightInInches(this string s)
        {
            try
            {
                if (!s.Contains("cm"))
                {
                    return int.Parse(s);
                }
                
                return int.Parse(s.RemoveFirstOccurrence("cm")) * Constants.InchesPerCentimeter;
            }
            catch (Exception e)
                when (e is ArgumentNullException or FormatException)
            {
                return 0;
            }
        }
    }
}