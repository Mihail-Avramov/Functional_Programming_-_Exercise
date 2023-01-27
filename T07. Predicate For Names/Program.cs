using System;
using System.Linq;

int length = int.Parse(Console.ReadLine());

string[] namesList = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToArray();

Action<string[], Predicate<string>> printFilteredList = (names, match) =>
{
    foreach (var name in names)
    {
        if (match(name))
        {
            Console.WriteLine(name);
        }
    }
};

Predicate<string> match = s => s.Length <= length;

printFilteredList(namesList,match);