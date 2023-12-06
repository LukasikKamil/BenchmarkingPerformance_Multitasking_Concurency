using System.Diagnostics; // Stopwatch

WriteLine("Please wait for the tasks to complete.");
Stopwatch stopwatch = Stopwatch.StartNew();
Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);
Task c = Task.Factory.StartNew(MethodC);

Task.WaitAll(new Task[] { a, b, c });
WriteLine();
WriteLine($"Result: {SharedObjects.Message}.");
WriteLine($"{stopwatch.ElapsedMilliseconds:N0} elapsed milliseconds.");

WriteLine($"{SharedObjects.Counter} string modifications.");