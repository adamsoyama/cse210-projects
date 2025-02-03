using System;

public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = verse;
        this.endVerse = verse;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }

    // Method to return the reference as a string
    public string GetReferenceString()
    {
        if (startVerse == endVerse)
        {
           string text = $"{book} {chapter}:{startVerse}";
            return text;
        }
        else
        {
            string text =  $"{book} {chapter}:{startVerse}-{endVerse}";
            return text;
        }
    }
}
