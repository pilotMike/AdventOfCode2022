using static AdventOfCode2022.Challenges.Challenge02.Hand;
using static AdventOfCode2022.Challenges.Challenge02.Outcome;

namespace AdventOfCode2022.Challenges.Challenge02;

internal sealed class Part2 : IChallenge<Points>
{
    public string Description { get; } = @"The Elf finishes helping with the tent and sneaks back over to you. 
""Anyway, the second column says how the round needs to end: X means you need to lose, 
Y means you need to end the round in a draw, and Z means you need to win. Good luck!""";

    public Points Execute(Input input)
    {
        static Hand opponentMap(char c) => c switch
        {
            'A' => Rock,
            'B' => Paper,
            'C' => Scissors
        };
        static Outcome desiredOutcome(char c) => c switch
        {
            'X' => Loss,
            'Y' => Draw,
            'Z' => Win
        };

        return input.ParseLines(static (ref ReadOnlySpan<char> line) =>
        {
            // before (using LINQ .First()): 336,312 bytes
            // after: 24,912 bytes
            var them = opponentMap(line[0]);
            var outcome = desiredOutcome(line[2]);
            Hand ours = them; // satisfy the compiler
            // do an equivalent of .First assuming there will be a match to avoid a closure
            foreach (var h in AllHands)
                if (h.Compare(them) == outcome)
                    ours = h;

            return new Points(outcome) + ours.Points;
        }).Sum();
    }
}
