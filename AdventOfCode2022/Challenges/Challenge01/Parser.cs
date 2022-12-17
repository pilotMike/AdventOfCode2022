using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCode2022.Challenges.Challenge01;

internal static class Parser
{
    /// <summary>
    /// Separates each line into groups on an empty line, then returns the sum of each group,
    /// representing the total calories carried by that elf.
    /// </summary>
    public static IEnumerable<Calories> ParseEachElvesCalories(TextInput input) =>
        input.ParseLinesEnumerable(line => 
            line.Split(t => t.IsNullOrWhiteSpace())
            .Select(set => set.Select(t => t.ParseInt()))
        )
        .Select(set => new Calories(set.Sum()));
}
