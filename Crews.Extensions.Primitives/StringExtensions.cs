using System.Globalization;
using System.Text;

namespace Crews.Extensions.Primitives;

/// <summary>
/// Contains extension methods useful for interacting with <see cref="string"/> instances.
/// </summary>
public static class StringExtensions
{
  /// <summary>
  /// Removes all the leading occurrences of <paramref name="trimString"/> from <paramref name="target"/>.
  /// </summary>
  /// <param name="target">The original string on which to operate.</param>
  /// <param name="trimString">The string to be trimmed.</param>
  /// <returns>
  /// The string that remains after all occurrences of <paramref name="trimString"/> are removed from the start of
  /// <paramref name="target"/>. If no strings can be trimmed from the current instance, or if
  /// <paramref name="trimString"/> is null or empty, the method returns the current instance unchanged.
  /// </returns>
  public static string TrimStart(this string target, string trimString)
  {
    if (string.IsNullOrEmpty(trimString)) return target;

    string result = target;
    while (result.StartsWith(trimString))
    {
      result = result[trimString.Length..];
    }

    return result.TrimStart();
  }

  /// <summary>
  /// Removes all the trailing occurrences of <paramref name="trimString"/> from <paramref name="target"/>.
  /// </summary>
  /// <param name="target">The original string on which to operate.</param>
  /// <param name="trimString">The string to be trimmed.</param>
  /// <returns>
  /// The string that remains after all occurrences of <paramref name="trimString"/> are removed from the end of
  /// <paramref name="target"/>. If no strings can be trimmed from the current instance, or if
  /// <paramref name="trimString"/> is null or empty, the method returns the current instance unchanged.
  /// </returns>
  public static string TrimEnd(this string target, string trimString)
  {
    if (string.IsNullOrEmpty(trimString)) return target;

    string result = target;
    while (result.EndsWith(trimString))
    {
      result = result[..^trimString.Length];
    }

    return result;
  }

  /// <summary>
  /// Gets the Base64-encoded representation of <paramref name="target"/>.
  /// </summary>
  /// <param name="target">The original string to be encoded.</param>
  /// <param name="encoding">The encoding to use. If unspecified, <see cref="Encoding.UTF8"/> is used.</param>
  /// <returns>A new Base64 string encoding of <paramref name="target"/>.</returns>
  public static string Base64Encode(this string target, Encoding? encoding = null)
  {
    encoding ??= Encoding.UTF8;
    byte[] data = encoding.GetBytes(target);
    return Convert.ToBase64String(data);
  }

  /// <summary>
  /// Converts <paramref name="target"/> into a pascal case string.
  /// </summary>
  /// <param name="target">The string to convert.</param>
  /// <param name="delimiters">
  /// One or more characters considered delimiters in <paramref name="target"/>. If unspecified, hyphen ('-'),
  /// underscore ('_'), and space (' ') characters are used.
  /// </param>
  /// <returns>A pascal case form of <paramref name="target"/>.</returns>
  public static string ToPascalCase(this string target, params char[] delimiters) => string.Join("", target
    .Split(delimiters.Length > 0 ? delimiters : ['-', ' ', '_'], 
      StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
    .Select(word => char.ToUpper(word[0]) + word[1..]));
}
