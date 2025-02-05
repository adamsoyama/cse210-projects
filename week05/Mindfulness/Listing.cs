using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private static readonly List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

    // Constructor
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Method to start the listing activity
    public void StartListing()
    {
        StartActivity();

        Random random = new Random();
        int duration = GetDuration();

        // Select a random prompt
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        DisplayCountdown(5); // Pause for 5 seconds

        int elapsedTime = 0;
        int itemCount = 0;

        Console.WriteLine("Start listing items...");

        while (elapsedTime < duration)
        {
            string item = Console.ReadLine();
            itemCount++;
            elapsedTime += 5;
        }

        Console.WriteLine($"You listed {itemCount} items.");

        EndActivity();
    }
}
