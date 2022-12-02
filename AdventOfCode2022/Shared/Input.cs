

using AdventOfCode2022.Shared.Tools;

namespace AdventOfCode2022.Shared;

internal delegate T SpanParseDelegate<T>(SpanLineEnumerable enumerator);
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
}
