using AdventOfCode2022.Extensions;

namespace AdventOfCode2022.Challenges.Challenge01
{
    internal class Part2 : Challenge<Calories>
    {
        public override string Description { get; } =
            @"By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. 
That way, even if one of those Elves runs out of snacks, they still have two backups.";

        public override Calories Execute(Input input) => Parser.ParseEachElvesCalories(input).OrderDescending().Take(3).Sum();
    }
}
