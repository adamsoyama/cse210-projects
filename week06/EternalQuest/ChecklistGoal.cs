public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int targetCount, int pointsPerCompletion, int bonusPoints) 
        : base(name, description)
    {
        if (targetCount <= 0)
        {
            throw new ArgumentException("Target count must be greater than zero.");
        }

        if (pointsPerCompletion <= 0)
        {
            throw new ArgumentException("Points per completion must be greater than zero.");
        }

        if (bonusPoints < 0)
        {
            throw new ArgumentException("Bonus points cannot be negative.");
        }

        TargetCount = targetCount;
        Points = pointsPerCompletion;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            Points = Points;
            if (CurrentCount == TargetCount)
            {
                Points += BonusPoints;
                IsComplete = true;
            }
        }
    }

    public override void DisplayProgress()
    {
        Console.WriteLine($"[ {(IsComplete ? 'X' : ' ')} ] {Name}: {Description} - Completed {CurrentCount}/{TargetCount} times - Points per completion: {Points}, Bonus: {BonusPoints}");
    }
}
