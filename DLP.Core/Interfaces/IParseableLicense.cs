using DLP.Core.Models;
using DLP.Core.Models.Enums;

namespace DLP.Core.Interfaces;

/// <summary>
/// Represents a entity with a parseable license.
/// </summary>
public interface IParseableLicense
{
    /// <summary>
    /// The friendly name of the state, provence, or other locality that issued the license.
    /// </summary>
    public string FullName { get; }

    /// <summary>
    /// The abbreviation of the state, provence, or other locality that issued the license.
    /// </summary>
    public string Abbreviation { get; }

    /// <summary>
    /// The country that issued the license.
    /// </summary>
    public IssuingCountry Country { get; }

    /// <summary>
    /// Drivers License Issuer Identification Number.
    /// </summary>
    /// <remarks>
    /// This list can be found (as of the time of this writing) at https://www.aamva.org/IIN-and-RID/
    /// </remarks>
    public int IssuerIdentificationNumber { get; }

    /// <summary>
    /// Is this data from this entity.
    /// </summary>
    /// <param name="data">The license data.</param>
    /// <returns>bool</returns>
    public bool IsDataFromEntity(string? data);

    /// <summary>
    /// Parses the string into a <see cref="DriversLicenseData"/>.
    /// </summary>
    /// <param name="data">The license data.</param>
    /// <returns><see cref="DriversLicenseData"/></returns>
    public DriversLicenseData ParseData(string? data);
}