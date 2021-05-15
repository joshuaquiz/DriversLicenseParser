namespace DLP.Core.Models.Enums
{
    /// <summary>
    /// AAMVA Name Truncations:<br />
    /// - Unknown: When the truncation cannot be determined<br />
    /// - Truncated: The name was truncated<br />
    /// - None: The name was not truncated<br />
    /// </summary>
    public enum Truncation
    {
        /// <summary>
        /// Unknown Truncation.
        /// </summary>
        Unknown,

        /// <summary>
        /// Truncated Name.
        /// </summary>
        Truncated,

        /// <summary>
        /// Not Truncated.
        /// </summary>
        None
    }
}