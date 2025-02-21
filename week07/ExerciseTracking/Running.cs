using System;

public abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public int Minutes
    {
        get { return minutes; }
    }

    // Method to calculate calories burned (This will be overridden in derived classes)
    public abstract double GetCaloriesBurned();

    // Existing abstract methods
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {GetType().Name} ({minutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile, Calories: {GetCaloriesBurned():0} kcal";
    }
}
