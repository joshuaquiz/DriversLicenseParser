using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System;
using System.Globalization;
using System.Linq;

namespace DLP.Core.ParseableLicenses
{
    /// <summary>
    /// Represents a license from the US state of Ohio.
    /// </summary>
    public sealed class Ohio : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Ohio";

        /// <inheritdoc />
        public string Abbreviation => "OH";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636023;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data) =>
            data.Contains("^")
                ? ParseFlatOhioLicense(data)
                : ParsingHelpers.BasicDriversLicenseParser(data, Country, out _);

        private DriversLicenseData ParseFlatOhioLicense(string data)
        {
            var license = new DriversLicenseData
            {
                State = Abbreviation,
                IssuingCountry = Country,
                LicenseVersion = LicenseVersion.UnknownVersion
            };
            data = data.RemoveFirstOccurrence(license.State);
            var dataParts = data.Split('^');
            license.City = dataParts.FirstOrDefault();
            var namePart = dataParts.ElementAtOrDefault(1) ?? string.Empty;
            var nameParts = namePart.Split('$', StringSplitOptions.RemoveEmptyEntries);
            switch (nameParts.Length)
            {
                case 1:
                    license.LastName = nameParts[0];
                    break;
                case 2:
                    license.LastName = nameParts[0];
                    license.FirstName = nameParts[1];
                    break;
                case 3:
                    license.LastName = nameParts[0];
                    license.FirstName = nameParts[1];
                    license.MiddleName = nameParts[2];
                    break;
                default:
                    license.LastName = namePart;
                    break;
            }

            string documentIdAndOtherData;
            if (dataParts.Length == 4)
            {
                license.StreetAddress = dataParts.ElementAtOrDefault(2);
                documentIdAndOtherData = dataParts.ElementAtOrDefault(3) ?? string.Empty;
            }
            else
            {
                var dataText = dataParts.ElementAtOrDefault(2);
                var rawStreetAddress = dataText?[
                    ..dataText.IndexOf(
                        IssuerIdentificationNumber.ToString(),
                        StringComparison.InvariantCultureIgnoreCase)];
                license.StreetAddress = rawStreetAddress?.Trim();
                documentIdAndOtherData = dataText.RemoveFirstOccurrence(rawStreetAddress);
            }

            var documentIdAndOtherDataParts = documentIdAndOtherData.Split('=');
            license.InventoryControl = documentIdAndOtherDataParts.FirstOrDefault();
            license.CustomerId = documentIdAndOtherDataParts
                .FirstOrDefault()
                ?.RemoveFirstOccurrence(IssuerIdentificationNumber.ToString());
            var remainingData = documentIdAndOtherDataParts.ElementAtOrDefault(1);
            var startIndex = 0;
            license.ExpirationDate = DateTimeOffset.ParseExact(remainingData?.SubstringSafe(startIndex, 4), "yyMM", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            startIndex += 4;
            license.DateOfBirth = DateTimeOffset.ParseExact(remainingData?.SubstringSafe(startIndex, 8), "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            startIndex += 8;
            var unknownFieldOne = remainingData?.SubstringSafe(startIndex, 2);
            startIndex += 2;
            var remainingDataParts = remainingData?[startIndex..].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            license.PostalCode = remainingDataParts?.FirstOrDefault();
            if (license.PostalCode is {Length: > 5})
            {
                license.PostalCode = $"{license.PostalCode[..5]}-{license.PostalCode[5..]}";
            }

            var vehicleClass = remainingDataParts?.ElementAtOrDefault(1);
            var unknownFieldTwo = remainingDataParts?.ElementAtOrDefault(2);
            var lastSectionStartIndex = 0;
            var lastSection = remainingDataParts?.ElementAtOrDefault(3);
            if (remainingDataParts is {Length: 5})
            {
                lastSection += remainingDataParts.ElementAtOrDefault(4);
            }

            if (lastSection == null)
            {
                return license;
            }

            license.Gender = lastSection.SubstringSafe(lastSectionStartIndex, 1) is "1" or "M"
                ? Gender.Male
                : Gender.Female;
            lastSectionStartIndex++;
            license.Height = lastSection.SubstringSafe(lastSectionStartIndex, 3).ParseHeightInInches();
            lastSectionStartIndex += 3;
            var weight = lastSection.SubstringSafe(lastSectionStartIndex, 3);
            lastSectionStartIndex += 3;
			license.HairColor = lastSection.SubstringSafe(lastSectionStartIndex, 3).ParseHairColor();
            lastSectionStartIndex += 3;
            license.EyeColor = lastSection.SubstringSafe(lastSectionStartIndex, 3).ParseEyeColor();
			return license;
		}
    }
}