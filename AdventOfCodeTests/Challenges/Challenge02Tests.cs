using AdventOfCode2022.Challenges.Challenge02;

namespace AdventOfCodeTests.Challenges
{
    public class Challenge02Tests
    {
        [Fact]
        public void Part1_SampleDataTest()
        {
            var input = new Input(@"A Y
B X
C Z");
            var challenge = new Part1();
            var result = challenge.Execute(input);

            Assert.Equal(new Points(15), result);
        }
    }
}
