public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    public void DisplayJobs(){
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job jobDescription in _jobs){
            jobDescription.DisplayJobDetails();
        }
    }
}