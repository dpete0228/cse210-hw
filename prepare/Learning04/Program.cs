using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("David Peters", "Division");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("David Peters", "Fractions", "9.3", "7-15");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("David Peters", "U.S. History", "The Revolutionary War");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}