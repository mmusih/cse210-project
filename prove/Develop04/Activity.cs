using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is a generic activity.";
        _duration = 60; // Default duration in seconds
    }

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds.");
        Console.WriteLine("Get ready to begin...");
        ShowCountDown(3);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You've completed {_name}.");
        Console.WriteLine($"Total duration: {_duration} seconds.");
        ShowCountDown(3);
    }

    protected void ShowSpinner(int seconds)
    {
        // Simulate showing a spinner animation
        Console.WriteLine("Spinner animation...");
        System.Threading.Thread.Sleep(seconds * 1000);
    }

    protected void ShowCountDown(int seconds)
    {
        // Simulate showing a countdown
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i}...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}