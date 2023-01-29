using System;
using System.Collections.Generic;
using System.Linq;

List<string> paryGuests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input = string.Empty;

Func<string, string, Predicate<string>> createPredicateFunc = (filterType, value) =>
{
    switch (filterType)
    {
        case "StartsWith":
            return n => n.StartsWith(value);
        case "EndsWith":
            return n => n.EndsWith(value);
        case "Length":
            return n => n.Length == int.Parse(value);
        default:
            return default;
    }
};

while ((input = Console.ReadLine()) != "Party!")
{
    string[] commandArguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string command = commandArguments[0];
    string filterType = commandArguments[1];
    string value = commandArguments[2];

    if (command == "Remove")
    {
        paryGuests.RemoveAll(createPredicateFunc(filterType, value));
    }
    else
    {
        foreach (var guest in paryGuests.FindAll(createPredicateFunc(filterType,value)))
        {
            int index = paryGuests.IndexOf(guest);
            paryGuests.Insert(index, guest);
        }
    }
}

if (paryGuests.Any())
{
    Console.WriteLine($"{string.Join(", ", paryGuests)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}