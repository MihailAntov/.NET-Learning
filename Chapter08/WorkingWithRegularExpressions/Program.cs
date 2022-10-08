using static System.Console;
using System.Text.RegularExpressions;
Write("Enter your age: ");
string input = ReadLine();
var ageChecked = new Regex(@"^\d+$");
if (ageChecked.IsMatch(input))
{
    WriteLine("Thank you!");
}
else
{
    WriteLine($"\"{input}\" is not a valid age.");
}
Write("Enter your cat's name:");
input = ReadLine().ToLower();
var catChecked = new Regex(@"^chocho$");
if (catChecked.IsMatch(input))
{
    WriteLine("Yes! He's cute. Press any key to exit.");
}
else
{
    WriteLine("Wrong cat name. Press any key to continue.");
}
string films = "\"Monsters, INC.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";
string[] filmsDumb = films.Split(',');
WriteLine("Dumb attempt at splitting:");
foreach(string film in filmsDumb)
{
    WriteLine(film);
}
var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
MatchCollection filmSmart = csv.Matches(films);
WriteLine("Smart attempt at splitting:");
foreach (Match film in filmSmart)
{
    WriteLine(film.Groups[2].Value);
}

//270 working with lists
