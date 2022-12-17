using AdventOfCode2022.Challenges.Challenge05;
using AdventOfCode2022.Shared.Tools;
using System.Diagnostics;

// pre-initialize for memory tracking and warm-up. It's not a good warmup, but it helps with me getting an idea of the memory usage
var challenge = new Part2();
var input = new DefaultInput();
challenge.Execute(input);


using (new MemoryAllocationLogger())
using (new StopwatchLogger())
{
    Console.WriteLine(challenge.Execute(input));
}