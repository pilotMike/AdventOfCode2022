namespace AdventOfCode2022.Challenges.Challenge05;

class BoxContainer
{
    private readonly List<BoxStack> boxStacks = new();
    public string TopCrates => string.Join("", boxStacks.Select(s => s.Peek()));

    public BoxStack GetStackById(BoxStackID boxStackID)
    {
        var index = Index(boxStackID);
        EnsureCapacity(index);
        return boxStacks[index];
    }

    public BoxContainer Reverse()
    {
        var container = new BoxContainer();
        foreach (var stack in this.boxStacks)
        {
            var newStack = stack.Reverse();
            container.boxStacks.Add(newStack);
        }
        return container;
    }

    static int Index(BoxStackID boxStack) => boxStack.Value - 1;

    void EnsureCapacity(int i)
    {
        var remainder = i - boxStacks.Count + 1;
        if (remainder > 0)
        {
            for (int j = 0; j < remainder; j++)
            {
                boxStacks.Add(new BoxStack());
            }
        }
    }

}
