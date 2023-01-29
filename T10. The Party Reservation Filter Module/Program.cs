using System;
using System.Collections.Generic;
using System.Linq;

List<string> guestNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> predicateSet = new Dictionary<string, Predicate<string>>();

Func<string, string, Predicate<string>> createPredicateFunc = (filterType, value) =>
{
    switch (filterType)
    {
        case "Starts with":
            return n => n.StartsWith(value);
        case "Ends with":
            return n => n.EndsWith(value);
        case "Length":
            return n => n.Length == int.Parse(value);
        case "Contains":
            return n => n.Contains(value);
        default:
            return default;
    }
};

string input = string.Empty;

while ((input = Console.ReadLine()) != "Print")
{
    string[] commandArguments = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

    string command = commandArguments[0];
    string filterType = commandArguments[1];
    string value = commandArguments[2];

    if (command == "Add filter")
    {
        predicateSet.Add(filterType+value, createPredicateFunc(filterType, value));
    }
    else
    {
        predicateSet.Remove(filterType+value);
    }
}

foreach (var match in predicateSet)
{
    guestNames.RemoveAll(match.Value);
}

Console.WriteLine(string.Join(" ", guestNames));