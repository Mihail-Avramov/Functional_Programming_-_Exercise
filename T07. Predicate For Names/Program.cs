using System;
using System.Collections.Generic;
using System.Linq;

int length = int.Parse(Console.ReadLine());

List<string> namesList = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Action<List<string>, Predicate<string>> printFilteredList = (names, match) =>
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