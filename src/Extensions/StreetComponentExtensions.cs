using System.Text.RegularExpressions;

using SsiGroup.ProjectUsNormalizer.Constants;
using SsiGroup.ProjectUsNormalizer.Models;

namespace SsiGroup.ProjectUsNormalizer.Extensions;

/// <summary>
///   Street component extensions.
/// </summary>
internal static class StreetComponentExtensions
{
  /// <summary>
  ///   Combines multiple street component types together after parsing is done.
  /// </summary>
  /// <remarks>
  ///   When multiple component types are directional it combines them without adding space;
  ///   all other components are combined with a space.
  ///   For example, in `123 N E MILES JOHNSON PARKWAY AVE S E`, where
  ///   * `123` - Primary Address Number.
  ///   * `N` - Pre-direction
  ///   * `E` - Pre-direction
  ///   * `MILES` - Primary Street Name
  ///   * `JOHNSON` - Primary Street Name
  ///   * `PARKWAY` - Suffix
  ///   * `AVE` - Suffix
  ///   * `S` - Post-direction
  ///   * `E` - Post-direction
  ///   This extension will group <see cref="StreetComponent" />s by each type, combining them appropriately with or without
  ///   space, resulting in `123 NE MILES JOHNSON PARKWAY AVE SE`, where
  ///   * `123` - Primary Address Number.
  ///   * `NE` - Pre-direction
  ///   * `MILES JOHNSON` - Primary Street Name
  ///   * `PARKWAY AVE` - Suffix
  ///   * `SE` - Post-direction
  /// </remarks>
  /// <param name="components">A collection of <see cref="StreetComponent" />.</param>
  /// <returns>A combined collection of <see cref="StreetComponent" />.</returns>
  internal static List<StreetComponent> CombineComponents(this List<StreetComponent> components)
  {
    components.Reverse();

    return components.GroupBy(comp => comp.ComponentType)
      .Select(
        group => group.Key switch
        {
          StreetComponentType.Predirectional or StreetComponentType.Postdirectional => new StreetComponent(
            string.Join("", group.Select(component => component.Text)),
            group.Key
          ),
          _ => new StreetComponent(
            string.Join(" ", group.Select(component => component.Text)),
            group.Key
          )
        }
      ).ToList();
  }

  /// <summary>
  ///   Checks whether <see cref="StreetComponent" /> is Primary Street Name or Suffix.
  /// </summary>
  /// <param name="nextComponent">A parsed street component.</param>
  /// <returns>A value indicating whether next street component type is StreetName or Suffix.</returns>
  internal static bool IsStreetNameOrSuffix(this StreetComponent? nextComponent)
  {
    return nextComponent?.ComponentType is StreetComponentType.StreetName or StreetComponentType.Suffix;
  }

  /// <summary>
  ///   Normalizes the US state in the street line.
  /// </summary>
  /// <remarks>
  ///   Normalization of state names in street line rules:
  ///   1. When the name of a state is used as a portion of the Primary Street Name, such as `123 TN COUNTY ROAD 4`, it
  ///   SHOULD use the standard two-letter abbreviation (previous steps took care of that).
  ///   2. When the name of a state is the complete Primary Street Name, such as OKLAHOMA AVE, then the state name SHOULD be
  ///   spelled out completely.
  ///   3. When the name of a state is followed by a number, such as `123 TN 440`, it SHOULD insert word HIGHWAY between
  ///   state name and a number.
  /// </remarks>
  /// <param name="components"></param>
  /// <returns></returns>
  internal static List<StreetComponent> NormalizeState(this List<StreetComponent> components)
  {
    StreetComponent? streetNameComponent = components
      .FirstOrDefault(component => component.ComponentType is StreetComponentType.StreetName);

    if (streetNameComponent?.IsState() ?? false)
    {
      components.ReplaceFirst(
        streetNameComponent!,
        new StreetComponent(streetNameComponent.ToSpelledOutState(), StreetComponentType.StreetName)
      );
    }

    // Replace state abbreviate followed by number with state abbreviation word HIGHWAY and then number,
    // i.e. replace `123 TN 440` with `123 TN HIGHWAY 440`.
    Match stateFollowedByNumberMatch =
      RegexConstants.UsStateFollowedByNumber.Match(streetNameComponent?.Text ?? string.Empty);

    if (stateFollowedByNumberMatch.Success)
    {
      components.ReplaceFirst(
        streetNameComponent!,
        new StreetComponent(
          $"{stateFollowedByNumberMatch.Groups[groupnum: 1]} HIGHWAY {stateFollowedByNumberMatch.Groups[groupnum: 2]}{stateFollowedByNumberMatch.Groups[groupnum: 3]}",
          StreetComponentType.StreetName
        )
      );
    }

    return components;
  }
}
