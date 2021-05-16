using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

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
                LicenseVersion.Version2 => ParsingHelpers.BasicVersion2Parser(data),
                LicenseVersion.Version3 => ParsingHelpers.BasicVersion3Parser(data),
                LicenseVersion.Version4 => ParsingHelpers.BasicVersion4Parser(data),
                LicenseVersion.Version5 => ParsingHelpers.BasicVersion5Parser(data),
                LicenseVersion.Version6 => ParsingHelpers.BasicVersion6Parser(data),
                LicenseVersion.Version7 => ParsingHelpers.BasicVersion7Parser(data),
                LicenseVersion.Version8 => ParsingHelpers.BasicVersion8Parser(data),
                _ => ParsingHelpers.BasicVersion1Parser(data)
            };
    }
}