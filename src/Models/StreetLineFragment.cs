namespace SsiGroup.ProjectUsNormalizer.Models;

/// <summary>
///   A street line fragment.
/// </summary>
/// <param name="Text">A text of a street line piece.</param>
/// <param name="FragmentType">
///   A type, either <see cref="StreetLineFragmentType.Numeric" /> or
///   <see cref="StreetLineFragmentType.RawText" />.
/// </param>
public record StreetLineFragment(string Text, StreetLineFragmentType FragmentType);
