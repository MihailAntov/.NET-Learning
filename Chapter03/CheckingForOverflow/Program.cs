// See https://aka.ms/new-console-template for more information
using static System.Console;
using static System.Convert;

try
{
checked
{
int x = int.MaxValue - 1;
WriteLine($"Initial value: {x}");
x++;
WriteLine($"After incrementing: {x}");
x++;
WriteLine($"After incrementing: {x}");
x++;
WriteLine($"After incrementing: {x}");
}
}
catch (OverflowException)
{
    WriteLine("The code overflowed but I caught the exception.");
}
unchecked
{
    int y = int.MaxValue + 1;
    WriteLine($"Initial value: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
    y--;
    WriteLine($"After decrementing: {y}");
}
double l = 39.4;
double z = l / 0;
WriteLine(z);
for ( ; true; ) ;