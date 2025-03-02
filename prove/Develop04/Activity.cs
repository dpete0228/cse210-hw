using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    
    
    public void Start(){
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine($"\n{_description}");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string userInput = Console.ReadLine();
        _duration = int.Parse(userInput);
         Console.Clear();
        Console.WriteLine("Get ready...");
        DisplayAnimation(5);
    }
    public void End(){
        Console.WriteLine("\nWell done!!");
        DisplayAnimation(5);
        Console.WriteLine($"\nYou have successfully completed another {_duration} seconds of the {_name} activity\n");
        DisplayAnimation(5);
    }
    public void DisplayAnimation(int duration){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        int i = 0;
        while(DateTime.Now < endTime){
            if(i == animationStrings.Count()){
                i = 0;
            }
            Console.Write(animationStrings[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
        }
    }
    public void DisplayCountdown(int duration){
            for(int i = duration; i >= 0; i--){
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
    }
}