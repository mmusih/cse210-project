using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your score?");
        string userInput = Console.ReadLine();
        int score = int.Parse(userInput);
        if (score >= 90){
    Console.WriteLine("A");
}
else if (score >= 80)
{
    Console.WriteLine("B");
}
else if (score >= 70)
{
    Console.WriteLine("C");
}
else if (score >= 60)
{
    Console.WriteLine("D");
}
else
{
    Console.WriteLine("F");
}
    }
}