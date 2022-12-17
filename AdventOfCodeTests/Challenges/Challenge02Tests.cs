using AdventOfCode2022.Challenges.Challenge02;
using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCodeTests.Challenges;

public class Challenge02Tests
{
    [Fact]
    public void Part1_SampleDataTest()
    {
        var input = new TextInput(@"A Y
B X
C Z");
        var challenge = new Part1();
        var result = challenge.Execute(input);

        Assert.Equal(new Points(15), result);
    }
}
