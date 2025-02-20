public class EternalGoal : Goal
{
    public int TimesRecorded { get; set; }

    public EternalGoal(string name, string description, int pointsPerCompletion) : base(name, description)
    {
        if (pointsPerCompletion <= 0)
        {
            throw new ArgumentException("Points per completion must be greater than zero.");
        }

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
