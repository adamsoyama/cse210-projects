public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description)
    {
        if (points <= 0)
        {
            throw new ArgumentException("Points must be greater than zero.");
        }

        Points = points;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            Points = Points;
            IsComplete = true;
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"[ {(IsComplete ? 'X' : ' ')} ] {Name}: {Description} - Points: {Points}");
    }
}
