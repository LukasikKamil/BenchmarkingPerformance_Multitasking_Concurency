using System.Diagnostics; // Stopwatch

OutputThreadInfo();
Stopwatch stopwatch = Stopwatch.StartNew();

SectionTitle("Running methods synchronously on one thread.");
MethodA();
MethodB();
MethodC();

WriteLine($"{stopwatch.ElapsedMilliseconds:#,##0}ms elapsed.");

SectionTitle("Running methods asynchronously on multiple thread.");
stopwatch.Restart();

Task taskA = new(MethodA);
taskA.Start();
Task taskB = Task.Factory.StartNew(MethodB);
Task taskC = Task.Run(MethodC);

Task[] tasks = { taskA, taskB, taskC };
Task.WaitAll(tasks);

WriteLine($"{stopwatch.ElapsedMilliseconds:#:##0}ms elapsed.");

SectionTitle("Passing the result of one task as a input into another.");
stopwatch.Restart();

Task<string> taskServiceThenSProc = Task.Factory
    .StartNew(CallWebService) // returns Task<decimal>
    .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result)); // returns Task<string>

WriteLine($"Result: {taskServiceThenSProc.Result}");
WriteLine($"{stopwatch.ElapsedMilliseconds:#:##0}ms elapsed.");

SectionTitle("Nested and child tasks");

Task outerTask = Task.Factory.StartNew(OuterMethod);
outerTask.Wait();
WriteLine("Console app is stopping.");

