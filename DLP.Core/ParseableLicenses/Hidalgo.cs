using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Hidalgo : IParseableLicense
    {
        public string FullName => "Hidalgo";

        public string Abbreviation => "HL";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Mexico;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636057;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}