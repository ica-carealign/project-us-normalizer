using System.Text.RegularExpressions;

using SsiGroup.ProjectUsNormalizer.Constants;

namespace SsiGroup.ProjectUsNormalizer.Extensions;

/// <summary>
///   An address cleaner extensions.
/// </summary>
internal static class AddressCleanerExtensions
{
  /// <summary>
  ///   Cleans an address component.
  /// </summary>
  /// <remarks>
  ///   It does following things:
  ///   1. Converts to upper.
  ///   2. Adds a space to a pound sign (#).
  ///   3. Removes invalid characters.
  ///   4. Replaces multiple whitespace characters with a single space.
  ///   5. Trims.
  /// </remarks>
  /// <param name="addressComponent">An address component.</param>
  /// <returns>A cleaned address component.</returns>
  internal static string? CleanComponent(string? addressComponent)
  {
    if (string.IsNullOrWhiteSpace(addressComponent))
    {
      return null;
    }

    return addressComponent
      .ToUpper()
      .AddSpaceToHash()
      .RemoveInvalidCharacters()
      .ReplaceWhitespaceCharactersWithSingleSpace()
      .Trim();
  }

  /// <summary>
  ///   Cleans a primary street name.
  /// </summary>
  /// <remarks>
  ///   In addition to cleaning address component <see cref="CleanComponent" />, it:
  ///   1. Abbreviates states.
  ///   2. Replaces special cases with expected values.
  ///   3. Replaces Rural routes with expected format.
  ///   4. Replaces interstate abbreviations with expected INTERSTATE word.
  /// </remarks>
  /// <param name="streetLine">A primary street line.</param>
  /// <returns>A cleaned primary street line.</returns>
  internal static string? CleanStreetLine(string? streetLine)
  {
    streetLine = CleanComponent(streetLine);

    if (string.IsNullOrWhiteSpace(streetLine))
    {
      return null;
    }

    return streetLine
      .AbbreviateState()
      .ReplaceSpecialCases()
      .ReplaceRuralRoutes()
      .ReplaceInterstateAbbreviation();
  }

  /// <summary>
  ///   Removes a period (.) from an address field except the filed is a decimal. In case of grid addresses period must not
  ///   be removed, i.e. in `123 ROAD 39.4` period should note be removed, but in `123 49TH. ST`, period must be removed.
  /// </summary>
  /// <param name="streetLineComponent">A street line component.</param>
  /// <returns>A fixed street line component.</returns>
  internal static string RemovePeriodsExceptForDecimals(string streetLineComponent)
  {
    if (streetLineComponent.Contains(value: '.') && !decimal.TryParse(streetLineComponent, out decimal _))
    {
      streetLineComponent = streetLineComponent.Replace(".", string.Empty);
    }

    return streetLineComponent;
  }

  /// <summary>
  ///   Adds a space to a pound sign (#).
  /// </summary>
  /// <param name="streetLine">A street line.</param>
  /// <returns>An updated street line.</returns>
  private static string AddSpaceToHash(this string streetLine)
  {
    return streetLine.Replace("#", "# ");
  }

  /// <summary>
  ///   Removes invalid characters.
  /// </summary>
  /// <param name="addressComponent">An address component.</param>
  /// <returns>A cleaned address component.</returns>
  private static string RemoveInvalidCharacters(this string addressComponent)
  {
    return RegexConstants.InvalidCharacters.Replace(addressComponent, string.Empty);
  }

  /// <summary>
  ///   Replaces an interstate abbreviation with full word INTERSTATE, i.e `123 I65 NORTH` will be replaces with `123
  ///   INTERSTATE 65 NORTH` or `123 IH10` will be replaced with `123 INTERSTATE 10`.
  /// </summary>
  /// <param name="streetLine">A street line.</param>
  /// <returns>An updated street line.</returns>
  private static string ReplaceInterstateAbbreviation(this string streetLine)
  {
    Match interstateMatch = RegexConstants.InterstateFollowedByNumber.Match(streetLine);

    if (interstateMatch.Success)
    {
      // everything before I or IH followed by number, i.e in `1132 IH20 EAST`, will pick `1132 `.
      string everythingBefore = streetLine.Substring(startIndex: 0, interstateMatch.Groups[groupnum: 1].Index);
      // everything after I or IH, i.e. in `1132 IH20 EAST`, will pick `20 EAST`.
      string everythingAfter = streetLine.Substring(interstateMatch.Groups[groupnum: 2].Index);
      // replace I or IH with INTERSTATE.
      streetLine = $"{everythingBefore}INTERSTATE {everythingAfter}";
    }

    return streetLine;
  }

  /// <summary>
  ///   Replaces RURAL ROUTES with expected format (RR _ BOX _). Street lines like `Rural Route Number 91 Box A7` should
  ///   become `RR 91 BOX A7` or `RFD0061 #87b Bryan Dairy Rd` should become `RR 61 BOX 87B`.
  /// </summary>
  /// <remarks>
  ///   RULES:
  ///   * SHOULD NOT use the words RURAL, NUMBER, NO., or the pound sign (#).
  ///   * MUST NOT add a leading zero before the rural route number.
  ///   * SHOULD include hyphens as part of the box number only when they are part of the address.
  ///   * SHOULD change the designations RFD and RD (as a meaning for rural or rural free delivery) to RR.
  ///   * SHOULD NOT allow additional designations, such as town or street names, on the patient Street Address Line of rural
  ///   route addresses.
  /// </remarks>
  /// <remarks></remarks>
  /// <param name="streetLine">A street line.</param>
  /// <returns>An updated street line.</returns>
  private static string ReplaceRuralRoutes(this string streetLine)
  {
    Match ruralRouteMatch = RegexConstants.RuralRoutes.Match(streetLine);

    if (ruralRouteMatch.Success)
    {
      // In rural routes pattern group 3 is route number (without leading 0).
      Group ruralRouteNumber = ruralRouteMatch.Groups[groupnum: 3];
      // In rural routes pattern group 5 is box number.
      Group boxNumber = ruralRouteMatch.Groups[groupnum: 5];
      // resulting rural route street line.
      streetLine = $"RR {ruralRouteNumber} BOX {boxNumber}";
    }

    return streetLine;
  }

  /// <summary>
  ///   Replaces special cases defined in <see cref="SpecialCases.Mappings" />.
  /// </summary>
  /// <param name="addressComponent">An address component.</param>
  /// <returns>An updated address component when it is matches one of the special cases.</returns>
  private static string ReplaceSpecialCases(this string addressComponent)
  {
    foreach (KeyValuePair<string, string> specialCase in SpecialCases.Mappings)
    {
      if (addressComponent.Contains(specialCase.Key))
      {
        addressComponent = addressComponent.Replace(specialCase.Key, specialCase.Value);
      }
    }

    return addressComponent;
  }

  private static string ReplaceWhitespaceCharactersWithSingleSpace(this string addressField)
  {
    return RegexConstants.Whitespaces.Replace(addressField, " ");
  }
}
