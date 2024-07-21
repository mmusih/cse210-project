using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you list things in a certain area.";
        _count = 0;
        _prompts = new List<string> { "Prompt 1", "Prompt 2", "Prompt 3" }; // Example prompts
    }

    public void RunActivity()
    {
        DisplayStartingMessage();
        // Implement specific behavior for ListingActivity
        Console.WriteLine("Running Listing Activity...");
        DisplayPrompts();
        GetListFromUser();
        DisplayEndingMessage();
    }

    private void DisplayPrompts()
    {
        foreach (var prompt in _prompts)
        {
            Console.WriteLine($"Prompt: {prompt}");
        }
        ShowCountDown(5);
    }

    public List<string> GetListFromUser()
    {
        // Simulate user input for listing items
        List<string> items = new List<string> { "Item 1", "Item 2", "Item 3" }; // Example items
        _count = items.Count;
        Console.WriteLine($"Listed {_count} items.");
        return items;
    }
}
