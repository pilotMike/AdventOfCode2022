using System.Numerics;

namespace AdventOfCode2022.Challenges.Challenge01
{
    internal readonly record struct Calories : IAdditionOperators<Calories, Calories, Calories>, IComparable<Calories>
    {
        private readonly int value;

        public Calories(int value) => this.value = value;

        public override string ToString() => nameof(Calories) + " { " + value + " }";

        public int CompareTo(Calories other) => value.CompareTo(other.value);

        public static Calories operator +(Calories left, Calories right) => new Calories(right.value + left.value);
    }
}
