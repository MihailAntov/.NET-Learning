using System.Threading.Tasks;
using System.Collections.Generic;
using static System.Console;


static async IAsyncEnumerable<int> GetNumbers()
{
    var r = new Random();

    //simulate work
    System.Threading.Thread.Sleep(r.Next(1000, 2000));
    yield return r.Next(0, 101);

    System.Threading.Thread.Sleep(r.Next(1000, 2000));
    yield return r.Next(0, 101);

    System.Threading.Thread.Sleep(r.Next(1000, 2000));
    yield return r.Next(0, 101);
}


await foreach (int number in GetNumbers())
{
    WriteLine($"Number: {number}");
}

