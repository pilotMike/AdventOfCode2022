using AdventOfCode2022.Challenges.Challenge03;
using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCodeTests.Challenges
{
    public class Challenge03Tests
    {
        [Fact]
        public void FirstDataRowIsCorrect()
        {
            const string firstRow = "vJrwpWtwJgWrhcsFMMfFFhFp";
            var input = new TextInput(firstRow);

            var c = new Part1();
            var res = c.Execute(input);

            var expected = new Priority('p' - 'a' + 1);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void SampleDataIsCorrect()
        {
            const string input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
            var i = new TextInput(input);
            var c = new Part1();
            var res = c.Execute(i);

            var expected = new Priority(157);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('z', 26)]
        [InlineData('A', 27)]
        [InlineData('Z', 52)]
        public void PrioritiesAreCorrect(char c, int expected)
        {
            var p = Priority.From(new Item(c));
            Assert.Equal(new Priority(expected), p);
        }
    }
}
