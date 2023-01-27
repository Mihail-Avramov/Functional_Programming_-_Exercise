using System;
using System.Collections.Generic;
using System.Linq;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

Func<List<int>, List<int>> reverseArrayFunc = numbers =>
{
    List<int> result = new List<int>();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        result.Add(numbers[i]);
    }

    return result;
};


Func<List<int>, Predicate<int>, List<int>> removeNumbersFunc = (numbers, match) =>
{
    List<int> result = new List<int>();

    foreach (var number in numbers)
    {
        if (match(number))
        {
            result.Add(number);
        }
    }

    return result;
};

Predicate<int> match = n => n % divider != 0;

numbers = removeNumbersFunc(numbers, match);

numbers = reverseArrayFunc(numbers);

Console.WriteLine(string.Join(" ", numbers));