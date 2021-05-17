using System;
using System.Globalization;
using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Ohio : IParseableLicense
    {
        public string FullName => "Ohio";

        public string Abbreviation => "OH";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636023;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }

		private static DriversLicenseData ParseOhioLicense(string licenseData)
		{
			var license = new DriversLicenseData();
			if (!licenseData.Contains("^") || !licenseData.StartsWith("OH"))
			{
				return new CustomerShell();
			}

			license.State = "OH";
			licenseData = licenseData.ReplaceFirst(license.State, string.Empty);
			license.City = licenseData.Substring(0, licenseData.IndexOf("^", StringComparison.Ordinal)).Trim();
			licenseData = licenseData.ReplaceFirst(license.City + "^", string.Empty);
			license.LastName = licenseData.Substring(0, licenseData.IndexOf("$", StringComparison.Ordinal)).Trim();
			licenseData = licenseData.ReplaceFirst(license.LastName + "$", string.Empty);
			license.FirstName = licenseData.Substring(0, licenseData.IndexOf("$", StringComparison.Ordinal)).Trim();
			licenseData = licenseData.ReplaceFirst(license.FirstName + "$", string.Empty);
			if (licenseData[0] == '$')
			{
				license.MiddleName = licenseData.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseData.Substring(0, licenseData.IndexOf("^", StringComparison.Ordinal)).Trim('$').Trim()
					: string.Empty;
				licenseData = licenseData.Substring(licenseData.IndexOf("^", StringComparison.Ordinal));
			}
			else
			{
				license.MiddleName = licenseData.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseData.Substring(0, licenseData.IndexOf("$", StringComparison.Ordinal)).Trim()
					: string.Empty;
				licenseData = licenseData.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseData.ReplaceFirst(license.MiddleName + "$", string.Empty)
					: licenseData.Substring(1);
			}
			if (licenseData[0] == '^')
			{
				licenseData = licenseData.Substring(1);
			}
			var addressMarker = licenseData.IndexOf("^", StringComparison.Ordinal);
			if (addressMarker > -1 && addressMarker < 30)
			{
				license.AddressLine1 = licenseData.Substring(0, addressMarker).Trim();
				licenseData = licenseData.ReplaceFirst(license.AddressLine1 + "^", string.Empty);
			}
			else
			{
				license.AddressLine1 = licenseData.Substring(0, 30).Trim();
				licenseData = licenseData.ReplaceFirst(license.AddressLine1, string.Empty);
			}
			licenseData = licenseData.Substring(licenseData.IndexOf("=", StringComparison.Ordinal) - 9);
			license.Number = licenseData.Substring(0, licenseData.IndexOf("=", StringComparison.Ordinal));
			licenseData = licenseData.ReplaceFirst(license.Number + "=", string.Empty);
			license.Expires = licenseData.Substring(0, 4)
				.ParseDateTimeExact("yyMM", CultureInfo.InvariantCulture, DateTimeStyles.None);
			licenseData = licenseData.Substring(4).Trim();
			license.BirthDate = licenseData.Substring(0, 8)
				.ParseDateTimeExact("yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
			licenseData = licenseData.Substring(10).Trim();
			license.Zip = StringExtensions.Split(licenseData, " ", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim() ?? string.Empty;
			licenseData = licenseData.ReplaceFirst(license.Zip, string.Empty).Trim();
			if (license.Zip.Length > 5)
			{
				license.Zip = license.Zip.Substring(0, 5) + "-" + license.Zip.Substring(5);
			}
			license.Class = licenseData.Substring(0, 1).Trim();
			licenseData = licenseData.Substring(3).Trim();
			if (string.IsNullOrWhiteSpace(licenseData))
			{
				return license;
			}
			license.Gender = licenseData.Substring(0, 1) == "1" ? "Male" : "Female";
			if (string.IsNullOrWhiteSpace(licenseData))
			{
				return license;
			}
			license.Height = licenseData.Substring(1, 1) + "' " + licenseData.Substring(2, 2) + "\"";
			if (string.IsNullOrWhiteSpace(licenseData))
			{
				return license;
			}
			license.Weight = licenseData.Substring(4, 3).Trim();
			if (string.IsNullOrWhiteSpace(licenseData))
			{
				return license;
			}
			license.Hair = licenseData.Substring(7, 3).Trim();
			if (string.IsNullOrWhiteSpace(licenseData))
			{
				return license;
			}
			license.Eyes = licenseData.Substring(10, 3).Trim();
			return license;
		}
	}
}