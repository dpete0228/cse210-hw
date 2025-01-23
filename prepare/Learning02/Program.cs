using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;
        Job job2 = new Job();
        job2._company = "Microsoft";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2025;
        Resume resume1 = new Resume();
        resume1._name = "David Peters";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1.DisplayJobs();
        
    }
}