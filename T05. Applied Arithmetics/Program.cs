using System;
using System.Linq;

int[] numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Func<string, int[], int[]> manipulator = (command, numbers) =>
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (command == "add")
        {
            numbers[i] += 1;
        }
        else if(command == "multiply")
        {
            numbers[i] *= 2;
        }
        else if (command == "subtract")
        {
            numbers[i] -= 1;
        }
    }

    return numbers;
};

string command = string.Empty;

while ((command = Console.ReadLine()) != "end")
{
    if (command == "print")
    {
        Console.WriteLine(string.Join(" ", numbers));
    }
    else
    {
        numbers = manipulator(command, numbers);
    }
}
