namespace SsiGroup.ProjectUsNormalizer.Models;

/// <summary>
///   A record representing an address.
/// </summary>
/// <param name="StreetAddress1">A street line 1.</param>
/// <param name="StreetAddress2">A street line 2.</param>
/// <param name="City">A city.</param>
/// <param name="State">A state.</param>
/// <param name="PostalCode">A postal code.</param>
/// <param name="Country">A country.</param>
public record Address(
  string? StreetAddress1 = null,
  string? StreetAddress2 = null,
  string? City = null,
  string? State = null,
  string? PostalCode = null,
  string? Country = null
);
