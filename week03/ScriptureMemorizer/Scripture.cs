using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        // Split the text into words and add to the list
        string[] textWords = text.Split(' ');
        foreach (string word in textWords)
        {
            words.Add(new Word(word));
        }
    }

    // Method to hide a few random words
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    // Method to return the scripture as a string
    public string GetScriptureString()
    {
        string result = reference.GetReferenceString() + "\n";
        foreach (Word word in words)
        {
            result += word.GetWordString() + " ";
        }
        return result.Trim();
    }

    // Method to check if all words are hidden
    public bool AreAllWordsHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
