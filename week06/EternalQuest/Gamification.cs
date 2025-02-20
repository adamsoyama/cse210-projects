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
        if (points <= 0)
        {
            throw new ArgumentException("Points to add must be greater than zero.");
        }

        TotalPoints += points;
        CheckLevelUp();
        CheckAchievements();
    }

    private void CheckLevelUp()
    {
        while (TotalPoints >= Level * 1000)
        {
            Level++;
            Console.WriteLine($"Congratulations! You've leveled up to Level {Level}!");
        }
    }

    private void CheckAchievements()
    {
        var achievementUnlocks = new Dictionary<int, string>
        {
            { 1000, "Rookie" },
            { 5000, "High Achiever" },
            { 10000, "Goal Master" },
            { 20000, "Champion" },
            { 50000, "Legend" }
        };

        foreach (var achievement in achievementUnlocks)
        {
            if (TotalPoints >= achievement.Key && !Achievements.Contains(achievement.Value))
            {
                Achievements.Add(achievement.Value);
                Console.WriteLine($"Achievement Unlocked: {achievement.Value}!");
            }
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
