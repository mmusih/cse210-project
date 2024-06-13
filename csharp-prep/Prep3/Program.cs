using System;

class Program
{
    static void Main(string[] args)
    {
Random randomGenerator = new Random();
int number = randomGenerator.Next(1, 101);
// Console.WriteLine(number);
int guess = -1;
while (!(guess == number)) {
    Console.WriteLine("Guess the magic number?");
    string response = Console.ReadLine();
    guess = int.Parse(response);
    if ( guess > number){
        Console.WriteLine("Lower");
    } 
    else if (guess < number){
        Console.WriteLine("Higher");
    }
    else {
        Console.WriteLine("You guessed it!!");
    }
        }

    }
}