using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries { get; set; }
    private List<Prompt> prompts;

    public Journal()
    {
        Entries = new List<Entry>();
        prompts = new List<Prompt>
        {
            new Prompt("Who was the most interesting person I interacted with today?"),
            new Prompt("What was the best part of my day?"),
            new Prompt("How did I see the hand of the Lord in my life today?"),
            new Prompt("What was the strongest emotion I felt today?"),
            new Prompt("If I had one thing I could do over today, what would it be?")
        };
    }

    public void AddEntry(string response)
    {
        var random = new Random();
        var selectedPrompt = prompts[random.Next(prompts.Count)];
        var date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(selectedPrompt.Text, response, date);
        Entries.Add(newEntry);
        Console.WriteLine("Entry added successfully.");
    }

    public void DisplayJournal()
    {
        foreach (var entry in Entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            Entries.Clear();  // Clear current entries
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Entries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
