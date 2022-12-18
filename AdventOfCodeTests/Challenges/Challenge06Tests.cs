using AdventOfCode2022.Challenges.Challenge06;
using AdventOfCode2022.Shared.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests.Challenges;
public class Challenge06Tests
{
    [Theory]
    [InlineData(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(6, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void Part1_IsCorrect_WithSampleData(int expected, string input)
    {
        var res = new Part1().Execute(new TextInput(input));

        Assert.Equal(expected, res);
    }

    [Theory]
    [InlineData(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
    [InlineData(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
    [InlineData(23, "nppdvjthqldpwncqszvftbrmjlhg")]
    [InlineData(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
    [InlineData(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
    public void Part2_IsCorrect_WithSampleData(int expected, string input)
    {
        var res = new Part2().Execute(new TextInput(input));

        Assert.Equal(expected, res);
    }
}
