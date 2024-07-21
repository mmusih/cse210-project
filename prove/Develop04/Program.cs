using System;

class Program
{
    static void Main(string[] args)
    {
        bool quitRequested = false;
        
        while (!quitRequested)
        {
            DisplayMenu();
            int choice = GetChoice();
            
            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.RunActivity();
                    break;
                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.RunActivity();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.RunActivity();
                    break;
                case 4:
                    quitRequested = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
        
        Console.WriteLine("Program ended. Goodbye!");
    }
    
    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
        Console.Write("Select a choice from the above menu: ");
    }
    
    static int GetChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            Console.Write("Select a choice from the above menu: ");
        }
        return choice;
    }
}
