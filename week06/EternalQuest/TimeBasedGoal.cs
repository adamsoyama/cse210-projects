public class TimeBasedGoal : Goal
{
    public DateTime Deadline { get; private set; }

    public TimeBasedGoal(string name, string description, int points, DateTime deadline) : base(name, description)
    {
        if (points <= 0)
        {
            throw new ArgumentException("Points must be greater than zero.");
        }

        if (deadline <= DateTime.Now)
        {
            throw new ArgumentException("Deadline must be in the future.");
        }

        Points = points;
        Deadline = deadline;
    }

    public override void RecordEvent()
    {
        if (!IsComplete && DateTime.Now <= Deadline)
        {
            Points = Points;
            IsComplete = true;
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"[ {(IsComplete ? 'X' : ' ')} ] {Name}: {Description} - Points: {Points} - Deadline: {Deadline}");
    }
}
