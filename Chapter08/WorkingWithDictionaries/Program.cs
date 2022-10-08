using static System.Console;
using System.Collections.Generic;

var keywords = new SortedDictionary<string, string>();
keywords.Add("int", "32-bit integer data type");
keywords.Add("long", "64-bit integer data type");
keywords.Add("float", "SIngle precision floating point number");
WriteLine("Keywords and their definitions:");
foreach(KeyValuePair<string, string> item in keywords)
{
    WriteLine($"    {item.Key}: {item.Value}");
}
WriteLine($"The definition of long is {keywords["long"]}");
keywords.Add("integer", keywords["int"]);
foreach(KeyValuePair<string, string> item in keywords)
{
    WriteLine($"    {item.Key}: {item.Value}");
}
var keywordsList = new SortedList<string, string>();
keywordsList.Add("int", "32-bit integer data type");
keywordsList.Add("long", "64-bit integer data type");
keywordsList.Add("float", "SIngle precision floating point number");
foreach(KeyValuePair<string, string> item in keywordsList)
{
    WriteLine($"    {item.Key}: {item.Value}");
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