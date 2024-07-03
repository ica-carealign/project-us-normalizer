namespace SsiGroup.ProjectUsNormalizer.Models;

/// <summary>
///   A street line fragment type.
/// </summary>
public enum StreetLineFragmentType
{
  /// <summary>
  ///   A numeric type. Means that it contains a digit, i.e. `124`, `87B`, or `M98BHS22`.
  /// </summary>
  Numeric,

  /// <summary>
  ///   A raw text type.
  /// </summary>
  RawText
}
