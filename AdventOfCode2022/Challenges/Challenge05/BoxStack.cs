namespace AdventOfCode2022.Challenges.Challenge05;

class BoxStack
{
    private Stack<char> Boxes { get; } = new();

    public void Add(char box)
    {
        if (char.IsWhiteSpace(box)) return;
        Boxes.Push(box);
    }

    public char Peek() => Boxes.Peek();
    public char Pop() => Boxes.Pop();

    public BoxStack Reverse()
    {
        var b = new BoxStack();
        foreach (var box in Boxes)
        {
            b.Add(box);
        }
        return b;
    }
}
