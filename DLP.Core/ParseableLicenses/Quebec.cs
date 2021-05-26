using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class Quebec : IParseableLicense
    {
        public string FullName => "Quebec";

        public string Abbreviation => "QC";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 604428;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}