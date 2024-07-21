using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on past experiences.";
        _prompts = new List<string> { "Reflecting Prompt 1", "Reflecting Prompt 2", "Reflecting Prompt 3" }; // Example prompts
        _questions = new List<string> { "Question 1", "Question 2", "Question 3" }; // Example questions
    }

    public void RunActivity()
    {
        DisplayStartingMessage();
        // Implement specific behavior for ReflectingActivity
        Console.WriteLine("Running Reflecting Activity...");
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine($"Reflecting Prompt: {_prompts[0]}");
        ShowCountDown(3);
    }

    private void DisplayQuestions()
    {
        foreach (var question in _questions)
        {
            Console.WriteLine($"Question: {question}");
            ShowSpinner(3);
        }
    }
}
