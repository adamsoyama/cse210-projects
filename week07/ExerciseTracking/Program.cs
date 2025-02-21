using System;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 21), 30, 3.0),
            new Cycling(new DateTime(2025, 02, 21), 30, 18.0),
            new Swimming(new DateTime(2025, 02, 21), 30, 20)
        };

        // Add some additional features
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        // Weekly summary (for demonstration)
        GenerateWeeklySummary(activities);
    }

    // Method to generate weekly summary
    public static void GenerateWeeklySummary(List<Activity> activities)
    {
        int totalMinutes = 0;
        double totalDistance = 0;
        double totalCalories = 0;

        foreach (var activity in activities)
        {
            totalMinutes += activity.Minutes;
            totalDistance += activity.GetDistance();
            totalCalories += activity.GetCaloriesBurned();
        }

        Console.WriteLine($"\nWeekly Summary: Total Minutes: {totalMinutes}, Total Distance: {totalDistance:0.0} miles, Total Calories: {totalCalories:0} kcal");
    }
}
