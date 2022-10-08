using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

Random r = new Random();
string Message = "";// a shared resrouce
object conch = new object();
int Counter = 0;

void MethodA()
{
    try
    {
        Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(r.Next(2000));
            Message += "A";
            Interlocked.Increment(ref Counter);
            Write(".");
        }
    }
    finally
    {
        Monitor.Exit(conch);
    }
}

void MethodB()
{
    try 
    {
        Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(r.Next(2000));
            Message += "B";
            Interlocked.Increment(ref Counter);
            Write(".");
        }
    }
    finally
    {
        Monitor.Exit(conch);
    }
}

WriteLine("Please wait for the tasks to complete.");
Stopwatch watch = Stopwatch.StartNew();

Task a = Task.Factory.StartNew(MethodA);
Task b = Task.Factory.StartNew(MethodB);

Task.WaitAll(new Task[] { a, b });

WriteLine();
WriteLine($"Results: {Message}.");
WriteLine($"{watch.ElapsedMilliseconds:#,##0} ms elapsed.");
WriteLine($"{Counter} string modifications.");