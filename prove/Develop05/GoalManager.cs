public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _folderPath = "savefolder/";

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
            Console.WriteLine("Eternal Quest Goal Tracker");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Create Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
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
        Console.WriteLine($"Player Score: {_score}");
    }

    private void ListGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
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
    Console.WriteLine("Select a goal to record:");
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
        Console.Write("\nWhat would you like to name the file? : ");
        string fileName = Console.ReadLine();

        using StreamWriter saveGoals = new($"{_folderPath}{fileName}.txt");
        saveGoals.WriteLine(_score);
        foreach (Goal goal in _goals)
        {
            saveGoals.WriteLine(goal.GetStringRepresentation());
        }
        _goals.Clear();
        
    }

    private void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
        {
            Console.WriteLine("No saved goals found.");
            return;
        }

        using (StreamReader reader = new StreamReader("goals.txt"))
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
