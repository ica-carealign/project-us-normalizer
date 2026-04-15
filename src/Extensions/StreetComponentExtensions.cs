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
  ///   For example, in <c>123 N E MILES JOHNSON PARKWAY AVE S E</c>, where
  ///   <list type="bullet">
  ///     <item><c>123</c> - Primary Address Number.</item>
  ///     <item><c>N</c> - Pre-direction.</item>
  ///     <item><c>E</c> - Pre-direction.</item>
  ///     <item><c>MILES</c> - Primary Street Name.</item>
  ///     <item><c>JOHNSON</c> - Primary Street Name.</item>
  ///     <item><c>PARKWAY</c> - Suffix.</item>
  ///     <item><c>AVE</c> - Suffix.</item>
  ///     <item><c>S</c> - Post-direction.</item>
  ///     <item><c>E</c> - Post-direction.</item>
  ///     <item><c>BLDG</c> - Secondary address identifier.</item>
  ///     <item><c>420</c> - Secondary address.</item>
  ///     <item><c>RM</c> - Secondary address identifier.</item>
  ///     <item><c>120</c> - Secondary address.</item>
  ///   </list>
  ///   This extension will group <see cref="StreetComponent" />s by each type, combining them appropriately with or without
  ///   space, resulting in <c>123 NE MILES JOHNSON PARKWAY AVE SE BLDG 420 RM 120</c>, where
  ///   <list type="bullet">
  ///     <item><c>123</c> - Primary Address Number.</item>
  ///     <item><c>NE</c> - Pre-direction.</item>
  ///     <item><c>MILES JOHNSON</c> - Primary Street Name.</item>
  ///     <item><c>PARKWAY AVE</c> - Suffix.</item>
  ///     <item><c>SE</c> - Post-direction.</item>
  ///     <item><c>BLDG 420</c> - Secondary address identifier and number.</item>
  ///     <item><c>RM 120</c> - Secondary address identifier and number.</item>
  ///   </list>
  /// </remarks>
  /// <param name="components">A collection of <see cref="StreetComponent" />.</param>
  /// <returns>A combined collection of <see cref="StreetComponent" />.</returns>
  internal static List<StreetComponent> CombineComponents(this List<StreetComponent> components)
  {
    components.Reverse();

    // Secondary address components should not be grouped.  
    List<StreetComponent> secondaryAddressComponents = components.Where(static component =>
      component.ComponentType is StreetComponentType.SecondaryAddress or StreetComponentType.SecondaryAddressIdentifier
    ).ToList();

    return components
      .Except(secondaryAddressComponents)
      .GroupBy(comp => comp.ComponentType)
      .Select(group => group.Key switch
        {
          StreetComponentType.Predirectional or StreetComponentType.Postdirectional => new StreetComponent(
            string.Join("", group.Select(static component => component.Text)),
            group.Key
          ),
          _ => new StreetComponent(
            string.Join(" ", group.Select(static component => component.Text)),
            group.Key
          )
        }
      )
      .Concat(secondaryAddressComponents)
      .ToList();
  }

  /// <summary>
  ///   Checks whether <see cref="StreetComponent" /> is <see cref="StreetComponentType.PreStreetParts" />, meaning that
  ///   it comes before
  ///   <see cref="StreetComponentType.PrimaryAddressNumber" /> or <see cref="StreetComponentType.Predirectional" />.
  /// </summary>
  /// <param name="streetComponent">A parsed street component.</param>
  /// <returns>A value indicating whether next street component type is PreStreetPart.</returns>
  internal static bool IsPreStreetPart(this StreetComponent? streetComponent)
  {
    return streetComponent?.ComponentType is StreetComponentType.PreStreetParts
      or StreetComponentType.PrimaryAddressNumber
      or StreetComponentType.Predirectional;
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
  ///   <list type="number">
  ///     <item>
  ///       When the name of a state is used as a portion of the Primary Street Name, such as <c>123 TN COUNTY ROAD 4</c>,
  ///       it SHOULD use the standard two-letter abbreviation (previous steps took care of that).
  ///       <item>
  ///       </item>
  ///       When the name of a state is the complete Primary Street Name, such as <c>OKLAHOMA AVE</c>, then the state name
  ///       SHOULD be spelled out completely.
  ///       <item>
  ///       </item>
  ///       When the name of a state is followed by a number, such as <c>123 TN 440</c>, it SHOULD insert word HIGHWAY
  ///       between state name and a number.
  ///     </item>
  ///   </list>
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

    // Replace state abbreviate followed by number with state abbreviation word <c>HIGHWAY</c> and then number,
    // i.e. replace <c>123 TN 440</c> with <c>123 TN HIGHWAY 440</c>.
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
