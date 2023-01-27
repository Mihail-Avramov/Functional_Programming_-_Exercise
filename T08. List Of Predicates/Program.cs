using System;
using System.Collections.Generic;
using System.Linq;

int rangeLimiter = int.Parse(Console.ReadLine());

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Func<int, int[]> crateIntRangeArrayFunc = range =>
{
    int[] result = new int[range];
    for (int i = 1; i <= range; i++)
    {
        result[i-1] = i;
    }

    return result;
};

Func<HashSet<int>, List<Predicate<int>>> createPredicatesListFunc = dividers =>
{
    List<Predicate<int>> result = new List<Predicate<int>>();

    foreach (var divider in dividers)
    {
        result.Add(n => n % divider == 0);
    }
    return result;
};


Func<int[], List<Predicate<int>>, List<int>> createFilteredListFunc = (numbers, matches) =>
{
    List<int> result = new List<int>();

    foreach (var number in numbers)
    {
        bool isValidToAdd = true;

        foreach (var match in matches)
        {
            if (!match(number))
            {
                isValidToAdd = false;
                break;
            }
        }

        if (isValidToAdd)
        {
            result.Add(number);
        }
    }
    return result;
};


int[] numbers = crateIntRangeArrayFunc(rangeLimiter);

List<Predicate<int>> matches = createPredicatesListFunc(dividers);

List<int> numbersToPrint = createFilteredListFunc(numbers, matches);

Console.WriteLine(string.Join(" ", numbersToPrint));