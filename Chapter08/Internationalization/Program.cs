using System.Globalization;
using static System.Console;

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;

WriteLine($"The current globalization culture is {globalization.Name}: {globalization.DisplayName}.");
WriteLine($"The current localization culture is {localization.Name}:{localization.DisplayName}.");

WriteLine("en-US: English (United States)");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");
Write("Enter an ISO culture code: ");
string newCulture = ReadLine();
if (!string.IsNullOrEmpty(newCulture))
{
    var ci = new CultureInfo(newCulture);
    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;
}
WriteLine();

Write("Enter your name: ");
string name = ReadLine();
Write("Enter your date of birth: ");
string dob = ReadLine();
Write("Enter your salary: ");
string salary = ReadLine();

DateTime date = DateTime.Parse(dob);
int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
decimal earns = decimal.Parse(salary);

WriteLine($"{name} was born on a {date:dddd}, is {minutes:N0} minutes old, and earns {earns:C}.");