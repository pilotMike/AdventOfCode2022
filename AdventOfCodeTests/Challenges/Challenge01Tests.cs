using AdventOfCode2022;
using AdventOfCode2022.Challenges.Challenge01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCodeTests.Challenges
{
    
    public class Challenge01Tests
    {
        [Fact]
        public void Part01_WithSamepleInput_Returns_24000_ForTotalCalories()
        {
            var input = new Input(@"1000
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
}
