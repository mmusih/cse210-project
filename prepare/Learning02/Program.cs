using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Media House";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2009;
        job1._endYear = 2011;

        // job1.Display();

        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2011;
        job2._endYear = 2015;

        // job2.Display();

        Resume myResume = new Resume();
        myResume._name = "Mmusi Hubona";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}