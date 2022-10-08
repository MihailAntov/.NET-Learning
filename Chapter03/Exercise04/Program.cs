using static System.Console;
WriteLine("Enter a number between 0 and 255: ");
string input1 = ReadLine();
WriteLine("Enter another number between 0 and 255: ");
string input2 = ReadLine();
try
{
    byte firstNumber = byte.Parse(input1);
    byte secondNumber = byte.Parse(input2);
    WriteLine($"{firstNumber} divided by {secondNumber} is {firstNumber / secondNumber}.");
}
catch (FormatException)
{
    WriteLine("FormatException: Input string was not in a correct format.");
}
catch (OverflowException)
{
    WriteLine("OverflowException: One of the numbers was either too big or too small.");
}
catch (Exception e)
{
    WriteLine($"Error: {e.GetType()} says {e.Message}.");
}

int x = 3;
int y = 2 + ++x;

int x2 = 3 << 2;
int y2 = 10 >> 1;
WriteLine($"{x2} ; {y2}");
int x3 = 10 & 8;
int y3 = 10 | 7;
WriteLine($"{x3} ; {y3}");