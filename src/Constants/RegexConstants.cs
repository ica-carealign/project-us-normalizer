using System.Text.RegularExpressions;

namespace SsiGroup.ProjectUsNormalizer.Constants;

/// <summary>
///   Static Regex constants.
/// </summary>
internal static class RegexConstants
{
  /// <summary>
  ///   A regex that matches 2-letter US states followed by a number, i.e. `123 CA 440` or `234 KY 20`.
  /// </summary>
  internal static readonly Regex UsStateFollowedByNumber = new(_stateFollowedByNumberPattern, RegexOptions.Compiled);

  /// <summary>
  ///   A regex that matches interstate shorthand followed by number, i.e. `I10` or `IH65`.
  /// </summary>
  internal static readonly Regex InterstateFollowedByNumber = new("(I|IH)([0-9]+)", RegexOptions.Compiled);

  /// <summary>
  ///   A regex that matches invalid characters for street line.
  /// </summary>
  /// <remarks>
  ///   Taken from https://pe.usps.com/text/pub28/28c3_019.htm
  /// </remarks>
  internal static readonly Regex InvalidCharacters = new("[*,()\":;'@&]", RegexOptions.Compiled);

  /// <summary>
  ///   A regex that matches multiple whitespaces.
  /// </summary>
  internal static readonly Regex Whitespaces = new(@"\s+", RegexOptions.Compiled);

  /// <summary>
  ///   A regex that matches Rural routes.
  /// </summary>
  /// <remarks>
  ///   The pattern must be RR _ BOX _.
  ///   RULES:
  ///   * SHOULD NOT use the words RURAL, NUMBER, NO., or the pound sign (#).
  ///   * MUST NOT add a leading zero before the rural route number.
  ///   * SHOULD include hyphens as part of the box number only when they are part of the address.
  ///   * SHOULD change the designations RFD and RD (as a meaning for rural or rural free delivery) to RR.
  ///   * SHOULD NOT allow additional designations, such as town or street names, on the patient Street Address Line of rural
  ///   route addresses.
  ///   The pattern matches several groups:
  ///   1. (RFD|RR|RD|RURAL ROUTE|RUTA).*? - Anything that start with RFD or RR or RD or RURAL ROUTE.
  ///   2. (0*) - Optional leading 0 of the number.
  ///   3. ([0-9]+) - Rural number.
  ///   4. (BOX|#|BUZON|BZN) - BOX, the pound sign (#), BUZON, or BZN surrounded by the spaces before and after.
  ///   5. ([0-9A-Z]+) - Box number that allows letters.
  ///   6. (.*) - Everything else after box number (should be ignored).
  /// </remarks>
  internal static readonly Regex RuralRoutes = new(_ruralRoutePattern, RegexOptions.Compiled);

  private const string _ruralRoutePattern = "(RFD|RR|RD|RURAL ROUTE|RUTA).*?(0*)([0-9]+) (BOX|#|BUZON|BZN) ([0-9A-Z]+)(.*)";

  private const string _stateFollowedByNumberPattern =
    "(AK|AL|AR|AZ|CA|CO|CT|DE|FL|GA|HI|IA|ID|IL|IN|KS|KY|LA|MA|MD|ME|MI|MN|MO|MS|MT|NC|ND|NE|NH|NJ|NM|NV|NY|OH|OK|OR|PA|RI|SC|SD|TN|TX|UT|VA|VT|WA|WI|WV|WY) ([0-9]+)(.*)";
}
