namespace AdventOfCode2022.Shared.Tools
{
    internal class MemoryAllocationLogger : IDisposable
    {
        private long _totalMemory;

        public MemoryAllocationLogger() 
        {
            _totalMemory = GC.GetTotalMemory(true);    
        }
        public void Dispose()
        {
            _totalMemory= GC.GetTotalMemory(false);
            Console.WriteLine("Total Memory Used: {0} bytes", _totalMemory.ToString("#,###"));
        }
    }
}
