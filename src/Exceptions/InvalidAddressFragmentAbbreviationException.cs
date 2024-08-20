namespace SsiGroup.ProjectUsNormalizer.Exceptions;

/// <summary>
///   Invalid address fragment abbreviation exception.
/// </summary>
public class InvalidAddressFragmentAbbreviationException : Exception
{
  /// <summary>
  ///   Initializes a new instance of the <see cref="InvalidAddressFragmentAbbreviationException" /> class.
  /// </summary>
  /// <param name="message">An error message.</param>
  public InvalidAddressFragmentAbbreviationException(string message) : base(message)
  {
  }

  /// <summary>
  ///   Initializes a new instance of the <see cref="InvalidAddressFragmentAbbreviationException" /> class.
  /// </summary>
  /// <param name="message">An error message.</param>
  /// <param name="innerException">Inner exception</param>
  public InvalidAddressFragmentAbbreviationException(string message, Exception innerException)
    : base(message, innerException)
  {
  }
}
