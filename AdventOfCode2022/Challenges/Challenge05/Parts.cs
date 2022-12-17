using AdventOfCode2022.Shared.Inputs;
using AdventOfCode2022.Shared.Tools;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Challenges.Challenge05;

readonly record struct BoxStackID
{
    public readonly int Value;
    public BoxStackID(int value)
    {
        if (value < 1 || value > 9)
            Throw.ArgumentOutOfRangeException(nameof(value), "Value must be between 1 and 9, inclusive.");
        this.Value = value;
    }
}
interface ICrateMover
{
    void MoveCrates(int count, BoxStack from, BoxStack to);
}
sealed class CrateMover9000 : ICrateMover
{
    public void MoveCrates(int count, BoxStack from, BoxStack to)
    {
        for (int i = 0; i < count; i++)
        {
            var box = from.Pop();
            to.Add(box);
        }
    }
}
sealed class CrateMover9001 : ICrateMover
{
    public void MoveCrates(int count, BoxStack from, BoxStack to)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < count; i++)
        {
            stack.Push(from.Pop());
        }
        foreach (var item in stack)
        {
            to.Add(item);
        }
    }
}

internal class Part1 : IChallenge<string>
{
    private readonly ICrateMover _crateMover;

    public string Description => "After the rearrangement procedure completes, what crate ends up on top of each stack?";

    public Part1(ICrateMover moveCrates = null) => _crateMover = moveCrates ?? new CrateMover9000();

    public string Execute(TextInput input)
    {
        return input.ParseLinesEnumerable(lineEnumerable =>
        {
            var enu = lineEnumerable.GetEnumerator();
            var container = ReadBoxLayout(ref enu);
            ExecuteInstructions(container, ref enu);
            return container.TopCrates;
        });
    }

    private static BoxContainer ReadBoxLayout(ref SpanLineEnumerator enu)
    {
        // sample layout
        // [W] [V]     [P]                      
        // [B] [T]     [C] [B]     [G]        
        // [G] [S]     [V] [H] [N] [T]        
        // [Z] [B] [W] [J] [D] [M] [S]        
        // [R] [C] [N] [N] [F] [W] [C]     [W]
        // [D] [F] [S] [M] [L] [T] [L] [Z] [Z]
        // [C] [W] [B] [G] [S] [V] [F] [D] [N]
        // [V] [G] [C] [Q] [T] [J] [P] [B] [M]
        //  1   2   3   4   5   6   7   8   9 

        var container = new BoxContainer();
        // read current layout (in reverse)
        while (enu.MoveNext())
        {
            (Range r, string text) = enu.Current;
            var line = text.AsSpan()[r];
            if (line.IsWhiteSpace())
                break;

            int j = 1;
            // read to end of line to add boxes
            for (int i = 1; i <= line.Length; i += 4)
            {
                var box = line[i];
                if (char.IsNumber(box)) break; // reached the number of the box stacks
                var stack = container.GetStackById(new BoxStackID(j));
                stack.Add(box);
                j++;
            }
        }
        // the container is set up in reverse, so make it right
        return container.Reverse();
    }

    private void ExecuteInstructions(BoxContainer container, ref SpanLineEnumerator enu)
    {
        BoxStack Find(int id) => container.GetStackById(new BoxStackID(id));
        while (enu.MoveNext())
        {
            (Range r, string text) = enu.Current;

            var match = CommandRegex.Match(text, startat: r.Start.Value);
            var (count, from, to) = (
                int.Parse(match.Groups["count"].ValueSpan),
                Find(int.Parse(match.Groups["from"].ValueSpan)),
                Find(int.Parse(match.Groups["to"].ValueSpan)));

            _crateMover.MoveCrates(count, from, to);
        }
    }

    static Regex CommandRegex { get; } = new Regex("move (?<count>[0-9]*) from (?<from>[1-9]) to (?<to>[[1-9])", RegexOptions.Compiled);
}

class Part2 : IChallenge<string>
{
    public string Description { get; } = "Move multiple boxes instead of one, so the order is preserved";

    public string Execute(TextInput input)
    {
        var part1 = new Part1(new CrateMover9001());
        return part1.Execute(input);
    }
}
