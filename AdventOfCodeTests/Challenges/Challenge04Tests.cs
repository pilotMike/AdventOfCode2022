using AdventOfCode2022.Challenges.Challenge04;
using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCodeTests.Challenges;
public class Challenge04Tests
{
    [Fact]
    public void Part1_IsCorrect_WithSampleInput()
    {
        const string input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        var c = new Part1();
        var result = c.Execute(new TextInput(input));

        Assert.Equal(2, result);
    }

    [Fact]
    public void Part1_2sCorrect_WithSampleInput()
    {
        const string input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

        var c = new Part2();
        var result = c.Execute(new TextInput(input));

        Assert.Equal(4, result);
    }
}
