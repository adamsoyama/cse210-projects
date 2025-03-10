using System;

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / distance;
    }

    // Calorie burn calculation for running
    public override double GetCaloriesBurned()
    {
        return Minutes * 10; // Rough estimate: 10 calories per minute
    }
}
