// See https://aka.ms/new-console-template for more information
using static System.Console;
int x = 0;
while (x < 10)
{
    WriteLine(x);
    x++;
}
string? password = string.Empty;
int attemptCounter = 0;
do
{
    WriteLine($"{10 - attemptCounter} attempts remaining.");
    Write("Enter your password: ");
    password = ReadLine();
    attemptCounter++;
} while (password != "Pa$$w0rd" & attemptCounter < 10);
if(password == "Pa$$w0rd")
{
    WriteLine("Correct!");
}
else
{
    WriteLine("No more attempts. Access denied.");
}
for (int y = 1; y<=10; y++)
{
    WriteLine(y);
}

string [] names = {"Adam", "Barry", "John", "Charlie"};
foreach (string name in names)
{
    WriteLine($"{name} is on position {Array.IndexOf(names, name) +1}.");
}

