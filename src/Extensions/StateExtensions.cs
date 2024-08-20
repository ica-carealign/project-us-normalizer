using SsiGroup.ProjectUsNormalizer.Constants;
using SsiGroup.ProjectUsNormalizer.Models;

namespace SsiGroup.ProjectUsNormalizer.Extensions;

/// <summary>
///   Various extensions dealing with the US state names in street components.
/// </summary>
internal static class StateExtensions
{
  /// <summary>
  ///   Replaces state values with 2-letter abbreviated version from <see cref="States.Abbreviations" />.
  /// </summary>
  /// <param name="addressComponent">A street name component.</param>
  /// <returns>An abbreviated version of the US state when matches; otherwise provided string.</returns>
  internal static string AbbreviateState(this string addressComponent)
  {
    foreach (KeyValuePair<string, string> state in States.Abbreviations)
    {
      if (addressComponent.ToUpper().Contains(state.Key))
      {
        addressComponent = addressComponent.Replace(state.Key, state.Value);
      }
    }

    return addressComponent;
  }

  /// <summary>
  ///   Checks whether a given string is one of the US states or not, either abbreviated or fully spelled out.
  /// </summary>
  /// <param name="streetComponent">A street name component.</param>
  /// <returns>A value indicating whether it matches one of the states.</returns>
  internal static bool IsState(this StreetComponent? streetComponent)
  {
    return streetComponent?.Text?.IsState() ?? false;
  }

  /// <summary>
  ///   Checks whether a given string is one of the US states or not, either abbreviated or fully spelled out.
  /// </summary>
  /// <param name="streetLineFragment">A street name component.</param>
  /// <returns>A value indicating whether it matches one of the states.</returns>
  internal static bool IsState(this StreetLineFragment? streetLineFragment)
  {
    return streetLineFragment?.Text?.IsState() ?? false;
  }

  /// <summary>
  ///   Replaces state values with 2-letter abbreviated version from <see cref="States.Abbreviations" />.
  /// </summary>
  /// <param name="streetNameComponent">A street name.</param>
  /// <returns>A fully spelled out name of a state or original string.</returns>
  internal static string ToSpelledOutState(this StreetComponent streetNameComponent)
  {
    return States.FullySpelledOut.TryGetValue(streetNameComponent.Text, out string? fullySpelledState)
      ? fullySpelledState
      : streetNameComponent.Text;
  }

  /// <summary>
  ///   Checks whether a given string is part of the 2-letter abbreviation of the US states.
  /// </summary>
  /// <param name="streetName">A street name component.</param>
  /// <returns>A value indicating whether it matches one of the state abbreviations.</returns>
  private static bool IsAbbreviatedState(this string? streetName)
  {
    return !string.IsNullOrEmpty(streetName)
      && States.Abbreviations.ContainsKey(streetName);
  }

  /// <summary>
  ///   Checks whether a given string is part of full names of the US states.
  /// </summary>
  /// <param name="streetComponent">A street name component.</param>
  /// <returns>A value indicating whether it matches one of the fully spelled out states.</returns>
  private static bool IsSpelledOutState(this string? streetComponent)
  {
    return !string.IsNullOrEmpty(streetComponent)
      && States.FullySpelledOut.ContainsKey(streetComponent);
  }

  /// <summary>
  ///   Checks whether a given string is one of the US states or not, either abbreviated or fully spelled out.
  /// </summary>
  /// <param name="streetName">A street name component.</param>
  /// <returns>A value indicating whether it matches one of the states.</returns>
  private static bool IsState(this string? streetName)
  {
    return !string.IsNullOrEmpty(streetName) && (streetName.IsAbbreviatedState() || streetName.IsSpelledOutState());
  }
}
