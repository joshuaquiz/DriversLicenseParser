using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Louisiana : IParseableLicense
    {
        public string FullName => "Louisiana";

        public string Abbreviation => "LA";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636007;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}