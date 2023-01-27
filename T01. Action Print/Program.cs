using System;

Action<string[]> printNames = names => Console.WriteLine(string.Join(Environment.NewLine, names));

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

printNames(names);