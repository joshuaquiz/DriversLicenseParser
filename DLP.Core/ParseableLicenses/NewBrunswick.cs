using DLP.Core.Interfaces;
using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.ParseableLicenses
{
    public sealed class NewBrunswick : IParseableLicense
    {
        public string FullName => "New Brunswick";

        public string Abbreviation => "NB";

        /// <inheritdoc />
        public IssuingCountry Country => IssuingCountry.Canada;

        /// <inheritdoc />
        public int IssuerIdentificationNumber => 636017;

        public bool IsDataFromEntity(string data) =>
            data.Contains(IssuerIdentificationNumber.ToString());

        public DriversLicenseData ParseData(string data)
        {
            return null;
        }
    }
}