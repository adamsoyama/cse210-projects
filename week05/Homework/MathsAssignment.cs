using System;
public class MathAssignment : Assignment
{
    private string textbookSection;
    private string problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        this.textbookSection = textbookSection;
        this.problems = problems;
    }

    // Method to get homework list
    public string GetHomeworkList()
    {
        return $"Section {textbookSection} Problems {problems}";
    }
}