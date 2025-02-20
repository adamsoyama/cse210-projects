using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    static List<Goal> goals = new List<Goal>();
    static Gamification gamification = new Gamification();

    public static void Main()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. View Goals");
            Console.WriteLine("3. Display Stats");
            Console.WriteLine("4. Save Progress");
            Console.WriteLine("5. Load Progress");
            Console.WriteLine("6. Record Goal");
            Console.WriteLine("7. Quit");
            Console.WriteLine("Select an option from the menu:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddGoal();
                    break;
                case "2":
                    ViewGoals();
                    break;
                case "3":
                    gamification.DisplayStats();
                    break;
                case "4":
                    SaveProgress();
                    break;
                case "5":
                    LoadProgress();
                    break;
                case "6":
                    RecordGoal();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter points: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, description, simplePoints));
                break;
            case "2":
                Console.Write("Enter points per completion: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, description, eternalPoints));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter points per completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, targetCount, checklistPoints, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
    }

    static void ViewGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            Console.WriteLine("Goals:");
            foreach (var goal in goals)
            {
                goal.DisplayProgress();
            }
        }
    }

    static void RecordGoal()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("Select goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        Console.Write("Choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            goals[choice].RecordEvent();
            gamification.AddPoints(goals[choice].Points);
            Console.WriteLine("Goal recorded.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal not recorded.");
        }
    }

    static void SaveProgress()
    {
        using (StreamWriter writer = new StreamWriter("progress.txt"))
        {
            writer.WriteLine(gamification.TotalPoints);
            writer.WriteLine(gamification.Level);
            foreach (var achievement in gamification.Achievements)
            {
                writer.WriteLine(achievement);
            }

            foreach (var goal in goals)
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


    static void LoadProgress()
    {
        if (!File.Exists("progress.txt"))
        {
            Console.WriteLine("No saved progress found.");
            return;
        }

        goals.Clear();
        gamification = new Gamification();

        using (StreamReader reader = new StreamReader("progress.txt"))
        {
            // Read total points and level
            if (int.TryParse(reader.ReadLine(), out int totalPoints))
            {
                gamification.AddPoints(totalPoints);
            }
            if (int.TryParse(reader.ReadLine(), out int level))
            {
                gamification.Level = level;
            }

            // Read achievements
            gamification.Achievements.Clear();
            string line;
            while ((line = reader.ReadLine()) != null && !line.Contains("|"))
            {
                gamification.Achievements.Add(line);
            }

            // Read goals
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    if (line == null || !line.Contains("|")) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length < 5)
                    {
                        Console.WriteLine($"Skipping invalid line: {line}");
                        continue;
                    }

                    string typeName = parts[0];
                    string name = parts[1];
                    string description = parts[2];
                    if (!int.TryParse(parts[3], out int points))
                    {
                        Console.WriteLine($"Invalid points value: {parts[3]}");
                        continue;
                    }
                    if (!bool.TryParse(parts[4], out bool isComplete))
                    {
                        Console.WriteLine($"Invalid completion status: {parts[4]}");
                        continue;
                    }

                    Goal goal = typeName switch
                    {
                        "SimpleGoal" => new SimpleGoal(name, description, points),
                        "EternalGoal" => new EternalGoal(name, description, points),
                        "ChecklistGoal" => new ChecklistGoal(name, description, int.Parse(parts[5]), points, int.Parse(parts[6])),
                        _ => null
                    };

                    if (goal == null)
                    {
                        Console.WriteLine($"Unknown goal type: {typeName}");
                        continue;
                    }

                    if (isComplete)
                    {
                        goal.MarkComplete();
                    }

                    // Read additional properties for specific goal types
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

                    goals.Add(goal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing line: {line}. Exception: {ex.Message}");
                }
            }
        }
        Console.WriteLine("Progress loaded.");
    }
}
