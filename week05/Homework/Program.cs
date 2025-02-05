using System;

class Program
{
    static void Main(string[] args)
    {

        // Create a simple assignment
        Assignment assignment = new Assignment("Kenneth Egumi", "Multiplication");

        // Call the GetSummary method and display the output
        Console.WriteLine(assignment.GetSummary());

        // Create a MathAssignment object and set its values
        MathAssignment mathAssignment = new MathAssignment("Adams Oyama", "Fractions", "7.3", "8-19");

        // Test GetSummary and GetHomeworkList methods
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());


        // Create a WritingAssignment object and set its values
        WritingAssignment writingAssignment = new WritingAssignment("Ekanachita Oyama", "European History", "The Causes of World War II");

        // Test GetSummary and GetWritingInformation methods
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}