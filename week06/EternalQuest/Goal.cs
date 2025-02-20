public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, string description)
    {
        Name = name;
        Description = description;
        Points = 0;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract void DisplayProgress();

    public void MarkComplete()
    {
        IsComplete = true;
    }
}
