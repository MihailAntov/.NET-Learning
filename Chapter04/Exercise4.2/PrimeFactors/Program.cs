// See https://aka.ms/new-console-template for more information
using Packt;
using System;
using static System.Console;
bool done = false;
while(done == false)
{
    WriteLine("This program calculates prime factors.");
    WriteLine();
    WriteLine("Please enter a number between 1 and 1000.");
    try
    {
        int input = Convert.ToInt32(ReadLine());
        var operation = new PrimeOperations();
        WriteLine($"The prime factors of {input} are {operation.PrimeFactors(input)}.");
        WriteLine("Press enter to exit.");
        ReadLine();
        done = true;
    }
    catch
    {
        WriteLine("Invalid input. Please try again.");
    }

}

