using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();
        int number;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Loop to get numbers from the user
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }

        } while (number != 0);

        // Calculate the sum
        int sum = numbers.Sum();
        Console.WriteLine("The sum is: " + sum);

        // Calculate the average
        double average = numbers.Average();
        Console.WriteLine("The average is: " + average);

        // Find the maximum number
        int max = numbers.Max();
        Console.WriteLine("The largest number is: " + max);

        // Stretch Challenge: Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine("The smallest positive number is: " + smallestPositive);

        // Stretch Challenge: Sort the numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}