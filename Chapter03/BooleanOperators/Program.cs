// See https://aka.ms/new-console-template for more information
using static System.Console;
bool a = true;
bool b = false;

WriteLine($"AND     | {a}  | {b} ");
WriteLine($"{a,5}   | {a & a,-5} | {a & b,-5} ");
WriteLine($"{b,5}   | {b & a,-5} | {b & b,-5} ");
WriteLine();
WriteLine($"OR      | {a}  | {b} ");
WriteLine($"{a,5}   | {a | a,-5} | {a | b,-5} ");
WriteLine($"{b,5}   | {b | a,-5} | {b | b,-5} ");
WriteLine();
WriteLine($"XOR     | {a}  | {b} ");
WriteLine($"{a,5}   | {a ^ a,-5} | {a ^ b,-5} ");
WriteLine($"{b,5}   | {b ^ a,-5} | {b ^ b,-5} ");

static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
}

WriteLine($"a && DoStuff() = {a && DoStuff()}");
WriteLine($"b && DoStuff() = {b && DoStuff()}");


