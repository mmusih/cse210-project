using System;

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Freedom St", "Lagos", "Lagos State", "Nigeria");
        Address address2 = new Address("456 Unity Rd", "Nairobi", "Nairobi County", "Kenya");
        Address address3 = new Address("789 Peace Ave", "Cape Town", "Western Cape", "South Africa");

        Lecture lecture = new Lecture("Tech Talk", "A talk on the latest in tech", "2023-09-01", "10:00 AM", address1, "Dr. John Smith", 100);
        Reception reception = new Reception("Wedding Reception", "Celebrate the wedding of John and Jane", "2023-10-15", "6:00 PM", address2, "rsvp@wedding.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Community Picnic", "Join us for a fun community picnic", "2023-08-20", "12:00 PM", address3, "Sunny with a chance of rain");

        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine();

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine();

        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
