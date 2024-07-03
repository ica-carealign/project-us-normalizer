using SsiGroup.ProjectUsNormalizer.Extensions;
using SsiGroup.ProjectUsNormalizer.Models;

namespace SsiGroup.ProjectUsNormalizer;

/// <summary>
///   Parses street line address into a collection of <see cref="StreetComponent" />.
/// </summary>
public static class StreetLineParser
{
  /// <summary>
  ///   Parses a street line into appropriate street components.
  /// </summary>
  /// <param name="streetLine">A street line.</param>
  /// <returns>A collection of <see cref="StreetComponent" />.</returns>
  public static IEnumerable<StreetComponent> Parse(string? streetLine)
  {
    List<StreetComponent> components = new();
    streetLine = AddressCleanerExtensions.CleanStreetLine(streetLine);

    if (string.IsNullOrWhiteSpace(streetLine))
    {
      return components;
    }

    string[] streetLineFragments = streetLine.Split(separator: ' ');
    List<StreetLineFragment> pieces = streetLineFragments.Select(ParseStreetLineFragment).Reverse().ToList();

    for (int index = 0; index < pieces.Count; index++)
    {
      StreetComponent? nextComponent = components.LastOrDefault();
      StreetLineFragment? previousPiece = pieces.ElementAtOrDefault(index + 1);
      StreetLineFragment currentFragment = pieces[index];
      // checks whether there is anything before previous piece.
      bool isMoreItemsBeforePreviousPiece = pieces.Count > index + 2;

      components.Add(
        ParseStreetComponent(
          currentFragment,
          previousPiece,
          nextComponent,
          isMoreItemsBeforePreviousPiece
        )
      );
    }

    components = components.CombineComponents()
      .NormalizeState();

    return components;
  }

  private static StreetComponent ParseDirectionComponent(
    StreetLineFragment currentFragment,
    StreetComponent? nextComponent
  )
  {
    string directionAbbreviation = currentFragment.GetDirectionAbbreviation();

    return nextComponent?.ComponentType switch
    {
      StreetComponentType.StreetName => new StreetComponent(
        directionAbbreviation,
        StreetComponentType.Predirectional
      ),
      StreetComponentType.Predirectional => new StreetComponent(
        directionAbbreviation,
        StreetComponentType.Predirectional
      ),
      StreetComponentType.Suffix => new StreetComponent(
        currentFragment.ToSpelledOutDirection(),
        StreetComponentType.StreetName
      ),
      _ => new StreetComponent(directionAbbreviation, StreetComponentType.Postdirectional)
    };
  }

  private static StreetComponent ParseStreetComponent(
    StreetLineFragment currentFragment,
    StreetLineFragment? previousPiece,
    StreetComponent? nextComponent,
    bool isMoreItemsBeforePreviousPiece
  )
  {
    if (previousPiece?.IsSecondaryUnitDesignator() ?? false)
    {
      return new StreetComponent(currentFragment.Text, StreetComponentType.SecondaryAddress);
    }

    if (currentFragment.IsSecondaryUnitDesignator() && currentFragment.IsRequiredSecondaryAddressExist(nextComponent))
    {
      return new StreetComponent(
        currentFragment.GetSecondaryUnitAbbreviation(),
        StreetComponentType.SecondaryAddressIdentifier
      );
    }

    if (currentFragment.FragmentType == StreetLineFragmentType.Numeric)
    {
      return previousPiece != null
        ? new StreetComponent(currentFragment.Text, StreetComponentType.StreetName)
        : new StreetComponent(currentFragment.Text, StreetComponentType.PrimaryAddressNumber);
    }

    if (currentFragment.IsDirection())
    {
      return ParseDirectionComponent(currentFragment, nextComponent);
    }

    // There are some US states that match suffix abbreviates, namely CT, KY, MT, PR, WY.
    if (currentFragment.IsState() && nextComponent.IsStreetNameOrSuffix())
    {
      return new StreetComponent(currentFragment.Text, StreetComponentType.StreetName);
    }

    if (currentFragment.IsSuffix())
    {
      return ParseSuffixComponent(currentFragment, nextComponent, isMoreItemsBeforePreviousPiece);
    }

    return new StreetComponent(currentFragment.Text, StreetComponentType.StreetName);
  }

  private static StreetLineFragment ParseStreetLineFragment(string streetLineFragment)
  {
    streetLineFragment = AddressCleanerExtensions.RemovePeriodsExceptForDecimals(streetLineFragment);

    return streetLineFragment.Any(char.IsDigit)
      ? new StreetLineFragment(streetLineFragment, StreetLineFragmentType.Numeric)
      : new StreetLineFragment(streetLineFragment, StreetLineFragmentType.RawText);
  }

  private static StreetComponent ParseSuffixComponent(
    StreetLineFragment currentFragment,
    StreetComponent? nextComponent,
    bool isMoreItemsBeforePreviousPiece
  )
  {
    if (ShouldSpellOutSuffix(nextComponent, isMoreItemsBeforePreviousPiece))
    {
      return new StreetComponent(
        currentFragment.ToSpelledOutSuffix(),
        StreetComponentType.StreetName
      );
    }

    return new StreetComponent(currentFragment.GetSuffixAbbreviation(), StreetComponentType.Suffix);
  }

  /// <summary>
  ///   Checks whether suffix should be fully spelled out or not.
  /// </summary>
  /// <remarks>
  ///   Current suffix should be spelled out when:
  ///   1. Next component is a street name, i.e. 123 HIGHWAY 395, HIGHWAY should be spelled out because next component is
  ///   part of street name.
  ///   2. Next component is a suffix (double suffix), i.e. 23 MAIN AVENUE DR (AVENUE should be fully spelled out because
  ///   next component DR is a suffix).
  ///   3. When there are no more items before previous piece (which should be primary address number), i.e. 100 AVENUE E
  ///   should be fully spell out AVENUE because previous piece is 100 (primary address number) and there is no more items
  ///   before it.
  /// </remarks>
  /// <param name="nextComponent">Next street component (already parsed).</param>
  /// <param name="isMoreItemsBeforePreviousPiece">A value indication whether there are more items before previous piece.</param>
  /// <returns>A value indicating whether suffix should be spelled out fully or not.</returns>
  private static bool ShouldSpellOutSuffix(StreetComponent? nextComponent, bool isMoreItemsBeforePreviousPiece)
  {
    return nextComponent.IsStreetNameOrSuffix() || !isMoreItemsBeforePreviousPiece;
  }
}
