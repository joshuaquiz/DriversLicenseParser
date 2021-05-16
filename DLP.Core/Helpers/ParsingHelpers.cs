using System;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using DLP.Core.Models.Enums;

namespace DLP.Core.Helpers
{
    public static class ParsingHelpers
    {
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

        public static string TrimToLength(this string s, int length) =>
            s.Length <= length
                ? s
                : s.Substring(0, length);

        public static string RemoveFirstOccurrence(this string haystack, string needle)
        {
            var index = haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase);
            return index > -1
                ? haystack.Remove(index, needle.Length)
                : haystack;
        }

        public static DateTimeOffset ParseDateTimeMonthDayYear(this string s) =>
            DateTimeOffset.ParseExact(
                s,
                "MMddyyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.AdjustToUniversal);

        public static IssuingCountry ParseIssuingCountry(this string s) =>
            s switch
            {
                "USA" => IssuingCountry.UnitedStates,
                "CAN" => IssuingCountry.Canada,
                _ => IssuingCountry.Unknown
            };

        public static Truncation ParseTruncation(this string s) =>
            s switch
            {
                "T" => Truncation.Truncated,
                "N" => Truncation.None,
                _ => Truncation.Unknown
            };

        public static Gender ParseGender(this string s) =>
            s switch
            {
                "1" => Gender.Male,
                "2" => Gender.Female,
                _ => Gender.Unknown
            };

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
    }
}