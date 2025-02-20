using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    public List<Goal> Goals { get; private set; }
    public Gamification Gamification { get; private set; }

    public GoalManager()
    {
        Goals = new List<Goal>();
        Gamification = new Gamification();
    }

    public void AddGoal(string goalType, string name, string description, int points, int targetCount = 0, int bonusPoints = 0)
    {
        Goal newGoal = goalType switch
        {
            "SimpleGoal" => new SimpleGoal(name, description, points),
            "EternalGoal" => new EternalGoal(name, description, points),
            "ChecklistGoal" => new ChecklistGoal(name, description, targetCount, points, bonusPoints),
            _ => throw new ArgumentException("Invalid goal type")
        };

        Goals.Add(newGoal);
    }

    public void ViewGoals()
    {
        if (Goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            Console.WriteLine("Goals:");
            foreach (var goal in Goals)
            {
                goal.DisplayProgress();
            }
        }
    }

    public void RecordGoal(int goalIndex)
    {
        if (goalIndex < 0 || goalIndex >= Goals.Count)
        {
            Console.WriteLine("Invalid choice. Goal not recorded.");
            return;
        }

        Goals[goalIndex].RecordEvent();
        Gamification.AddPoints(Goals[goalIndex].Points);
        Console.WriteLine("Goal recorded.");
    }

    public void SaveProgress(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(Gamification.TotalPoints);
            writer.WriteLine(Gamification.Level);
            foreach (var achievement in Gamification.Achievements)
            {
                writer.WriteLine(achievement);
            }

            foreach (var goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Description}|{goal.Points}|{goal.IsComplete}");
                if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine(eternalGoal.TimesRecorded);
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.CurrentCount}|{checklistGoal.TargetCount}|{checklistGoal.BonusPoints}");
                }
            }
        }
        Console.WriteLine("Progress saved.");
    }

    public void LoadProgress(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved progress found.");
            return;
        }

        Goals.Clear();
        Gamification = new Gamification();

        using (StreamReader reader = new StreamReader(filename))
        {
            if (int.TryParse(reader.ReadLine(), out int totalPoints))
            {
                Gamification.AddPoints(totalPoints);
            }
            if (int.TryParse(reader.ReadLine(), out int level))
            {
                Gamification.Level = level;
            }

            Gamification.Achievements.Clear();
            string line;
            while ((line = reader.ReadLine()) != null && !line.Contains("|"))
            {
                Gamification.Achievements.Add(line);
            }

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 5) continue;

                string typeName = parts[0];
                string name = parts[1];
                string description = parts[2];
                if (!int.TryParse(parts[3], out int points)) continue;
                if (!bool.TryParse(parts[4], out bool isComplete)) continue;

                Goal goal = typeName switch
                {
                    "SimpleGoal" => new SimpleGoal(name, description, points),
                    "EternalGoal" => new EternalGoal(name, description, points),
                    "ChecklistGoal" => new ChecklistGoal(name, description, int.Parse(parts[5]), points, int.Parse(parts[6])),
                    _ => null
                };

                if (goal == null) continue;

                if (isComplete)
                {
                    goal.MarkComplete();
                }

                if (goal is EternalGoal eternalGoal && int.TryParse(reader.ReadLine(), out int timesRecorded))
                {
                    eternalGoal.TimesRecorded = timesRecorded;
                }
                else if (goal is ChecklistGoal checklistGoal && reader.ReadLine() is string checklistLine)
                {
                    string[] checklistParts = checklistLine.Split('|');
                    if (checklistParts.Length == 3 && int.TryParse(checklistParts[0], out int currentCount))
                    {
                        checklistGoal.CurrentCount = currentCount;
                    }
                }

                Goals.Add(goal);
            }
        }
        Console.WriteLine("Progress loaded.");
    }
}
