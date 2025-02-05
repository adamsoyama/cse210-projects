using System;
public class Assignment
{
    private string studentName;
    private string topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        this.studentName = studentName;
        this.topic = topic;
    }

    // Method to get summary
    public string GetSummary()
    {
        return $"{studentName} - {topic}";
    }
}