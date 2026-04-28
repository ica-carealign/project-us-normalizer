using SsiGroup.ProjectUsNormalizer.Constants;
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
      StreetLineFragment currentFragment = pieces[index];
      StreetLineFragment? previousPiece = pieces.ElementAtOrDefault(index + 1);
      StreetLineFragment? beforePreviousPiece = pieces.ElementAtOrDefault(index + 2);

      components.Add(
        ParseStreetComponent(
          currentFragment,
          previousPiece,
          nextComponent,
          beforePreviousPiece
        )
      );
    }

    components = components.CombineComponents()
      .NormalizeState();

    return components;
  }

  /// <summary>
  ///   Tries to analyze previous and next pieces to check whether it should be marked as
  ///   <see cref="StreetComponentType.PrimaryAddressNumber" />.
  /// </summary>
  /// <remarks>
  ///   It is applicable only on the <c>Numeric</c> street fragment.
  ///   Some examples (should return true for those):
  ///   <list type="bullet">
  ///     <item><c>488</c> in <c>488 west 49th. Street</c>.</item>
  ///     <item><c>520</c> in <c>Unit 3250 520 2nd Street North East Lobby</c>.</item>
  ///     <item><c>611MN4</c> in <c>611MN4 40th. Ave North Apt 243</c>.</item>
  ///     <item><c>3324</c> in <c>3324 TN HIGHWAY 431</c>.</item>
  ///     <item><c>454</c> in <c>454 TN 431</c>.</item>
  ///     <item><c>52</c> in <c>52 TN 431 UNIT 12</c>.</item>
  ///     <item><c>955</c> in <c>955 IH20 BYP RD</c>.</item>
  ///     <item><c>932</c> in <c>Apartment 223B 932 1/2 Main Street</c>.</item>
  ///   </list>
  /// </remarks>
  /// <param name="previousPiece">A previous street line fragment.</param>
  /// <param name="currentFragment">A current street line fragment.</param>
  /// <param name="nextComponent">A next parsed component.</param>
  /// <param name="beforePreviousPiece">A fragment that precedes previous fragment.</param>
  /// <returns>A value indicating whether it should be marked as primary address number.</returns>
  private static bool IsPrimaryAddressNumber(
    StreetLineFragment currentFragment,
    StreetComponent? nextComponent,
    StreetLineFragment? previousPiece,
    StreetLineFragment? beforePreviousPiece
  )
  {
    // current fragment must be Numeric
    if (currentFragment.FragmentType is not StreetLineFragmentType.Numeric)
    {
      return false;
    }

    // when there are no more fragments before this numeric, it is a primary address number.
    if (previousPiece == null)
    {
      return true;
    }

    // next fragment is street or predirectional, but previous piece is secondary unit address preceded by secondary unit designator.
    // In case of <c>Unit 3200 152 North East Tech Dr Upper</c> - <c>152</c> is primary address number.
    // In case of <c>Unit 3200 152 Tech Dr Upper</c> - <c>152</c> is primary address number.
    if (nextComponent?.ComponentType is StreetComponentType.StreetName or StreetComponentType.Predirectional
        && previousPiece.FragmentType == StreetLineFragmentType.Numeric
        && beforePreviousPiece?.IsSecondaryUnitDesignator() == true
       )
    {
      return true;
    }

    // next fragment is street or predirectional, but previous piece is secondary unit designator and there is nothing else in front.
    // In case of <c>#3200 South Tech Street</c> - <c>3200</c> is NOT primary address number, but secondary address.
    // In case of <c>UCENT Building 411 N Central Ave</c> - <c>411</c> IS primary address number, NOT secondary address.
    if (nextComponent?.ComponentType is StreetComponentType.StreetName or StreetComponentType.Predirectional
        && previousPiece.IsSecondaryUnitDesignator()
        && beforePreviousPiece != null
       )
    {
      return true;
    }

    // when current numeric in front of predirectional, it is a primary address number.
    if (nextComponent?.ComponentType == StreetComponentType.Predirectional
        && previousPiece?.IsSecondaryUnitDesignator() != true
       )
    {
      return true;
    }

    // next fragment is street, but previous is NOT numeric, highway, nor secondary unit designator.
    // In case of <c>932 1/2 Main Street</c> - <c>1/2</c> is not primary address number, but part of street name.
    // In case of <c>3324 HWY 431 FRONTAGE RD</c> - <c>431</c> is NOT primary address number, but highway number.
    if (nextComponent?.ComponentType == StreetComponentType.StreetName
        && previousPiece.FragmentType != StreetLineFragmentType.Numeric
        && !IsSpecialCaseHighwayDesignation(previousPiece)
        && !previousPiece.IsSecondaryUnitDesignator()
       )
    {
      return true;
    }

    return false;
  }

  private static bool IsSecondaryAddress(
    StreetLineFragment currentFragment,
    StreetComponent? nextComponent,
    StreetLineFragment? previousPiece,
    StreetLineFragment? beforePreviousPiece
  )
  {
    return previousPiece?.IsSecondaryUnitDesignator() == true
      && !currentFragment.IsSecondaryUnitDesignator()
      && !IsPrimaryAddressNumber(currentFragment, nextComponent, previousPiece, beforePreviousPiece);
  }

  private static bool IsSpecialCaseHighwayDesignation(StreetLineFragment? previousPiece)
  {
    return previousPiece?.IsState() == true
      || (!string.IsNullOrEmpty(previousPiece?.Text) && SpecialCases.Highways.Contains(previousPiece.Text));
  }

  private static StreetComponent ParseDirectionComponent(
    StreetLineFragment currentFragment,
    StreetComponent? nextComponent
  )
  {
    string directionAbbreviation = currentFragment.GetDirectionAbbreviation();

    return nextComponent?.ComponentType switch
    {
      StreetComponentType.PreStreetParts => new StreetComponent(
        currentFragment.Text,
        StreetComponentType.PreStreetParts
      ),
      StreetComponentType.PrimaryAddressNumber => new StreetComponent(
        currentFragment.Text,
        StreetComponentType.PreStreetParts
      ),
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
    StreetLineFragment? beforePreviousPiece
  )
  {
    if (IsPrimaryAddressNumber(currentFragment, nextComponent, previousPiece, beforePreviousPiece))
    {
      return new StreetComponent(currentFragment.Text, StreetComponentType.PrimaryAddressNumber);
    }

    if (IsSecondaryAddress(currentFragment, nextComponent, previousPiece, beforePreviousPiece))
    {
      return new StreetComponent(currentFragment.Text, StreetComponentType.SecondaryAddress);
    }

    if (currentFragment.IsSecondaryUnitDesignator() && currentFragment.MeetsSecondaryAddressRequirements(nextComponent))
    {
      return new StreetComponent(
        currentFragment.GetSecondaryUnitAbbreviation(),
        StreetComponentType.SecondaryAddressIdentifier
      );
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

    if (currentFragment.IsSuffix() && !nextComponent.IsPreStreetPart())
    {
      return ParseSuffixComponent(currentFragment, nextComponent, beforePreviousPiece != null);
    }

    if (nextComponent.IsPreStreetPart()
        || nextComponent?.ComponentType is StreetComponentType.SecondaryAddressIdentifier)
    {
      return new StreetComponent(currentFragment.Text, StreetComponentType.PreStreetParts);
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
  ///   <list type="number">
  ///     <item>
  ///       Next component is a street name, i.e. <c>123 HIGHWAY 395</c>, <c>HIGHWAY</c> should be spelled out because next
  ///       component is part of street name.
  ///     </item>
  ///     <item>
  ///       Next component is a suffix (double suffix), i.e. <c>23 MAIN AVENUE DR</c> (<c>AVENUE</c> should be fully spelled
  ///       out because next component <c>DR</c> is a suffix).
  ///     </item>
  ///     <item>
  ///       When there are no more items before previous piece (which should be primary address number), i.e.
  ///       <c>100 AVENUE E</c> should be fully spell out <c>AVENUE</c> because previous piece is <c>100</c> (primary address
  ///       number) and there is no more items before it.
  ///     </item>
  ///   </list>
  /// </remarks>
  /// <param name="nextComponent">Next street component (already parsed).</param>
  /// <param name="isMoreItemsBeforePreviousPiece">A value indication whether there are more items before previous piece.</param>
  /// <returns>A value indicating whether suffix should be spelled out fully or not.</returns>
  private static bool ShouldSpellOutSuffix(StreetComponent? nextComponent, bool isMoreItemsBeforePreviousPiece)
  {
    return nextComponent.IsStreetNameOrSuffix() || !isMoreItemsBeforePreviousPiece;
  }
}
