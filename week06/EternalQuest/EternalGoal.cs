public class EternalGoal : Goal
{
    public int TimesRecorded { get; set; }  // Changed to public set accessor

    public EternalGoal(string name, string description, int pointsPerCompletion) : base(name, description)
    {
        Points = pointsPerCompletion;
        TimesRecorded = 0;
    }

    public override void RecordEvent()
    {
        TimesRecorded++;
        Points += Points;
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"[ ∞ ] {Name}: {Description} - Points per completion: {Points}");
    }
}
