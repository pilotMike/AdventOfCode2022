using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Shared.Extensions;
using AdventOfCode2022.Shared.Inputs;
using AdventOfCode2022.Shared.Tools;
using MoreLinq;
using NetFabric.Hyperlinq;

namespace AdventOfCode2022.Challenges.Challenge03;

readonly record struct Item(char ItemType);
readonly record struct Priority(int Value) : IAdditionOperators<Priority, Priority, Priority>
{
    public static Priority From(Item item) =>
        new (
            item.ItemType switch
            {
                >= 'a' and <= 'z' => item.ItemType - 'a' + 1,
                >= 'A' and <= 'Z' => item.ItemType - 'A' + 27
            });
    public static Priority operator +(Priority a, Priority b) =>
        new Priority(a.Value + b.Value);
    public static Priority operator *(Priority p, int count) => new Priority(p.Value * count);
}

readonly ref struct RuckSack
{

    public RuckSack(ReadOnlySpan<Item> CompartmentA, ReadOnlySpan<Item> CompartmentB)
    {
        this.CompartmentA = CompartmentA;
        this.CompartmentB = CompartmentB;
    }

    public ReadOnlySpan<Item> CompartmentA { get; }
    public ReadOnlySpan<Item> CompartmentB { get; }

    public static RuckSack Parse(ref ReadOnlySpan<char> line)
    {
        var mid = line.Length / 2;
        var compartmentA = line.Slice(0, mid);
        var compartmentB = line.Slice(mid);

        // structs are fun!
        var a = MemoryMarshal.Cast<char, Item>(compartmentA);
        var b = MemoryMarshal.Cast<char, Item>(compartmentB);

        return new RuckSack(a, b);
    }
}
internal class Part1 : IChallenge<Priority>
{
    public string Description => "Find the sum of the priorities of the item types that appear in both compartments";

    public Priority Execute(TextInput input)
        => input.ParseLinesSpan((ref ReadOnlySpan<char> line) =>
        {
            var rucksack = RuckSack.Parse(ref line);

            var intersection = rucksack.CompartmentA.Intersect(rucksack.CompartmentB);
            // getting this to work in a hyper-linq manner requires a lot of code that 
            // the lib uses a generator for, so no .Select here
            // 196 KB
            var sum = default(Priority);
            foreach (var item in intersection)
                sum += Priority.From(item);

            return sum;

            //// 254 KB
            //var a = rucksack.CompartmentA.ToArray();
            //var b = rucksack.CompartmentB.ToArray();

            //return a.Intersect(b).Select(Priority.From).Sum();
        }).Sum();
}

internal class Part2 : IChallenge<Priority>
{
    public string Description => @"Find the one item that is common between all 3 elves.
Every 3 lines is a group.";

    public Priority Execute(TextInput input)
    {
        // 295 KB
        return input.ParseLinesEnumerable((SpanLineEnumerable enu) =>
            enu.Batch(3)
            .Select(g =>
            {
                IEnumerable<Item> itemIntersection = null;
                foreach (var group in g.Select(pair => pair.GetCharacters().Select(c => new Item(c))))
                {
                    if (itemIntersection == null)
                        itemIntersection = group;
                    else
                        itemIntersection = itemIntersection.Intersect(group);
                }
                return itemIntersection.Select(Priority.From).Sum();
            })
            .Sum());
    }
}
