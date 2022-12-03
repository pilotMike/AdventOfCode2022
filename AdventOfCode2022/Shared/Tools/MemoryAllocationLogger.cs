namespace AdventOfCode2022.Shared.Tools;

internal sealed class MemoryAllocationLogger : IDisposable
{
    private readonly long _totalMemory;

    public MemoryAllocationLogger()
    {
        _totalMemory = GC.GetTotalMemory(true);
        Console.WriteLine("Current Memory Usage: {0} bytes", _totalMemory.ToString("#,###"));
    }

    public void Dispose()
    {
        var final = GC.GetTotalMemory(false);
        var used = final - _totalMemory;
        Console.WriteLine("Final Memory Usage: {0} bytes", final.ToString("#,###"));
        Console.WriteLine("Total Memory Used: {0} bytes", used.ToString("#,###"));
    }
}
