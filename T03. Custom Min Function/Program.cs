
using System;
using System.Collections.Generic;
using System.Linq;

HashSet<int> numbersSet = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(n => int.Parse(n))
        .ToHashSet();

Func<HashSet<int>, int> returnMinNumber = numbers => numbers.Min();


Console.WriteLine(returnMinNumber(numbersSet));