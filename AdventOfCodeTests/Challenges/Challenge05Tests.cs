using AdventOfCode2022.Challenges.Challenge05;
using AdventOfCode2022.Shared.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeTests.Challenges;
public class Challenge05Tests
{
    [Fact]
    public void Part1_IsCorrect_WithSampleInput()
    {
        const string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

        var c = new Part1();
        var res = c.Execute(new TextInput(input));

        Assert.Equal("CMZ", res);
    }

    [Fact]
    public void Part2_IsCorrect_WithSampleInput()
    {
        const string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

        var c = new Part2();
        var res = c.Execute(new TextInput(input));

        Assert.Equal("MCD", res);
    }


}
