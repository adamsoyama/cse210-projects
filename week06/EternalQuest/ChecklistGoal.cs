public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, string description, int targetCount, int pointsPerCompletion, int bonusPoints) 
        : base(name, description)
    {
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
