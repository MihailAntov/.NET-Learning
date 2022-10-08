using static System.Console;
using System.Collections.Generic;
using System.Collections.Immutable;
var cities = new List<string>();
cities.Add("London");
cities.Add("Paris");
cities.Add("Milan");
WriteLine("Initial list:");
foreach(string city in cities)
{
    WriteLine($"    {city}");
}
WriteLine($"The first city is {cities[0]}.");
WriteLine($"The last city is {cities[cities.Count -1]}.");

cities.Insert(0, "Sydney");
WriteLine("After including Sydney at index 0:");
foreach(string city in cities)
{
    WriteLine($"    {city}");
}
cities.RemoveAt(1);
cities.Remove("Milan");
WriteLine("After removing two cities:");
foreach(string city in cities)
{
    WriteLine($"    {city}");
}
var immutableCities = cities.ToImmutableList();
var newList = immutableCities.Add("Rio");
Write("Immutable list of cities:");
foreach (string city in immutableCities)
{
    Write($"   {city}");
}
WriteLine();
Write("New list of cities:");
foreach (string city in newList)
{
    Write($"   {city}");
}
WriteLine();
WriteLine($"Last city in new list: {newList[^1]}");
WriteLine($"Number of cities in new list: {newList.Count}");
WriteLine($"First city in new list: {newList[^newList.Count]}");
Index firstCity = 0;
WriteLine($"First city in the new list is {newList[firstCity]}");