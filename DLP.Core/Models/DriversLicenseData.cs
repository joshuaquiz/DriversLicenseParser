using System;
using DLP.Core.Models.Enums;

namespace DLP.Core.Models;

/// <summary>
/// Represents data parsed from a drivers license.
/// </summary>
public sealed class DriversLicenseData
{
    /// <summary>
    /// Customer First Name
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// Customer Last Name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Customer Middle Name
    /// </summary>
    public string? MiddleName { get; set; }

    /// <summary>
    /// Document Expiration Date
    /// </summary>
    public DateTimeOffset? ExpirationDate { get; set; }

    /// <summary>
    /// Document Issue Date
    /// </summary>
    public DateTimeOffset? IssueDate { get; set; }

    /// <summary>
    /// Customer Date of Birth
    /// </summary>
    public DateTimeOffset? DateOfBirth { get; set; }

    /// <summary>
    /// Customer Gender
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Customer Eye Color
    /// </summary>
    public EyeColor EyeColor { get; set; }

    /// <summary>
    /// Customer Hair Color
    /// </summary>
    public HairColor HairColor { get; set; }

    /// <summary>
    /// Customer Height (in inches)
    /// </summary>
    public decimal? Height { get; set; }

    /// <summary>
    /// Customer Street Address
    /// </summary>
    public string? StreetAddress { get; set; }

    /// <summary>
    /// Customer Street Address Line 2
    /// </summary>
    public string? SecondStreetAddress { get; set; }

    /// <summary>
    /// Customer City
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Customer State
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Customer Postal Code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// Unique Customer ID Number
    /// </summary>
    public string? CustomerId { get; set; }

    /// <summary>
    /// Unique Document ID Number
    /// </summary>
    public string? DocumentId { get; set; }

    /// <summary>
    /// Issuing Country
    /// </summary>
    public IssuingCountry IssuingCountry { get; set; }

    /// <summary>
    /// Was Middle Name truncated?
    /// </summary>
    public Truncation MiddleNameTruncated { get; set; }

    /// <summary>
    /// Was First Name truncated?
    /// </summary>
    public Truncation FirstNameTruncated { get; set; }

    /// <summary>
    /// Was Last Name truncated?
    /// </summary>
    public Truncation LastNameTruncated { get; set; }

    /// <summary>
    /// Country and municipality and/or state/province.
    /// </summary>
    public string? PlaceOfBirth { get; set; }

    /// <summary>
    /// A string of letters and/or numbers that identifies when, where, and by whom a driver license/ID card was made.
    /// </summary>
    public string? AuditInformation { get; set; }

    /// <summary>
    /// A string of letters and/or numbers that is affixed to the raw materials (card stock, laminate, etc.) used in producing driver licenses and ID cards.
    /// </summary>
    public string? InventoryControl { get; set; }

    /// <summary>
    /// Other Last Name by which cardholder is known.
    /// </summary>
    public string? LastNameAlias { get; set; }

    /// <summary>
    /// Other First Name by which the cardholder is known.
    /// </summary>
    public string? FirstNameAlias { get; set; }

    /// <summary>
    /// Other suffix by which cardholder is known.
    /// </summary>
    public string? SuffixAlias { get; set; }

    /// <summary>
    /// Name Suffix.
    /// </summary>
    public NameSuffix NameSuffix { get; set; }

    /// <summary>
    /// The version of license.
    /// </summary>
    public LicenseVersion LicenseVersion{ get; set; }
}