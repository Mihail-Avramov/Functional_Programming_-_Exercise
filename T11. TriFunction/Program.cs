using System;
using System.Linq;

int sum = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> checkStringSum = (name, sum) => name.Sum(ch => ch) >= sum;

Func<string[],int, Func<string, int, bool>, string> getFirstNameMatch = 
    (names, sum, match) => names.FirstOrDefault(name => match(name, sum));

Console.WriteLine(getFirstNameMatch(names, sum, checkStringSum));