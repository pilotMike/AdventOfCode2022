namespace AdventOfCode2022.Shared;

internal class Input
{
    private readonly string lines;

    public Input(string lines)
    {
        this.lines = lines;
    }

    public T ParseLines<T>(Func<IEnumerable<string>, T> selector)
    {
        return selector(lines.Split(Environment.NewLine));

    }
}
