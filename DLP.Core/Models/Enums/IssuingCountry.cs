namespace DLP.Core.Models.Enums;

/// <summary>
/// AAMVA Issuing Countries:<br />
/// - Unknown: When the issuing country is not available<br />
/// - UnitedStates: The USA<br />
/// - Canada: Canada, eh?<br />
/// - Mexico: Unknown AAMVA status<br />
/// </summary>
public enum IssuingCountry
{
    /// <summary>
    /// Unknown Issuing Country.
    /// </summary>
    Unknown,

    /// <summary>
    /// The United States.
    /// </summary>
    UnitedStates,

    /// <summary>
    /// Canada, eh?
    /// </summary>
    Canada,

    /// <summary>
    /// Mexico: Unknown AAMVA status
    /// </summary>
    Mexico
}