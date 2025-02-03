using System;

public class Word
{
    private string text;
    private bool isHidden;

    // Constructor
    public Word(string text)
    {
        this.text = text;
        this.isHidden = false;
    }

    // Method to hide the word
    public void Hide()
    {
        isHidden = true;
    }

    // Method to check if the word is hidden
    public bool IsHidden()
    {
        return isHidden;
    }

    // Method to return the word as a string (hidden or visible)
    public string GetWordString()
    {
        if (isHidden)
        {
            return new string('_', text.Length);
        }
        else
        {
            return text;
        }
    }
}
