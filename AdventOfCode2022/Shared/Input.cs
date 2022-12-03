using AdventOfCode2022.Shared.Tools;

namespace AdventOfCode2022.Shared;

internal delegate T SpanParseDelegate<T>(SpanLineEnumerable lines);
internal delegate T SpanRefDelegate<T>(ref ReadOnlySpan<char> line);
internal class Input
{
    private readonly string lines;

    public Input(string lines)
    {
        this.lines = lines;
    }

    public T ParseLines<T>(SpanParseDelegate<T> selector)
    {
        var enu = new SpanLineEnumerable(lines);
        return selector(enu);
    }

    public IEnumerable<T> ParseLines<T>(SpanRefDelegate<T> selector)
    {
        foreach (var (range, text) in new SpanLineEnumerable(lines))
        {
            var line = text.AsSpan()[range];
            yield return selector(ref line);
        }
    }
}
