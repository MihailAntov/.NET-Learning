// See https://aka.ms/new-console-template for more information


#nullable disable
using static System.Console;
Write("Press any key combination:");
ConsoleKeyInfo key = ReadKey();
WriteLine();
WriteLine($"You pressed {key.Key}.");
WriteLine($"The symbol you meant to enter was {key.KeyChar}.");
if (key.Modifiers == 0)
{
    WriteLine("You were not holding down anything.");
}
else
{
    WriteLine($"You were holding down {key.Modifiers}.");
}



