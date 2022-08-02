namespace DLP.Core.Models.Enums;

/// <summary>
/// Represents the different parts of a name that can be parsed.
/// </summary>
public enum NamePart
{
    /// <summary>
    /// Unknown name type.
    /// </summary>
    Undefined,

    /// <summary>
    /// Used to try to extract the first name.
    /// </summary>
    FirstName,

    /// <summary>
    /// Used to try to extract the middle name.
    /// </summary>
    MiddleName,

    /// <summary>
    /// Used to try to extract a short middle name.
    /// </summary>
    ShortMiddleName,

    /// <summary>
    /// Used to try to extract the last name.
    /// </summary>
    LastName,

    /// <summary>
    /// Used to try to extract the suffix.
    /// </summary>
    Suffix
}