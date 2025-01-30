using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to a file");
            Console.WriteLine("4. Load journal from a file");
            Console.WriteLine("5. Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your response:");
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    break;

                case "2":
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.WriteLine("Enter filename to save journal:");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.WriteLine("Enter filename to load journal:");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
