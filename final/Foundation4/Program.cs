using System;

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running("03 Nov 2024", 30, 4.8),
            new Cycling("04 Nov 2024", 45, 20.0),
            new Swimming("05 Nov 2024", 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
