namespace AdventOfCode2022.Shared;

internal interface IChallenge<T>
{
    string Description { get; }

    T Execute(Input input);

}
