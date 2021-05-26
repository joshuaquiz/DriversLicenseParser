using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Hawaii : IParseableLicense
    {
        public string FullName => "Hawaii";

        public string Abbreviation => "HI";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.UnitedStates;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636047;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}