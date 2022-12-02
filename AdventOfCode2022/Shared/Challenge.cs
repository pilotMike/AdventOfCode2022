

namespace AdventOfCode2022.Shared;

internal abstract class Challenge<T>
{
    public abstract string Description { get; }

    public abstract T Execute(Input input);

}
