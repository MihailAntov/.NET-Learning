// See https://aka.ms/new-console-template for more information
using static System.Console;
using System.IO;

if (args.Length == 0)
{
    WriteLine("There are no arguments.");
}
else
{
    WriteLine("There is at least one argument.");
}
object o = -5;
int j = 4;
if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}
A_label: 
    var number = (new Random ()).Next(1, 7);
    WriteLine($"My random number is {number}");
    switch (number)
    {
        case 1:
            WriteLine("One");
            break;
        case 2:
            WriteLine("Two");
            goto case 1;
        case 3:
        case 4:
            WriteLine("Three or four");
            goto case 1;
        case 5:
            //sleep for half a second
            System.Threading.Thread.Sleep(500);
            goto A_label;  
        default:
            WriteLine("Default");
            break;              
}
// string path = "/Users/markjprice/Code/Chapter03";
string path = @"D:\.Net Core Projects\Code\Chapter03";
Stream s = File.Open(
    Path.Combine(path, "file.txt"), FileMode.OpenOrCreate);

string message = string.Empty;
message = s switch 
{
    FileStream writeableFile when s.CanWrite
        => "The stream is a file that I can write to.",
    FileStream readOnlyFile
        => "The stream is a read-only file.",
    MemoryStream ms
        => "The stream is a memory address.",
    null
        => "The stream is null.",
    _
        => "The stream is some other type.",                
};
WriteLine(message);    