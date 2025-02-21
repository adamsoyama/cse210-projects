using System;

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    // Calorie burn calculation for cycling
    public override double GetCaloriesBurned()
    {
        return Minutes * 8; // Rough estimate: 8 calories per minute
    }
}
