using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void StartBreathing()
    {
        StartActivity();

        int seconds = GetDuration();
        for (int i = 0; i < seconds / 6; i++)
        {
            AnimateBreathing("Breathe in...", 3);
            AnimateBreathing("Breathe out...", 3);
        }

        EndActivity();
        Log.LogActivity("Breathing Activity", seconds);
    }

    private void AnimateBreathing(string message, int duration)
    {
        Console.WriteLine(message);
        for (int i = 1; i <= duration * 10; i++)
        {
            Console.Write("#");
            Thread.Sleep((int)(1000 / (Math.Log(i + 1) + 1)));
        }
        Console.WriteLine();
    }
}