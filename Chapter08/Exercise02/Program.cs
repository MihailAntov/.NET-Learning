using System.Text.RegularExpressions;
using static System.Console;
using Exercise03;
//WriteLine("The default regular expression checks for at least one digit.");
bool done = false;
var regexComparer = new Regex(@"\d+");
int number = 55;
while (done == false)
{
    WriteLine("Enter a number:");
    string input = ReadLine();
    try
    {
        number = int.Parse(input);
    }
    catch
    {
        WriteLine("Invalid number.");
    }
    WriteLine(intExtensions.ToWords(number));

    //Clear();
   // Write("Enter a regular expression (or press ENTER to use the default): ");
    //string regExInput = ReadLine();
    //if (!string.IsNullOrEmpty(regExInput))
    //{
   //     regexComparer = new Regex($@"{regExInput}");
    //}
   // else
   // {
    //    regexComparer = new Regex(@"\d+");
    //}
   // Write("Enter some input: ");
   //string input = ReadLine();
   // WriteLine($"{input} matches {regexComparer}: {regexComparer.IsMatch(input)}");
    WriteLine("Press escape to quit or any key to try again.");
    var loopInput = ReadKey();
    if (loopInput.Key == ConsoleKey.Escape)
    {
        done = true;
    }
}
