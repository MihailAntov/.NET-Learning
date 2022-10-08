// See https://aka.ms/new-console-template for more information
using static System.Console;
using static System.Convert;
bool sure = false;
do
{
    WriteLine("Running this will cause an infinite loop. Are you sure you wish to continue? y/n");
    ConsoleKeyInfo input = ReadKey();
    WriteLine();
    switch (input.KeyChar)
    {
        case ('y'):
        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            WriteLine(i);
        }
        break;
        case 'n':
        WriteLine("Smart choice. Exiting.");
        sure = true;
        break;
        default:
        WriteLine("Invalid input. Please try again.");
        break;
    }

} while (sure == false);