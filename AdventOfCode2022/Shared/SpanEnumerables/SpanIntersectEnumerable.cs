using System.Runtime.CompilerServices;

namespace AdventOfCode2022.Shared.Extensions;

public static partial class EnumerableExtensions
{
    public static SpanIntersectEnumerable<TSource> Intersect<TSource>(
        this ReadOnlySpan<TSource> source,
        ReadOnlySpan<TSource> second)
    {
        return new SpanIntersectEnumerable<TSource>(source, second);
    }

    public readonly ref struct SpanIntersectEnumerable<TSource>
    {
        private readonly ReadOnlySpan<TSource> source;
        private readonly ReadOnlySpan<TSource> second;

        public SpanIntersectEnumerable(ReadOnlySpan<TSource> source, ReadOnlySpan<TSource> second)
        {
            this.source = source;
            this.second = second;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Enumerator GetEnumerator() => new(in this);

        public ref struct Enumerator
        {
            private readonly ReadOnlySpan<TSource> source;
            private readonly HashSet<TSource> set;
            private int index;

            internal Enumerator(in SpanIntersectEnumerable<TSource> enumerable)
            {
                this.source = enumerable.source;
                this.set = new HashSet<TSource>();
                foreach (ref readonly var item in enumerable.second)
                    set.Add(item);
                this.index = -1;
            }

            public ref readonly TSource Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => ref source[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext()
            {
                while (++index < source.Length)
                {
                    if (set.Remove(source[index]))
                        return true;
                }
                return false;
            }
        }
    }
}
