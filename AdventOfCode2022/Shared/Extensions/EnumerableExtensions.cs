using System.Numerics;

namespace AdventOfCode2022.Shared.Extensions;

public static partial class EnumerableExtensions
{
    public static T Sum<T>(this IEnumerable<T> source) where T : struct, IAdditionOperators<T, T, T>
    {
        var sum = default(T);
        foreach (var item in source)
        {
            checked { sum += item; }
        }
        return sum;
    }

    public static IEnumerable<T> IntersectBy<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second,
        Func<T, TKey> keySelector)
    {
        var set = new Dictionary<TKey, T>(EqualityComparer<TKey>.Default);
        foreach (var s in second)
            set[keySelector(s)] = s;

        foreach (T element in first)
        {
            if (set.Remove(keySelector(element)))
            {
                yield return element;
            }
        }
    }
}
