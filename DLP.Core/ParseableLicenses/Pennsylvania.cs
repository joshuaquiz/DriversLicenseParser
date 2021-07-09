using DLP.Core.Helpers;
using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;
using System;

namespace DLP.Core.ParseableLicenses
{
    /// <summary>
    /// Represents a license from the US state of Pennsylvania.
    /// </summary>
    public sealed class Pennsylvania : IParseableLicense
    {
        /// <inheritdoc />
        public string FullName => "Pennsylvania";

        /// <inheritdoc />
        public string Abbreviation => "PA";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636025;

        /// <inheritdoc />
        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        /// <inheritdoc />
        public DriversLicenseData ParseData(string data)
        {
            var licenseData = ParsingHelpers.BasicDriversLicenseParser(
                data,
                Country,
                out var splitUpData);
            if (splitUpData.TryGetValue("ANS", out var ansiData))
            {
                var indexOfDl = ansiData.IndexOf("DL", StringComparison.InvariantCultureIgnoreCase);
                licenseData.InventoryControl = ansiData[2..indexOfDl];
                var indexOfD = ansiData.IndexOf("D", indexOfDl + 1, StringComparison.InvariantCultureIgnoreCase);
                licenseData.AuditInformation = ansiData[(indexOfDl + 2)..indexOfD];
                licenseData.CustomerId = ansiData[(ansiData.IndexOf("DAQ", StringComparison.InvariantCultureIgnoreCase) + 3)..];
            }
            else if (splitUpData.TryGetValue("AAM", out var aamvaData))
            {
                var indexOfDl = aamvaData.IndexOf("DL", StringComparison.InvariantCultureIgnoreCase);
                licenseData.InventoryControl = aamvaData[2..indexOfDl];
                var indexOfD = aamvaData.IndexOf("D", indexOfDl + 1, StringComparison.InvariantCultureIgnoreCase);
                licenseData.AuditInformation = aamvaData[(indexOfDl + 2)..indexOfD];
                licenseData.CustomerId = aamvaData[(aamvaData.IndexOf("DAQ", StringComparison.InvariantCultureIgnoreCase) + 3)..];
            }

            return licenseData;
        }
    }
}