using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by guiding your breathing.";
    }

    public void RunActivity()
    {
        DisplayStartingMessage();
        Console.WriteLine("Running Breathing Activity...");
        ShowBreathingInstructions();
        DisplayEndingMessage();
    }

    private void ShowBreathingInstructions()
    {
        Console.WriteLine("Follow the instructions for breathing...");
        ShowCountDown(_duration);
    }
}
