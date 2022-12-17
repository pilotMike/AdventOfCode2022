using AdventOfCode2022.Challenges.Challenge01;
using AdventOfCode2022.Shared;
using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCodeTests.Challenges;


public class Challenge01Tests
{
    [Fact]
    public void Part01_WithSamepleInput_Returns_24000_ForTotalCalories()
    {
        var input = new TextInput(@"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000");
        var challenge = new Part1();
        var result = challenge.Execute(input);

        Assert.Equal(new Calories(24000), result);
    }
}
