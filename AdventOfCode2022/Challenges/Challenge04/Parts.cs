using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCode2022.Challenges.Challenge04;

static class RangeExtensions
{
    static bool Between(this int x, Range r) => r.Start.Value <= x && x <= r.End.Value;

    public static bool FullyContains(this Range source, Range target) =>
        source.Start.Value <= target.Start.Value && source.End.Value >= target.End.Value;

    public static bool Overlaps(this Range left, Range right) =>
        left.Start.Value.Between(right) || left.End.Value.Between(right) ||
        right.Start.Value.Between(left) || right.End.Value.Between(left);

}

static class Parser
{
    public static Range Parse(ReadOnlySpan<char> part)
    {
        var hyphen = part.IndexOf('-');
        var start = int.Parse(part.Slice(0, hyphen));
        var end = int.Parse(part.Slice(hyphen + 1));
        return new Range(new Index(start), new Index(end));
    }
    public static (Range a, Range b) ParseLine(ref ReadOnlySpan<char> line)
    {
        var splitOn = line.IndexOf(',');
        var elfA = Parse(line.Slice(0, splitOn));
        var elfB = Parse(line.Slice(splitOn + 1));
        return (elfA, elfB);
    }
}

internal class Part1 : IChallenge<int>
{
    public string Description { get; } = @"Space needs to be cleared before the last supplies can be unloaded from the ships, 
and so several Elves have been assigned the job of cleaning up sections of the camp. Every section has a unique ID number, 
and each Elf is assigned a range of section IDs.

However, as some of the Elves compare their section assignments with each other, they've noticed that many of the assignments 
overlap. To try to quickly find overlaps and reduce duplicated effort, the Elves pair up and make a big list of the section 
assignments for each pair (your puzzle input).

Some of the pairs have noticed that one of their assignments fully contains the other. For example, 2-8 fully contains 3-7, 
and 6-6 is fully contained by 4-6. In pairs where one assignment fully contains the other, one Elf in the pair would be 
exclusively cleaning sections their partner will already be cleaning, so these seem like the most in need of reconsideration. 
In this example, there are 2 such pairs.

In how many assignment pairs does one range fully contain the other?";

    public int Execute(TextInput input) =>
        input.ParseLinesSpan(Parser.ParseLine)
            .Count(elves => elves.a.FullyContains(elves.b) || elves.b.FullyContains(elves.a));
}

internal sealed class Part2 : IChallenge<int>
{
    public string Description { get; } = "In how many assignment pairs do the ranges overlap? (at all)";

    public int Execute(TextInput input) =>
        input.ParseLinesSpan(Parser.ParseLine)
            .Count(elves => elves.a.Overlaps(elves.b));
}