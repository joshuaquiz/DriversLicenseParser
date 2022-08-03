﻿/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace DLP.Core
{
	public static class DriverLicenseParserOld
	{

		#region Constants

		private const string FullNameCode = "DAA";
		private const string FullName2Code = "DCT";
		private const string FirstNameCode = "DAC";
		private const string MiddleNameCode = "DAD";
		private const string LastNameCode = "DCS";
		private const string DateOfBirthCode = "DBB";
		private const string LicenseNumberCode = "DAQ";
		private const string AddressLine1Code = "DAG";
		private const string AddressLine1Code2 = "DAL";
		private const string CityCode = "DAI";
		private const string StateCode = "DAJ";
		private const string ZipCode = "DAK";

		#endregion

		#region Function Dictionaries

		private static readonly ReadOnlyDictionary<string, Action<DriversLicenseData, string>> BaseCodeToParseMap =
			new ReadOnlyDictionary<string, Action<DriversLicenseData, string>>(
				new Dictionary<string, Action<DriversLicenseData, string>>
				{
					{
						FullNameCode,
						(license, rest) => license.HandleStandardFullName(rest, rest.Contains(",") ? "," : " ")
					},
					{
						FullName2Code,
						(license, rest) => license.HandleStandardFullName2(rest, rest.Contains(",") ? "," : " ")
					},
					{
						FirstNameCode,
						(license, rest) => license.FirstName = rest
					},
					{
						MiddleNameCode,
						(license, rest) => license.MiddleName = rest
					},
					{
						LastNameCode,
						(license, rest) => license.LastName = rest
					},
					{
						DateOfBirthCode,
						(license, rest) => license.HandleStandardBirthDate(rest)
					},
					{
						AddressLine1Code,
						(license, rest) => license.AddressLine1 = rest
					},
					{
						CityCode,
						(license, rest) => license.City = rest
					},
					{
						StateCode,
						(license, rest) => license.State = rest
					},
					{
						ZipCode,
						(license, rest) => license.Zip = rest.ParseNumbersOnly().Length >= 9 ? rest.Substring(0, 5).Trim() : rest
					}
				});

		private static readonly IReadOnlyDictionary<string, Action<DriversLicenseData, string>> NCCodeToParseMap =
			new ReadOnlyDictionary<string, Action<DriversLicenseData, string>>(
				BaseCodeToParseMap.Concat(
					new Dictionary<string, Action<DriversLicenseData, string>>
					{
						{
							"DAB",
							(license, rest) => license.LastName = rest
						},
						{
							nameof(DateOfBirthCode),
							(license, rest) =>
							{
								license.BirthDate = rest
									.Trim()
									.ParseDateTimeExact("MM-dd-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
								if (!license.BirthDate.IsRealDate())
								{
									license.BirthDate = null;
								}
							}
						},
						{
							AddressLine1Code2,
							(license, rest) => license.AddressLine1 = rest
						},
						{
							"DAN",
							(license, rest) => license.City = rest
						},
						{
							"DAO",
							(license, rest) => license.State = rest
						},
						{
							"DAP",
							(license, rest) => license.Zip = rest.ParseNumbersOnly().Length >= 9 ? rest.Substring(0, 5).Trim() : rest
						}
					}
				).ToDictionary(x => x.Key, x => x.Value));

		private static readonly IReadOnlyDictionary<string, Action<DriversLicenseData, string>> UtahCodeToParseMap =
			new ReadOnlyDictionary<string, Action<DriversLicenseData, string>>(
				BaseCodeToParseMap.Concat(
					new Dictionary<string, Action<DriversLicenseData, string>>
					{
						{
							nameof(FullName2Code),
							(license, rest) => license.HandleStandardFullName2(rest, rest.Contains(",") ? "," : " ")
						}
					}
				).ToDictionary(x => x.Key, x => x.Value));

		private static readonly IReadOnlyDictionary<string, Action<DriversLicenseData, string>> OregonCodeToParseMap;

		#endregion

		#region IINs

		static DriverLicenseParserOld()
		{
			var orMap = BaseCodeToParseMap.ToDictionary(x => x.Key, x => x.Value);
			orMap[FullNameCode] = (license, rest) => license.HandleOregonFullName(rest);
			orMap.Add(
				AddressLine1Code2,
				(license, rest) => license.AddressLine1 = rest);
			OregonCodeToParseMap = new ReadOnlyDictionary<string, Action<DriversLicenseData, string>>(orMap);
		}

		#endregion

		public static CustomerShell ParseDataInternal(string licenseInformation, bool runZipLookup)
		{
			var lines = StringExtensions.Split(
					licenseInformation,
					licenseInformation.Contains("\n") ? "\n" : "\\n",
					StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.Where(x => x.Length > 2)
				.ToList();
			var firstLine = lines.First();
			var stateParser = IINs.FirstOrDefault(x => x.StateTest(firstLine))?.ParseMethod
							?? ParseLicenseBasic;
			var result = stateParser(lines);
			// If no county try to look it up.
			// If no zip, then nothing to look the county up by so we are done.
			if (!string.IsNullOrWhiteSpace(result.County)
				|| string.IsNullOrWhiteSpace(result.Zip)
				|| !runZipLookup)
			{
				return result;
			}
			var countyLookup = ZipTastic.GetZipCodeInformation(result.Zip);
			result.County = countyLookup.County;
			return result;
		}

		private static CustomerShell ParseLicenseBasic(IEnumerable<string> licenseData)
		{
			var license = new DriversLicenseData();
			foreach (var item in licenseData)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				license = LicenseNumberTest(license, item);
				InvokeIfCan(BaseCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static CustomerShell ParseLicenseFullNameFix(IEnumerable<string> licenseData)
		{
			var license = new DriversLicenseData();
			foreach (var item in licenseData)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				// Illinois License doesn't have a new line break and the FirstName is in the first line but doesn't start w/ DAA
				if (item.Contains(FullNameCode) && code != FullNameCode)
				{
					var fullNameCodeIndex = item.IndexOf(FullNameCode, StringComparison.Ordinal);
					var firstMiddleLast =
						item.Substring(
								fullNameCodeIndex,
								item.Length - fullNameCodeIndex)
							.Replace(FullNameCode, string.Empty);
					// Should be LastName, First,Luz
					license.HandleStandardFullName(firstMiddleLast, ",");
					continue;
				}
				license = LicenseNumberTest(license, item);
				InvokeIfCan(BaseCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static CustomerShell ParseMinnesotaLicense(IEnumerable<string> licenseData)
		{
			var data = licenseData.ToList();
			var fullNameData = data.FirstOrDefault(x => x.Contains(FullNameCode));
			if (fullNameData != null)
			{
				var parts = fullNameData.Replace(FullNameCode, string.Empty).Split(' ');
				switch (parts.Length)
				{
					case 2:
						data.Add(LastNameCode + parts[0]);
						data.Add(FirstNameCode + parts[1]);
						break;
					case 3:
						data.Add(LastNameCode + parts[0]);
						data.Add(MiddleNameCode + parts[1]);
						data.Add(FirstNameCode + parts[2]);
						break;
					default:
						data.Add(LastNameCode + fullNameData);
						break;
				}
				data.Remove(fullNameData);
			}
			return ParseLicenseBasic(data);
		}

		private static CustomerShell ParseOregonLicense(IEnumerable<string> licenseData)
		{
			var license = new DriversLicenseData();
			foreach (var item in licenseData)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				license = LicenseNumberTest(license, item);
				InvokeIfCan(OregonCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static void EncryptionTest(IEnumerable<string> data)
		{
			if (string.Join("\n", data).IndexOfAny(new[] { '«', '¼', '¾', '¹', '²', '³', '£', '¢', 'º', '¨', '¯', '¦', 'ª', '¤', 'æ', '°' }) > -1)
			{
				throw new DriversLicenseException("The data in this license appears to be encrypted. It cannot be extracted.");
			}
		}

		private static DriversLicenseData LicenseNumberTest(DriversLicenseData license, string strItem)
		{
			var index = strItem.IndexOf(LicenseNumberCode, StringComparison.Ordinal);
			if (index > -1)
			{
				license.Number = strItem.Substring(index + LicenseNumberCode.Length);
			}
			return license;
		}
	}
}*/