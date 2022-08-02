namespace DLP.Core.Models.Enums;

/// <summary>
/// AAMVA Genders:<br />
/// - Unknown: When the gender cannot be determined<br />
/// - Male: Male<br />
/// - Female: Female<br />
/// - Other: Not yet part of the AAMVA spec<br />
/// </summary>
public enum Gender
{
    /// <summary>
    /// Unknown Gender.
    /// </summary>
    Unknown,

    /// <summary>
    /// Male.
    /// </summary>
    Male,

    /// <summary>
    /// Female.
    /// </summary>
    Female,

    /// <summary>
    /// Other.
    /// </summary>
    Other
}