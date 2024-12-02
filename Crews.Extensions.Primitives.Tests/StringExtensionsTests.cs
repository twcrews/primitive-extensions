using System.Text;

namespace Crews.Extensions.Primitives.Tests;

public class StringExtensionsTests
{
  [Fact(DisplayName = "TrimStart returns initial string if trim parameter is empty.")]
  public void TrimStart_ReturnsOriginalOnEmptyParam()
  {
    string subject = "Hello world!";
    string actual = subject.TrimStart(string.Empty);

    Assert.Equal(subject, actual);
  }

  [Fact(DisplayName = "TrimEnd returns initial string if trim parameter is empty.")]
  public void TrimEnd_ReturnsOriginalOnEmptyParam()
  {
    string subject = "Hello world!";
    string actual = subject.TrimEnd(string.Empty);

    Assert.Equal(subject, actual);
  }

  [Theory(DisplayName = "TrimStart successfully trims all leading occurrances of a given string.")]
  [InlineData("!@!@!@Hello world!", "!@", "Hello world!")]
  [InlineData("abc123abcHello world!", "abc", "123abcHello world!")]
  [InlineData("abc123Hello world!", "123", "abc123Hello world!")]
  public void TrimStart_ReturnsCorrectlyTrimmedString(string subject, string param, string expected)
    => Assert.Equal(expected, subject.TrimStart(param));

  [Theory(DisplayName = "TrimStart successfully trims all leading occurrances of a given string.")]
  [InlineData("Hello world!#@#@#@", "#@", "Hello world!")]
  [InlineData("Hello world!abc123abc", "abc", "Hello world!abc123")]
  [InlineData("Hello world!123abc", "123", "Hello world!123abc")]
  public void TrimEnd_ReturnsCorrectlyTrimmedString(string subject, string param, string expected)
    => Assert.Equal(expected, subject.TrimEnd(param));

  [Theory(DisplayName = "Base64Encode correctly encodes strings.")]
  [InlineData("apple", "utf-8", "YXBwbGU=")]
  [InlineData("banana", "us-ascii", "YmFuYW5h")]
  [InlineData("cranberry", "utf-32", "YwAAAHIAAABhAAAAbgAAAGIAAABlAAAAcgAAAHIAAAB5AAAA")]
  [InlineData(
    "The quick brown fox jumps over the lazy dog.",
    null,  // Encoder should default to UTF8.
    "VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wcyBvdmVyIHRoZSBsYXp5IGRvZy4=")]
  public void Base64Encode_EncodesCorrectly(string input, string? encoding, string expected)
  {
    Encoding expectedEncoding = Encoding.UTF8;
    if (encoding != null)
    {
      expectedEncoding = Encoding.GetEncodings()
        .Select(i => i.GetEncoding())
        .Single(i => i.BodyName == encoding);
    }

    string actual = encoding == null ? input.Base64Encode() : input.Base64Encode(expectedEncoding);
    Assert.Equal(expected, actual);
  }

  [Theory(DisplayName = "ToPascalCase correctly converts strings")]
  [InlineData("snake_case_string", new char[] {}, "SnakeCaseString")]
  [InlineData("kebab-case-string", new char[] {}, "KebabCaseString")]
  [InlineData("camelCaseString", new char[] {}, "CamelCaseString")]
  [InlineData("variable_delimited-and.Cased string", new char[] {}, "VariableDelimitedAnd.CasedString")]
  [InlineData("PascalCaseString", new char[] {}, "PascalCaseString")]
  [InlineData("custom_delimited.string", new char[] {'.'}, "Custom_delimitedString")]
  [InlineData("ab_short_substring", new char[] {}, "ABShortSubstring")]
  public void ToPascalCase_ConvertsCorrectly(string subject, char[] delimiters, string expected)
  {
    string actual = subject.ToPascalCase(delimiters);
    Assert.Equal(expected, actual);
  }
}
