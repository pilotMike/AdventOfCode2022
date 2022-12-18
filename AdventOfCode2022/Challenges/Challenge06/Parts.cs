using AdventOfCode2022.Shared.Inputs;
using System.Collections;

namespace AdventOfCode2022.Challenges.Challenge06;

record Signal(IEnumerable<char> Characters);
abstract record Subroutine { public abstract int IndexOfStart(Signal signal); }
record StartOfPacketMarker : Subroutine
{
    const int PackageLength = 4;
    public override int IndexOfStart(Signal signal) =>
        signal.Characters.Window(PackageLength)
            .Select((w, i) => (w, i))
            .First(t => t.w.Distinct().Count() == PackageLength)
            .i + PackageLength;
}
record StartOfMesssageMarker : Subroutine
{
    const int MessageMarkerLength = 14;
    public override int IndexOfStart(Signal signal) =>
        signal.Characters
        .Window(MessageMarkerLength)
            .Select((w, i) => (w, i))
            .First(t => t.w.Distinct().Count() == MessageMarkerLength)
            .i + MessageMarkerLength;
}

class CommunicationSystem
{
    private readonly Subroutine subroutine;

    public CommunicationSystem(Subroutine subroutine) => this.subroutine = subroutine;

    public int LockOn(Signal signal) => subroutine.IndexOfStart(signal);
}

class Part1 : IChallenge<int>
{
    public string Description => "Find the first sequence of 4 characters that are distinct.";

    public int Execute(TextInput input) =>
        new CommunicationSystem(new StartOfPacketMarker())
        .LockOn(new Signal(input.Characters));
}

class Part2 : IChallenge<int>
{
    public string Description => "Now do it again for 14 characters in length";

    public int Execute(TextInput input) =>
        new CommunicationSystem(new StartOfMesssageMarker())
        .LockOn(new Signal(input.Characters));
}
