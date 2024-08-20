namespace SsiGroup.ProjectUsNormalizer.Models;

/// <summary>
///   Street address component type.
/// </summary>
/// <remarks>
///   Taken from Project US@ technical specification:
///   <a href="https://oncprojectracking.healthit.gov/wiki/pages/viewpage.action?pageId=180486153" />.
///   Version 1.0. ADDRESS ELEMENTS AND ABBREVIATIONS. Pages 16-17.
/// </remarks>
public enum StreetComponentType
{
  /// <summary>
  ///   Primary Address Number type.
  /// </summary>
  PrimaryAddressNumber,

  /// <summary>
  ///   Pre-directional type.
  /// </summary>
  Predirectional,

  /// <summary>
  ///   Primary Street Name type.
  /// </summary>
  StreetName,

  /// <summary>
  ///   Suffix type.
  /// </summary>
  Suffix,

  /// <summary>
  ///   Post-directional type.
  /// </summary>
  Postdirectional,

  /// <summary>
  ///   Secondary Address Identifier type.
  /// </summary>
  SecondaryAddressIdentifier,

  /// <summary>
  ///   Secondary Address type.
  /// </summary>
  SecondaryAddress
}
