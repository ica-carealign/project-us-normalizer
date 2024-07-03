using SsiGroup.ProjectUsNormalizer.Constants;
using SsiGroup.ProjectUsNormalizer.Exceptions;
using SsiGroup.ProjectUsNormalizer.Models;

namespace SsiGroup.ProjectUsNormalizer.Extensions;

internal static class StreetLineFragmentExtensions
{
  /// <summary>
  ///   Attempts to retrieve a direction abbreviation from <see cref="Directions.Abbreviations" />.
  /// </summary>
  /// <param name="streetLineFragment">A street line fragment.</param>
  /// <returns>An abbreviated direction.</returns>
  /// <exception cref="InvalidAddressFragmentAbbreviationException">when provided element is not in the abbreviations list.</exception>
  internal static string GetDirectionAbbreviation(this StreetLineFragment streetLineFragment)
  {
    return Directions.Abbreviations.GetValueOrDefault(streetLineFragment.Text)
      ?? throw new InvalidAddressFragmentAbbreviationException(
        $"Couldn't get abbreviation for {streetLineFragment.Text} in {nameof(Directions.Abbreviations)}"
      );
  }

  /// <summary>
  ///   Attempts to retrieve a secondary unit designator abbreviation from
  ///   <see cref="SecondaryUnitDesignators.Abbreviations" />.
  /// </summary>
  /// <param name="streetLineFragment">A street line fragment.</param>
  /// <returns>An abbreviated secondary unit designator.</returns>
  /// <exception cref="InvalidAddressFragmentAbbreviationException">when provided element is not in the abbreviations list.</exception>
  internal static string GetSecondaryUnitAbbreviation(this StreetLineFragment streetLineFragment)
  {
    return SecondaryUnitDesignators.Abbreviations.GetValueOrDefault(streetLineFragment.Text)
      ?? throw new InvalidAddressFragmentAbbreviationException(
        $"Couldn't get abbreviation for {streetLineFragment.Text} in {nameof(SecondaryUnitDesignators.Abbreviations)}"
      );
  }

  /// <summary>
  ///   Attempts to retrieve a suffix abbreviation from <see cref="Suffixes.Abbreviations" />.
  /// </summary>
  /// <param name="streetLineFragment">A street line fragment.</param>
  /// <returns>An abbreviated suffix.</returns>
  /// <exception cref="InvalidAddressFragmentAbbreviationException">when provided element is not in the abbreviations list.</exception>
  internal static string GetSuffixAbbreviation(this StreetLineFragment streetLineFragment)
  {
    return Suffixes.Abbreviations.GetValueOrDefault(streetLineFragment.Text)
      ?? throw new InvalidAddressFragmentAbbreviationException(
        $"Couldn't get abbreviation for {streetLineFragment.Text} in {nameof(Suffixes.Abbreviations)}"
      );
  }

  /// <summary>
  ///   Checks whether street line piece is a direction.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <returns>A value indicating whether provided piece is a direction.</returns>
  internal static bool IsDirection(this StreetLineFragment? streetLinePiece)
  {
    return !string.IsNullOrEmpty(streetLinePiece?.Text)
      && Directions.Abbreviations.ContainsKey(streetLinePiece!.Text);
  }

  /// <summary>
  ///   Checks whether street line piece requires a secondary address.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <param name="nextComponent">A next component.</param>
  /// <returns>A value indicating whether required secondary address exist.</returns>
  internal static bool IsRequiredSecondaryAddressExist(
    this StreetLineFragment? streetLinePiece,
    StreetComponent? nextComponent
  )
  {
    return !string.IsNullOrEmpty(streetLinePiece?.Text)
      && !string.IsNullOrEmpty(nextComponent?.Text)
      && nextComponent!.ComponentType is StreetComponentType.SecondaryAddress
      && SecondaryUnitDesignators.RequireSecondaryAddress.Contains(streetLinePiece!.Text);
  }

  /// <summary>
  ///   Checks whether street line piece is a secondary unit designator.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <returns>A value indicating whether provided piece is a secondary unit designator.</returns>
  internal static bool IsSecondaryUnitDesignator(this StreetLineFragment? streetLinePiece)
  {
    return !string.IsNullOrEmpty(streetLinePiece?.Text)
      && SecondaryUnitDesignators.Abbreviations.ContainsKey(streetLinePiece!.Text);
  }

  /// <summary>
  ///   Checks whether street line piece is a suffix.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <returns>A value indicating whether provided piece is a suffix.</returns>
  internal static bool IsSuffix(this StreetLineFragment? streetLinePiece)
  {
    return !string.IsNullOrEmpty(streetLinePiece?.Text)
      && Suffixes.Abbreviations.ContainsKey(streetLinePiece!.Text);
  }

  /// <summary>
  ///   Converts street line piece to fully spelled out direction when it exists in
  ///   <see cref="Directions.FullySpelledOut" />, otherwise original text.
  /// </summary>
  /// <param name="streetLineFragment">A street line fragment.</param>
  /// <returns>A spelled out direction or original value.</returns>
  internal static string ToSpelledOutDirection(this StreetLineFragment streetLineFragment)
  {
    return streetLineFragment.Text.ToSpelledOutDirection();
  }

  /// <summary>
  ///   Converts street line piece to fully spelled out suffix when it exists in
  ///   <see cref="Suffixes.FullySpelledOut" />, otherwise original text.
  /// </summary>
  /// <param name="streetLineFragment">A street line fragment.</param>
  /// <returns>A spelled out suffix or original value.</returns>
  internal static string ToSpelledOutSuffix(this StreetLineFragment streetLineFragment)
  {
    return streetLineFragment.Text.ToSpelledOutSuffix();
  }

  /// <summary>
  ///   Converts street line piece to fully spelled out direction when it exists in
  ///   <see cref="Directions.FullySpelledOut" />, otherwise original text.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <returns>A spelled out direction or original value.</returns>
  private static string ToSpelledOutDirection(this string streetLinePiece)
  {
    return Directions.FullySpelledOut.TryGetValue(streetLinePiece, out string? fullySpelledDirection)
      ? fullySpelledDirection
      : streetLinePiece;
  }

  /// <summary>
  ///   Converts street line piece to fully spelled out suffix when it exists in
  ///   <see cref="Suffixes.FullySpelledOut" />, otherwise original text.
  /// </summary>
  /// <param name="streetLinePiece">A street line fragment.</param>
  /// <returns>A spelled out suffix or original value.</returns>
  private static string ToSpelledOutSuffix(this string streetLinePiece)
  {
    return Suffixes.FullySpelledOut.TryGetValue(streetLinePiece, out string? fullySpelledSuffix)
      ? fullySpelledSuffix
      : streetLinePiece;
  }
}
