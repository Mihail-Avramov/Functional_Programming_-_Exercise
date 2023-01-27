using System;
using System.Collections.Generic;
using System.Linq;

int[] range = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

bool isEven = Console.ReadLine() == "even";

Func<int, int, List<int>> crateRangeListFunc = (num1, num2) =>
{
    List<int> result = new List<int>();

    for (int i = num1; i <= num2; i++)
    {
        result.Add(i);
    }

    return result;
};

List<int> numbers = crateRangeListFunc(range[0], range[1]);


Predicate<int> match;

if (isEven)
{
    match = number => number % 2 == 0;
}
else
{
    match = number => number % 2 != 0;
}


Console.WriteLine(string.Join(" ", numbers.Where(n => match(n))));