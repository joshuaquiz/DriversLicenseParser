using System;
using System.Collections.Generic;
using System.Linq;
using DLP.Core.Exceptions;
using DLP.Core.Interfaces;
using DLP.Core.Models;

namespace DLP.Core
{
    public sealed class DriversLicenseParser
    {
        private readonly IReadOnlyCollection<IParseableLicense> _parseableLicenses;

        public DriversLicenseParser(IEnumerable<IParseableLicense> parseableLicenses)
        {
            _parseableLicenses = parseableLicenses?.ToList();
        }

        /// <summary>
        /// Attempts to parse the license data.
        /// </summary>
        /// <param name="data">The license data.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided data is empty or null.</exception>
        /// <exception cref="LicenseFormatException">Thrown if the data could not be matched to any known format.</exception>
        /// <returns><see cref="DriversLicenseData"/></returns>
        public DriversLicenseData Parse(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            var license = _parseableLicenses?.FirstOrDefault(x => x.IsDataFromEntity(data));
            if (license == null)
            {
                throw new LicenseFormatException(data);
            }

            return license.ParseData(data);
        }
    }
}