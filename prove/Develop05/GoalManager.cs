public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            DisplayMenu();
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}\n");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to return to the menu.");
        Console.ReadKey();
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nSelect goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter goal target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter goal bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nSelect a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var goal = _goals[index];
        goal.RecordEvent();
        _score += goal.Points;

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            _score += checklistGoal.Bonus;
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string fileName = Console.ReadLine();
        
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string fileName = Console.ReadLine();
        
        if (!File.Exists(fileName))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        using (StreamReader reader = new StreamReader(fileName))
        {
            _score = int.Parse(reader.ReadLine());
            _goals.Clear();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(parts[4]);
                        var simpleGoal = new SimpleGoal(name, description, points);
                        if (isComplete)
                        {
                            simpleGoal.RecordEvent();
                        }
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, description, points));
                        break;
                    case "ChecklistGoal":
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int i = 0; i < amountCompleted; i++)
                        {
                            checklistGoal.RecordEvent();
                        }
                        _goals.Add(checklistGoal);
                        break;
                }
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}
