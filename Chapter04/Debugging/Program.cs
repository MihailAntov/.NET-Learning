// See https://aka.ms/new-console-template for more information
using static System.Console;

static double Add(double a, double b)
{
    return a + b; //deliberate bug!
}

{
    double a = 4.5;
    double b = 2.5;
    double answer = Add(a, b);
    WriteLine($"{a} + {b} = {answer}");
    ReadLine();
}

