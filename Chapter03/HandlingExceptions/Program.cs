// See https://aka.ms/new-console-template for more information
using static System.Console;
using static System.Convert;
WriteLine("Before parsing");
Write("What is your age? ");
string? input = ReadLine();
try
{
    int age = int.Parse(input);
    WriteLine($"You are {age} years old.");
}
catch (OverflowException)
{
    WriteLine($"{input} is either too large or too small. Please enter a value between {int.MinValue} and {int.MaxValue}.");
}
catch (FormatException)
{
    WriteLine($"\"{input}\" is not a valid format for age.");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}
WriteLine("After parsing");
