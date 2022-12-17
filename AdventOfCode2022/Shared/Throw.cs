namespace AdventOfCode2022.Shared;
internal static class Throw
{
    public static NotSupportedException NotSupportedException() => throw new NotSupportedException();
    public static void ArgumentOutOfRangeException(string name, string message) => throw new ArgumentOutOfRangeException(name, message);
}
