using System.Diagnostics; // Stopwatch

using static System.Diagnostics.Process; //GetCurrentProcess()

namespace ALLinONE.Shered; 

public static class Recorder
{
    private static Stopwatch stopwatch = new();

    private static long bytesPhisicalBefore = 0;
    private static long bytesVirtualBefore = 0;

    public static void Start()
    {
        // force some garbage collections to release memory that is no longer referenced but has been released yed
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        // store the current phisical and virtual memory use
        bytesPhisicalBefore = GetCurrentProcess().WorkingSet64;
        bytesVirtualBefore = GetCurrentProcess().VirtualMemorySize64;

        stopwatch.Restart();
    }

    public static void Stop()
    {
        stopwatch.Stop();

        long bytesPhisicalAfter = GetCurrentProcess().WorkingSet64;

        long bytesVirtualAfter = GetCurrentProcess().VirtualMemorySize64;

        WriteLine("{0:N0} phisical bytes used.", bytesPhisicalAfter - bytesPhisicalBefore);

        WriteLine("{0:N0} virtual bytes used.", bytesVirtualAfter - bytesVirtualBefore);

        WriteLine("{0} time span elapsed.", stopwatch.Elapsed);

        WriteLine("{0:N0} total miliseconds elapsed.", stopwatch.ElapsedMilliseconds);
    }
}
