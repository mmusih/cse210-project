public class Program
{
    public static Journal journal = new Journal();
    public static PromptGenerator promptGenerator = new PromptGenerator();

    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
        }
    }

    public static void WriteEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        journal.AddEntry(new Entry(prompt, response));
    }

    public static void LoadJournal()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }

    public static void SaveJournal()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }
}