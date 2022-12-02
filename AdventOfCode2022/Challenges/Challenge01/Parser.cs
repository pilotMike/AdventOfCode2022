using MoreLinq;

namespace AdventOfCode2022.Challenges.Challenge01
{
    internal static class Parser
    {
        /// <summary>
        /// Separates each line into groups on an empty line, then returns the sum of each group.
        /// </summary>
        public static IEnumerable<int> ParseEachElvesCalories(Input input) => 
            input.ParseLines(lines =>
                    lines.Split(string.IsNullOrWhiteSpace)
                    .Select(set => set.Select(int.Parse)))
                .Select(set => set.Sum());
    }
}
