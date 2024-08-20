namespace SsiGroup.ProjectUsNormalizer.Extensions;

/// <summary>
///   Collection extensions.
/// </summary>
internal static class CollectionExtensions
{
  /// <summary>
  ///   Attempts to get a value for associated key from a dictionary.
  /// </summary>
  /// <typeparam name="TKey">A type of key.</typeparam>
  /// <typeparam name="TValue">A type of value.</typeparam>
  /// <param name="dictionary">A dictionary.</param>
  /// <param name="key">A key.</param>
  /// <returns>A value for provided key when exists, otherwise default value.</returns>
  public static TValue? GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue>? dictionary, TKey key)
  {
    return dictionary.GetValueOrDefault(key, default!);
  }

  /// <summary>
  ///   Attempts to get a value for associated key from a dictionary.
  /// </summary>
  /// <typeparam name="TKey">A type of key.</typeparam>
  /// <typeparam name="TValue">A type of value.</typeparam>
  /// <param name="dictionary">A dictionary.</param>
  /// <param name="key">A key.</param>
  /// <param name="defaultValue">A default value, when key doesn't exist.</param>
  /// <returns>A value for provided key when exists, otherwise default value.</returns>
  public static TValue? GetValueOrDefault<TKey, TValue>(
    this IReadOnlyDictionary<TKey, TValue>? dictionary,
    TKey key,
    TValue defaultValue
  )
  {
    return dictionary?.TryGetValue(key, out TValue? value) ?? false ? value : defaultValue;
  }

  /// <summary>
  ///   Replaces a first occurrence of an existing item in a list with a new item.
  /// </summary>
  /// <typeparam name="T">A type of items in a list.</typeparam>
  /// <param name="source">A list of items.</param>
  /// <param name="oldValue">An old value.</param>
  /// <param name="newValue">A new value.</param>
  /// <returns>A list with updated value.</returns>
  /// <exception cref="ArgumentNullException">when source is null or oldValue doesn't exit in a list.</exception>
  public static List<T> ReplaceFirst<T>(this List<T> source, T oldValue, T newValue)
  {
    if (source == null)
    {
      throw new ArgumentNullException(nameof(source));
    }

    int oldValueIndex = source.IndexOf(oldValue);

    if (oldValueIndex != -1)
    {
      source[oldValueIndex] = newValue;
    }
    else
    {
      throw new ArgumentNullException(nameof(oldValue));
    }

    return source;
  }
}
