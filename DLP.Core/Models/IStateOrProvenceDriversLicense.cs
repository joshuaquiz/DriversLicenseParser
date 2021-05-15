using System.Collections.Generic;

namespace DLP.Core.Models
{
    public interface IStateOrProvenceDriversLicense
    {
        /// <summary>
        /// The friendly name of the state, provence, or other locality that issued the license.
        /// </summary>
        string StateOrProvenceName { get; set; }

        /// <summary>
        /// Drivers License Issuer Identification Number.
        /// </summary>
        /// <remarks>
        /// This list can be found (as of the time of this writing) at https://www.aamva.org/IIN-and-RID/
        /// </remarks>
        int DriversLicenseIssuerIdentificationNumber { get; set; }

        DriversLicenseData ParseDataForStateOrProvence(IEnumerable<string> rows);

        bool IsDataFromThisStateOrProvence(string data);
    }
}