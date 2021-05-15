using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace DLP.Core
{
	public static class DriverLicenseParser
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

		private static readonly IReadOnlyList<DLIIN> IINs =
			new ReadOnlyCollection<DLIIN>(
				new List<DLIIN>
				{
					new DLIIN
					{
						StateName = "Indiana",
						IIN = 636037,
						ParseMethod = ParseLicenseBasic,
						StateTest = x => x.StartsWith("ANSI 636037")
					},
					new DLIIN
					{
						StateName = "Illinois",
						IIN = 636035,
						ParseMethod = ParseLicenseFullNameFix,
						StateTest = x => x.Contains("ANSI 636035")
					},
					new DLIIN
					{
						StateName = "Ohio",
						IIN = 636023,
						ParseMethod = ParseOhioLicense,
						StateTest = x => x.Contains("^") && x.StartsWith("OH") // OH is a little different.
					},
					new DLIIN
					{
						StateName = "Washington",
						IIN = 636045,
						ParseMethod = ParseWashingtonLicense,
						StateTest = x => x.Contains("ANSI 636045")
					},
					new DLIIN
					{
						StateName = "Mississippi",
						IIN = 636051,
						ParseMethod = ParseLicenseBasic,
						StateTest = x => x.Contains("ANSI63605")
					},
					new DLIIN
					{
						StateName = "Utah",
						IIN = 636040,
						ParseMethod = ParseUtahLicense,
						StateTest = x => x.StartsWith("\u001e\rANSI 636040")
					},
					new DLIIN
					{
						StateName = "Pennsylvania",
						IIN = 636025,
						ParseMethod = ParsePennsylvaniaLicense,
						StateTest = x => x.Contains("AAMVA636025") || x.Contains("ANSI 636025")
					},
					new DLIIN
					{
						StateName = "New York",
						IIN = 636001,
						ParseMethod = ParseLicenseBasic,
						StateTest = x => x.StartsWith("\u001e\rANSI 636001")
					},
					new DLIIN
					{
						StateName = "Kentucky",
						IIN = 636046,
						ParseMethod = ParseLicenseBasic,
						StateTest = x => x.StartsWith("\u001c\rANSI 636046")
					},
					new DLIIN
					{
						StateName = "North Carolina",
						IIN = 636004,
						ParseMethod = ParseNorthCarolinaLicense,
						StateTest = x => x.ContainsCaseInvariant("AAMVA36004") // NC is just a special one.
					},
					new DLIIN
					{
						StateName = "Minnesota",
						IIN = 636038,
						ParseMethod = ParseMinnesotaLicense,
						StateTest = x => x.ContainsCaseInvariant("ANSI 636038")
					},
					new DLIIN
					{
						StateName = "Florida",
						IIN = 636010,
						ParseMethod = ParseLicenseFullNameFix,
						StateTest = x => x.ContainsCaseInvariant("ANSI 636010")
					},
					new DLIIN
					{
						StateName = "Wyoming",
						IIN = 636060,
						ParseMethod = ParseWyomingLicense,
						StateTest = x => x.StartsWith("\u001e\rANSI 636060") || x.StartsWith("ANSI 636060")
					},
					new DLIIN
					{
						StateName = "Connecticut",
						IIN = 636006,
						ParseMethod = ParseLicenseFullNameFix,
						StateTest = x => x.ContainsCaseInvariant("AAMVA636006")
					},
					new DLIIN
					{
						StateName = "Michigan",
						IIN = 636032,
						ParseMethod = ParseMichiganLicense,
						StateTest = x => x.ContainsCaseInvariant("ANSI 636032")
					},
					new DLIIN
					{
						StateName = "Oregon",
						IIN = 636029,
						ParseMethod = ParseOregonLicense,
						StateTest = x => x.ContainsCaseInvariant("ANSI 636029")
					},
					new DLIIN
					{
						StateName = "Texas",
						IIN = 636015
					},
					new DLIIN
					{
						StateName = "Wisconsin",
						IIN = 636031
					},
					new DLIIN
					{
						StateName = "Alabama",
						IIN = 636033
					},
					new DLIIN
					{
						StateName = "Louisiana",
						IIN = 636007
					},
					new DLIIN
					{
						StateName = "Oklahoma",
						IIN = 636058
					},
					new DLIIN
					{
						StateName = "Alaska",
						IIN = 636059
					},
					new DLIIN
					{
						StateName = "Maine",
						IIN = 636041
					},
					new DLIIN
					{
						StateName = "Ontario",
						IIN = 636012
					},
					new DLIIN
					{
						StateName = "Arizona",
						IIN = 636026
					},
					new DLIIN
					{
						StateName = "Manitoba",
						IIN = 636048
					},
					new DLIIN
					{
						StateName = "Arkansas",
						IIN = 636021
					},
					new DLIIN
					{
						StateName = "Maryland",
						IIN = 636003
					},
					new DLIIN
					{
						StateName = "British Columbia",
						IIN = 636028
					},
					new DLIIN
					{
						StateName = "Massachusetts",
						IIN = 636002
					},
					new DLIIN
					{
						StateName = "Prince Edward Island",
						IIN = 604425
					},
					new DLIIN
					{
						StateName = "California",
						IIN = 636014
					},
					new DLIIN
					{
						StateName = "Rhode Island",
						IIN = 636052
					},
					new DLIIN
					{
						StateName = "Coahuila",
						IIN = 636056
					},
					new DLIIN
					{
						StateName = "Saskatchewan",
						IIN = 636044
					},
					new DLIIN
					{
						StateName = "Colorado",
						IIN = 636020
					},
					new DLIIN
					{
						StateName = "South Carolina",
						IIN = 636005
					},
					new DLIIN
					{
						StateName = "Missouri",
						IIN = 636030
					},
					new DLIIN
					{
						StateName = "South Dakota",
						IIN = 636042
					},
					new DLIIN
					{
						StateName = "District of Columbia",
						IIN = 636043
					},
					new DLIIN
					{
						StateName = "Montana",
						IIN = 636008
					},
					new DLIIN
					{
						StateName = "Tennessee",
						IIN = 636053
					},
					new DLIIN
					{
						StateName = "Delaware",
						IIN = 636011
					},
					new DLIIN
					{
						StateName = "Nebraska",
						IIN = 636054
					},
					new DLIIN
					{
						StateName = "State Dept (USA)",
						IIN = 636027
					},
					new DLIIN
					{
						StateName = "Nevada",
						IIN = 636049
					},
					new DLIIN
					{
						StateName = "Georgia",
						IIN = 636055
					},
					new DLIIN
					{
						StateName = "New Brunswick",
						IIN = 636017
					},
					new DLIIN
					{
						StateName = "US Virgin Islands",
						IIN = 636062
					},
					new DLIIN
					{
						StateName = "Guam",
						IIN = 636019
					},
					new DLIIN
					{
						StateName = "New Hampshire",
						IIN = 636039
					},
					new DLIIN
					{
						StateName = "Hawaii",
						IIN = 636047
					},
					new DLIIN
					{
						StateName = "New Jersey",
						IIN = 636036
					},
					new DLIIN
					{
						StateName = "Vermont",
						IIN = 636024
					},
					new DLIIN
					{
						StateName = "Hidalgo",
						IIN = 636057
					},
					new DLIIN
					{
						StateName = "New Mexico",
						IIN = 636009
					},
					new DLIIN
					{
						StateName = "Virginia",
						IIN = 636000
					},
					new DLIIN
					{
						StateName = "Idaho",
						IIN = 636050
					},
					new DLIIN
					{
						StateName = "Newfoundland",
						IIN = 636016
					},
					new DLIIN
					{
						StateName = "West Virginia",
						IIN = 636061
					},
					new DLIIN
					{
						StateName = "Iowa",
						IIN = 636018
					},
					new DLIIN
					{
						StateName = "North Dakota",
						IIN = 636034
					},
					new DLIIN
					{
						StateName = "Kansas",
						IIN = 636022
					},
					new DLIIN
					{
						StateName = "Nova Scotia",
						IIN = 636013
					}
				});

		static DriverLicenseParser()
		{
			var orMap = BaseCodeToParseMap.ToDictionary(x => x.Key, x => x.Value);
			orMap[FullNameCode] = (license, rest) => license.HandleOregonFullName(rest);
			orMap.Add(
				AddressLine1Code2,
				(license, rest) => license.AddressLine1 = rest);
			OregonCodeToParseMap = new ReadOnlyDictionary<string, Action<DriversLicenseData, string>>(orMap);
		}

		#endregion

		public static CustomerShell ParseData(string licenseInformation) =>
			ParseDataInternal(licenseInformation, true);

		public static CustomerShell TestParseData(string licenseInformation) =>
			ParseDataInternal(licenseInformation, false);

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

		private static CustomerShell ParseMichiganLicense(IEnumerable<string> licenseData)
		{
			var license = new DriversLicenseData();
			foreach (var item in licenseData)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;

				if (code == FullName2Code)
				{
					code = FirstNameCode;
				}
				license = LicenseNumberTest(license, item);
				InvokeIfCan(BaseCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static CustomerShell ParseUtahLicense(IEnumerable<string> licenseData)
		{
			var license = new DriversLicenseData();
			foreach (var item in licenseData)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				license = LicenseNumberTest(license, item);
				if (code == FullName2Code)
				{
					code = nameof(FullName2Code);
				}
				InvokeIfCan(UtahCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static CustomerShell ParseOhioLicense(IEnumerable<string> licenseData)
		{
			var licenseString = string.Join("\n", licenseData);
			var license = new DriversLicenseData();
			if (!licenseString.Contains("^") || !licenseString.StartsWith("OH"))
			{
				return new CustomerShell();
			}
			license.State = "OH";
			licenseString = licenseString.ReplaceFirst(license.State, string.Empty);
			license.City = licenseString.Substring(0, licenseString.IndexOf("^", StringComparison.Ordinal)).Trim();
			licenseString = licenseString.ReplaceFirst(license.City + "^", string.Empty);
			license.LastName = licenseString.Substring(0, licenseString.IndexOf("$", StringComparison.Ordinal)).Trim();
			licenseString = licenseString.ReplaceFirst(license.LastName + "$", string.Empty);
			license.FirstName = licenseString.Substring(0, licenseString.IndexOf("$", StringComparison.Ordinal)).Trim();
			licenseString = licenseString.ReplaceFirst(license.FirstName + "$", string.Empty);
			if (licenseString[0] == '$')
			{
				license.MiddleName = licenseString.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseString.Substring(0, licenseString.IndexOf("^", StringComparison.Ordinal)).Trim('$').Trim()
					: string.Empty;
				licenseString = licenseString.Substring(licenseString.IndexOf("^", StringComparison.Ordinal));
			}
			else
			{
				license.MiddleName = licenseString.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseString.Substring(0, licenseString.IndexOf("$", StringComparison.Ordinal)).Trim()
					: string.Empty;
				licenseString = licenseString.IndexOf("$", StringComparison.Ordinal) > -1
					? licenseString.ReplaceFirst(license.MiddleName + "$", string.Empty)
					: licenseString.Substring(1);
			}
			if (licenseString[0] == '^')
			{
				licenseString = licenseString.Substring(1);
			}
			var addressMarker = licenseString.IndexOf("^", StringComparison.Ordinal);
			if (addressMarker > -1 && addressMarker < 30)
			{
				license.AddressLine1 = licenseString.Substring(0, addressMarker).Trim();
				licenseString = licenseString.ReplaceFirst(license.AddressLine1 + "^", string.Empty);
			}
			else
			{
				license.AddressLine1 = licenseString.Substring(0, 30).Trim();
				licenseString = licenseString.ReplaceFirst(license.AddressLine1, string.Empty);
			}
			licenseString = licenseString.Substring(licenseString.IndexOf("=", StringComparison.Ordinal) - 9);
			license.Number = licenseString.Substring(0, licenseString.IndexOf("=", StringComparison.Ordinal));
			licenseString = licenseString.ReplaceFirst(license.Number + "=", string.Empty);
			license.Expires = licenseString.Substring(0, 4)
				.ParseDateTimeExact("yyMM", CultureInfo.InvariantCulture, DateTimeStyles.None);
			licenseString = licenseString.Substring(4).Trim();
			license.BirthDate = licenseString.Substring(0, 8)
				.ParseDateTimeExact("yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
			licenseString = licenseString.Substring(10).Trim();
			license.Zip = StringExtensions.Split(licenseString, " ", StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()?.Trim() ?? string.Empty;
			licenseString = licenseString.ReplaceFirst(license.Zip, string.Empty).Trim();
			if (license.Zip.Length > 5)
			{
				license.Zip = license.Zip.Substring(0, 5) + "-" + license.Zip.Substring(5);
			}
			license.Class = licenseString.Substring(0, 1).Trim();
			licenseString = licenseString.Substring(3).Trim();
			if (string.IsNullOrWhiteSpace(licenseString))
			{
				return license.ToCustomerShell();
			}
			license.Gender = licenseString.Substring(0, 1) == "1" ? "Male" : "Female";
			if (string.IsNullOrWhiteSpace(licenseString))
			{
				return license.ToCustomerShell();
			}
			license.Height = licenseString.Substring(1, 1) + "' " + licenseString.Substring(2, 2) + "\"";
			if (string.IsNullOrWhiteSpace(licenseString))
			{
				return license.ToCustomerShell();
			}
			license.Weight = licenseString.Substring(4, 3).Trim();
			if (string.IsNullOrWhiteSpace(licenseString))
			{
				return license.ToCustomerShell();
			}
			license.Hair = licenseString.Substring(7, 3).Trim();
			if (string.IsNullOrWhiteSpace(licenseString))
			{
				return license.ToCustomerShell();
			}
			license.Eyes = licenseString.Substring(10, 3).Trim();
			return license.ToCustomerShell();
		}

		private static CustomerShell ParseNorthCarolinaLicense(IEnumerable<string> licenseData)
		{
			var data = licenseData.ToList();
			var index = data[0].IndexOf("DAB", StringComparison.Ordinal);
			if (index > -1)
			{
				data[0] = data[0].Substring(index);
			}
			var license = new DriversLicenseData();
			foreach (var item in data)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				license = LicenseNumberTest(license, item);
				// In the event that you needed another reason to not like NC (i.e. Duke) check this out.
				// SOME CODES ARE DIFFERENT!
				// Good job NC
				if (code == DateOfBirthCode)
				{
					code = nameof(DateOfBirthCode);
				}
				InvokeIfCan(NCCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
		}

		private static CustomerShell ParsePennsylvaniaLicense(IEnumerable<string> licenseData)
		{
			var licenseDataList = licenseData.ToList();
			var license = ParseLicenseBasic(licenseDataList);
			if (licenseDataList.Any(x => x.StartsWith(FullNameCode)))
			{
				if (license.PrimaryLastName.Contains(" ") || (license.PrimaryMiddleName?.Contains(" ") ?? false))
				{
					// This happens when a suffix is added, the name parts should be in the right order.
					return license;
				}

				var originalFirstName = license.PrimaryFirstName;
				var originalMiddleName = license.PrimaryMiddleName;
				var originalLastName = license.PrimaryLastName;
				if (originalMiddleName != null)
				{
					license.PrimaryLastName = originalMiddleName;
					license.PrimaryMiddleName = originalFirstName;
				}
				else
				{
					license.PrimaryLastName = originalFirstName;
				}

				license.PrimaryFirstName = originalLastName;
			}
			return license;
		}

		private static CustomerShell ParseWyomingLicense(IEnumerable<string> licenseData)
		{
			var license = ParseLicenseBasic(licenseData);
			var nameSections = StringExtensions.Split(license.PrimaryFirstName, " ", StringSplitOptions.RemoveEmptyEntries);
			if (nameSections.Length != 2 || !string.IsNullOrWhiteSpace(license.PrimaryMiddleName)) return license;
			license.PrimaryFirstName = nameSections[0];
			license.PrimaryMiddleName = nameSections[1];
			return license;
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

		private static CustomerShell ParseWashingtonLicense(IEnumerable<string> licenseData)
		{
			var data = licenseData.ToList();
			EncryptionTest(data);
			var sectionWithLastName = data.FirstOrDefault(x => x.Contains(LastNameCode));
			if (sectionWithLastName != null)
			{
				data.Add(LastNameCode + sectionWithLastName.Split(new[] { LastNameCode }, StringSplitOptions.None)[1]);
			}
			var license = new DriversLicenseData();
			foreach (var item in data)
			{
				var lengthOverThree = item.Length > 3;
				var code = lengthOverThree ? item.Substring(0, 3) : item;
				var rest = lengthOverThree ? item.Substring(3).Trim() : string.Empty;
				license = LicenseNumberTest(license, item);
				if (code == FullName2Code)
				{
					var nameSections = rest.Split(' ');
					if (nameSections.Length == 1)
					{
						license.FirstName = rest;
						continue;
					}
				}
				InvokeIfCan(BaseCodeToParseMap, code, license, rest);
			}
			return license.ToCustomerShell();
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

		private static void InvokeIfCan(
			IReadOnlyDictionary<string, Action<DriversLicenseData, string>> dict,
			string code,
			DriversLicenseData license,
			string rest)
		{
			if (dict.ContainsKey(code))
			{
				dict[code](license, rest);
			}
		}

	}
}