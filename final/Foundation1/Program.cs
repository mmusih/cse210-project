// Program.cs
using System;
class Program
{
    public static void Main()
    {
        var video1 = new Video("Learning C#", "Alice", 300);
        var video2 = new Video("Advanced C#", "Bob", 450);
        var video3 = new Video("C# Tips and Tricks", "Charlie", 600);

        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Jane", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Doe", "I learned a lot!"));

        video2.AddComment(new Comment("Anna", "This is a bit advanced for me."));
        video2.AddComment(new Comment("Mike", "Excellent content!"));

        video3.AddComment(new Comment("Emily", "Awesome tips, thanks!"));
        video3.AddComment(new Comment("Paul", "Could you add more examples?"));

        var videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}
