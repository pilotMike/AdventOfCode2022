using AdventOfCode2022.Shared.Tools;

namespace AdventOfCode2022.Shared.Inputs;

internal delegate T SpanParseDelegate<T>(SpanLineEnumerable lines);
internal delegate T SpanRefDelegate<T>(ref ReadOnlySpan<char> line);
internal class TextInput : Input
{
    private readonly string lines;

    public TextInput(string lines)
    {
        this.lines = lines;
    }

    public T ParseLinesEnumerable<T>(SpanParseDelegate<T> selector)
    {
        var enu = new SpanLineEnumerable(lines);
        return selector(enu);
    }

    public IEnumerable<T> ParseLinesSpan<T>(SpanRefDelegate<T> selector)
    {
        foreach (var (range, text) in new SpanLineEnumerable(lines))
        {
            var line = text.AsSpan()[range];
            yield return selector(ref line);
        }
    }
}
