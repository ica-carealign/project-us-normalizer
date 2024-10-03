using SsiGroup.ProjectUsNormalizer.Extensions;
using SsiGroup.ProjectUsNormalizer.Models;

namespace SsiGroup.ProjectUsNormalizer;

/// <summary>
///   An address normalizer.
/// </summary>
public static class AddressNormalizer
{
  /// <summary>
  ///   Normalizes a provided address.
  /// </summary>
  /// <param name="address">An address.</param>
  /// <returns>A new normalized address.</returns>
  public static Address Normalize(Address address)
  {
    return new Address(
      NormalizeStreetLine(address?.StreetAddress1),
      NormalizeStreetLine(address?.StreetAddress2),
      NormalizeCity(address?.City),
      NormalizeState(address?.State),
      NormalizePostalCode(address?.PostalCode),
      NormalizeCountry(address?.Country)
    );
  }

  /// <summary>
  ///   Normalizes an address city.
  /// </summary>
  /// <param name="city">A city.</param>
  /// <returns>A normalized city.</returns>
  public static string? NormalizeCity(string? city)
  {
    return AddressCleanerExtensions.CleanComponent(city);
  }

  /// <summary>
  ///   Normalizes an address country.
  /// </summary>
  /// <param name="country">A country.</param>
  /// <returns>A normalized country.</returns>
  public static string? NormalizeCountry(string? country)
  {
    return AddressCleanerExtensions.CleanComponent(country);
  }

  /// <summary>
  ///   Normalizes an address postal code.
  /// </summary>
  /// <param name="postalCode">A postal code.</param>
  /// <returns>A normalized postal code.</returns>
  public static string? NormalizePostalCode(string? postalCode)
  {
    return AddressCleanerExtensions.CleanComponent(postalCode);
  }

  /// <summary>
  ///   Normalizes an address state.
  /// </summary>
  /// <param name="state">A state.</param>
  /// <returns>A normalized state.</returns>
  public static string? NormalizeState(string? state)
  {
    return AddressCleanerExtensions.CleanComponent(state)?.AbbreviateState();
  }

  /// <summary>
  ///   Normalizes an address street line.
  /// </summary>
  /// <param name="streetLine">A street line.</param>
  /// <returns>A normalized street line.</returns>
  public static string? NormalizeStreetLine(string? streetLine)
  {
    List<string> parsedStreetComponents = StreetLineParser.Parse(streetLine)
      .Select(component => component.Text)
      .ToList();

    return parsedStreetComponents.Any()
      ? string.Join(" ", parsedStreetComponents)
      : null;
  }
}
