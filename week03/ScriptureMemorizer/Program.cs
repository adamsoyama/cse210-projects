using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a scripture reference
        Reference reference = new Reference("John", 3, 16);

        // Create a scripture
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, scriptureText);

        // Main loop
        while (true)
        {
            // Clear the console and display the scripture
            Console.Clear();
            Console.WriteLine(scripture.GetScriptureString());

            // Prompt the user to press enter or type quit
            Console.WriteLine("Press Enter to continue or type 'quit' to end:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            // Hide a few random words
            scripture.HideRandomWords(3);

            // Check if all words are hidden
            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetScriptureString());
                Console.WriteLine("All words hidden. Program ended.");
                break;
            }
        }
    }
}
