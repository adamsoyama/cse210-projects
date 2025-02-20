using System;

public class Program
{
    static GoalManager goalManager = new GoalManager();

    public static void Main()
    {
        bool running = true;
        while (running)
        {
            try
            {
                DisplayMenu();
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
                        Console.WriteLine("Thank you for using the Eternal Quest Program! Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("          Eternal Quest Program     ");
        Console.WriteLine("====================================");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. View Goals");
        Console.WriteLine("3. Display Stats");
        Console.WriteLine("4. Save Progress");
        Console.WriteLine("5. Load Progress");
        Console.WriteLine("6. Record Goal");
        Console.WriteLine("7. Quit");
        Console.WriteLine("====================================");
        Console.Write("Select an option from the menu: ");
    }

    static void AddGoal()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("          Add New Goal              ");
            Console.WriteLine("====================================");
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("4. Time-Based Goal");
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
                    if (int.TryParse(Console.ReadLine(), out int simplePoints) && simplePoints > 0)
                    {
                        goalManager.AddGoal("SimpleGoal", name, description, simplePoints);
                        Console.WriteLine("Simple Goal added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid points. Goal not added.");
                    }
                    break;
                case "2":
                    Console.Write("Enter points per completion: ");
                    if (int.TryParse(Console.ReadLine(), out int eternalPoints) && eternalPoints > 0)
                    {
                        goalManager.AddGoal("EternalGoal", name, description, eternalPoints);
                        Console.WriteLine("Eternal Goal added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid points per completion. Goal not added.");
                    }
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    if (int.TryParse(Console.ReadLine(), out int targetCount) && targetCount > 0)
                    {
                        Console.Write("Enter points per completion: ");
                        if (int.TryParse(Console.ReadLine(), out int checklistPoints) && checklistPoints > 0)
                        {
                            Console.Write("Enter bonus points: ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints) && bonusPoints >= 0)
                            {
                                goalManager.AddGoal("ChecklistGoal", name, description, checklistPoints, targetCount, bonusPoints);
                                Console.WriteLine("Checklist Goal added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid bonus points. Goal not added.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid points per completion. Goal not added.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid target count. Goal not added.");
                    }
                    break;
                case "4":
                    Console.Write("Enter points: ");
                    if (int.TryParse(Console.ReadLine(), out int timeBasedPoints) && timeBasedPoints > 0)
                    {
                        Console.Write("Enter deadline (yyyy-MM-dd HH:mm:ss): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime deadline) && deadline > DateTime.Now)
                        {
                            goalManager.AddGoal("TimeBasedGoal", name, description, timeBasedPoints, deadline: deadline);
                            Console.WriteLine("Time-Based Goal added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid deadline. Goal not added.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid points. Goal not added.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Goal not added.");
                    break;
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the goal: {ex.Message}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    static void RecordGoal()
    {
        try
        {
            Console.Clear();
            if (goalManager.Goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("====================================");
            Console.WriteLine("          Record Goal               ");
            Console.WriteLine("====================================");
            Console.WriteLine("Select goal to record:");
            for (int i = 0; i < goalManager.Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {goalManager.Goals[i].Name}");
            }
            Console.Write("Choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= goalManager.Goals.Count)
            {
                goalManager.RecordGoal(choice - 1);
                Console.WriteLine("Goal recorded successfully!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Goal not recorded.");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while recording the goal: {ex.Message}");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
