namespace AdventOfCode2022.Shared.Extensions;

internal static class ParserExtensions
{
    /// <summary>
    /// Returns whether the subsection of a string is null or white space.
    /// </summary>
    public static bool IsNullOrWhiteSpace(this (Range r, string t) source)
    {
        ReadOnlySpan<char> span = source.t.AsSpan()[source.r];
        return span.IsEmpty || span.IsWhiteSpace();
    }

    /// <summary>
    /// Parses the subset of a string into an integer.
    /// </summary>
    public static int ParseInt(this (Range r, string t) source) => int.Parse(source.t.AsSpan()[source.r]);

    public static IEnumerable<char> GetCharacters(this (Range r, string s) line)
    {
        for (int i = line.r.Start.Value; i < line.r.End.Value; i++)
        {
            yield return line.s[i];
        }
    }
}
