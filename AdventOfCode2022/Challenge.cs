using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AdventOfCodeTests")]

namespace AdventOfCode2022;

internal abstract class Challenge<T>
{
    public abstract string Description { get; }

    public abstract T Execute(Input input);

}
