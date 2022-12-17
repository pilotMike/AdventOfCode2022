using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Shared.Tools;
internal readonly struct StopwatchLogger : IDisposable
{
    private readonly long _time;

    public StopwatchLogger() => this._time = Stopwatch.GetTimestamp();

    public void Dispose()
    {
        Console.WriteLine(Stopwatch.GetElapsedTime(_time));
    }
}
