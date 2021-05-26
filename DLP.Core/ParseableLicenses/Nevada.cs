using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Nevada : IParseableLicense
    {
        public string FullName => "Nevada";

        public string Abbreviation => "NV";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636049;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}