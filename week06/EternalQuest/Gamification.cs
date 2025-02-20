using System;
using System.Collections.Generic;

public class Gamification
{
    public int TotalPoints { get; private set; }
    public int Level { get; set; }
    public List<string> Achievements { get; private set; }

    public Gamification()
    {
        TotalPoints = 0;
        Level = 1;
        Achievements = new List<string>();
    }

    public void AddPoints(int points)
    {
        TotalPoints += points;
        CheckLevelUp();
        CheckAchievements();
    }

    private void CheckLevelUp()
    {
        if (TotalPoints >= Level * 1000)
        {
            Level++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {Level}!");
        }
    }

    private void CheckAchievements()
    {
        if (TotalPoints >= 5000 && !Achievements.Contains("High Achiever"))
        {
            Achievements.Add("High Achiever");
            Console.WriteLine("Achievement Unlocked: High Achiever!");
        }

        if (TotalPoints >= 10000 && !Achievements.Contains("Goal Master"))
        {
            Achievements.Add("Goal Master");
            Console.WriteLine("Achievement Unlocked: Goal Master!");
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Total Points: {TotalPoints}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine("Achievements:");
        foreach (var achievement in Achievements)
        {
            Console.WriteLine($"- {achievement}");
        }
        int pointsToNextLevel = Level * 1000 - TotalPoints;
        Console.WriteLine($"Points to next level: {pointsToNextLevel}");
    }
}
