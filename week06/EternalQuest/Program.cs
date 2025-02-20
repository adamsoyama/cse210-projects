using System;

public class Program
{
    static GoalManager goalManager = new GoalManager();

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
                    goalManager.ViewGoals();
                    break;
                case "3":
                    goalManager.Gamification.DisplayStats();
                    break;
                case "4":
                    goalManager.SaveProgress("progress.txt");
                    break;
                case "5":
                    goalManager.LoadProgress("progress.txt");
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
                goalManager.AddGoal("SimpleGoal", name, description, simplePoints);
                break;
            case "2":
                Console.Write("Enter points per completion: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal("EternalGoal", name, description, eternalPoints);
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter points per completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goalManager.AddGoal("ChecklistGoal", name, description, checklistPoints, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal not added.");
                break;
        }
    }

    static void RecordGoal()
    {
        if (goalManager.Goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("Select goal to record:");
        for (int i = 0; i < goalManager.Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goalManager.Goals[i].Name}");
        }
        Console.Write("Choice: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        goalManager.RecordGoal(choice);
    }
}
