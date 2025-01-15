using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("Enter your score? ");
        string scoreFromUser = Console.ReadLine();
        int score = int.Parse(scoreFromUser);

        string letter = "";

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = score % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else
        {
            sign = "-";
        }

        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }
        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (score >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you failed. Try again next time!");
        }
    }
}