using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        int sum = 0;
        List<int> numbers = new List<int>();
        while (!(number == 0)) {
            Console.WriteLine("Enter number: ");
            string response = Console.ReadLine();
            number = int.Parse(response);
            if (!(number == 0)) {
                numbers.Add(number);
            }
        }
        for (int i = 0; i<numbers.Count; i++)
        sum += numbers[i];
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int high = numbers.Max();
        Console.WriteLine($"The largest number is: {high}");
    }
}