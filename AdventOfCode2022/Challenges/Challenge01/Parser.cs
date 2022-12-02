namespace AdventOfCode2022.Challenges.Challenge01;

internal static class Parser
{
    /// <summary>
    /// Separates each line into groups on an empty line, then returns the sum of each group,
    /// representing the total calories carried by that elf.
    /// </summary>
    public static IEnumerable<Calories> ParseEachElvesCalories(Input input) =>
        input.ParseLines(enu => enu.Split(t =>
            {
                var line = t.text.AsSpan()[t.range];
                return line.IsEmpty || line.IsWhiteSpace();
            })
            .Select(set => set.Select(t => int.Parse(t.text.AsSpan()[t.range])))
        )
        .Select(set => new Calories(set.Sum()));
        //input.ParseLines(lines =>
        //        lines.Split(string.IsNullOrWhiteSpace)
        //        .Select(set => set.Select(int.Parse)))
        //    .Select(set => new Calories(set.Sum()));
}
