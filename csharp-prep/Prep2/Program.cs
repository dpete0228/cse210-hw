using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to my letter grade calculator");
        Console.Write("Please enter the percentage that you received (Without the % sign): ");
        string userInput = Console.ReadLine();
        int percentGrade = int.Parse(userInput);
        string letterGrade = "";
        if (percentGrade >= 90){
            letterGrade = "A";
        }else if (percentGrade >= 80){
            letterGrade = "B";
        }else if (percentGrade >= 70){
            letterGrade = "C";
        }else if (percentGrade >= 60){
            letterGrade = "D";
        }else if (percentGrade < 60){
            letterGrade = "F";
        }
        Console.WriteLine($"You got a(n) {letterGrade} in the class");

    }
}