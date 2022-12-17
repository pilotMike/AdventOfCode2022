using AdventOfCode2022.Shared.Inputs;
using static AdventOfCode2022.Challenges.Challenge02.Hand;

namespace AdventOfCode2022.Challenges.Challenge02;

internal sealed class Part1 : IChallenge<Points>
{
    public string Description { get; } = @"Rock, Paper, Scissors:
For example, suppose you were given the following strategy guide:

A Y
B X
C Z
This strategy guide predicts and recommends the following:

In the first round, your opponent will choose Rock (A), and you should choose Paper (Y). This ends in a win for you with a score of 8 (2 because you chose Paper + 6 because you won).
In the second round, your opponent will choose Paper (B), and you should choose Rock (X). This ends in a loss for you with a score of 1 (1 + 0).
The third round is a draw with both players choosing Scissors, giving you a score of 3 + 3 = 6.
In this example, if you were to follow the strategy guide, you would get a total score of 15 (8 + 1 + 6).

What would your total score be if everything goes exactly according to your strategy guide?";

    

    public Points Execute(TextInput input)
    {
        static Hand opponentMap(char c) => c switch
        {
            'A' => Rock,
            'B' => Paper,
            'C' => Scissors
        };
        static Hand ourSideMap(char c) => c switch
        {
            'Y' => Paper,
            'X' => Rock,
            'Z' => Scissors
        };

        return input.ParseLinesSpan((ref ReadOnlySpan<char> line) =>
        {
            var them = opponentMap(line[0]);
            var us = ourSideMap(line[2]);
            var outcome = us.Compare(them);
            return new Points(outcome) + us.Points;
        }).Sum();
    }
}
