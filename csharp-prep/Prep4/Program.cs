using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int userNumber;
        do {
            Console.Write("Enter a number: ");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);
            numbers.Add(userNumber);
        }while(userNumber != 0);
        int sum = 0;
        int largestNumber = 0;
        int count = numbers.Count();
        foreach(int number in numbers){
            sum += number;
            if(largestNumber < number){
                largestNumber = number;
            }
        }
        count -= 1;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine(count);
        int average = sum / count;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}