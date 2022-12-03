using System.Numerics;

namespace AdventOfCode2022.Challenges.Challenge02;

readonly record struct Points : IAdditionOperators<Points, Points, Points>
{
    private readonly int value;

    public Points(int value) => this.value = value;
    public Points(Outcome outcome) => this.value = (int)outcome;

    public override string ToString() => nameof(Points) + " { " + value + " }";

    public static Points operator +(Points a, Points b) => new (a.value + b.value);
}
