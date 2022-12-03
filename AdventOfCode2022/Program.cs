using AdventOfCode2022.Challenges.Challenge02;
using AdventOfCode2022.Shared.Tools;

// pre-initialize for memory tracking and warm-up. It's not a good warmup, but it helps with me getting an idea of the memory usage
var challenge = new Part2();
var input = new DefaultInput();
challenge.Execute(input);

using (new MemoryAllocationLogger())
{
    Console.WriteLine(challenge.Execute(input));
}