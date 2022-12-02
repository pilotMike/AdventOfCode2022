using System.Numerics;

namespace AdventOfCode2022.Extensions
{
    internal static class EnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> source) where T : struct, IAdditionOperators<T, T, T>
        {
            var sum = default(T);
            foreach ( var item in source)
            {
                checked { sum += item; }
            }
            return sum;
        }
    }
}
