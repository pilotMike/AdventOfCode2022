using AdventOfCode2022.Shared.Inputs;

namespace AdventOfCode2022.Shared;

internal interface IChallenge<T>
{
    string Description { get; }

    T Execute(TextInput input);

}
