using System;
using System.Threading;
public class Activity
{
    private string name;
    private string description;
    private int duration;

    // Constructor
    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    // Method to start the activity
    public void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity.");
        Console.WriteLine(description);
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        DisplayCountdown(3); // Pause for 3 seconds before starting
    }

    // Method to end the activity
    public void EndActivity()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"Activity: {name}, Duration: {duration} seconds.");
        DisplayCountdown(3); // Pause for 3 seconds before ending
    }

    // Method to display a countdown
    public void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    //Method to get the duration of the activity
    public int GetDuration()
    {
        return duration;
    }
}