using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using DLP.Core.Parsers;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Michigan : IParseableLicense
    {
        public string FullName => "Michigan";

        public string Abbreviation => "MI";

        public string Country => "USA";

        public int IssuerIdentificationNumber => 636032;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data) =>
            ParsingHelpers.GetLicenseVersion(data) switch
            {
                LicenseVersion.Version2 => Version2StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version3 => Version3StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version4 => Version4StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version5 => Version5StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version6 => Version6StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version7 => Version7StandardParser.ParseDriversLicenseData(data),
                LicenseVersion.Version8 => Version8StandardParser.ParseDriversLicenseData(data),
                _ => Version1StandardParser.ParseDriversLicenseData(data)
            };
    }
}