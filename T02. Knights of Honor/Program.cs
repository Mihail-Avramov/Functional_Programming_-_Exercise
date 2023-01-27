using System;

Action<string, string[]> printNames = (title, names) =>
{
    foreach (var name in names)
    {
        Console.WriteLine($"{title} {name}");
    }
};

string addTitle = "Sir";

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printNames(addTitle, names);