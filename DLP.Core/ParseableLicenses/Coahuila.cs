using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Coahuila : IParseableLicense
    {
        public string FullName => "Coahuila";

        public string Abbreviation => "CU";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Mexico;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636056;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}