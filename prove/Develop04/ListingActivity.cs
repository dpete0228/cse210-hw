using System;

public class ListingActivity : Activity
{
    private List<string> listingPrompts = new List<string>
{
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the Holy Ghost this month?",
    "Who are some of your personal heroes?",
    "What are some things you are grateful for today?",
    "What are some accomplishments you are proud of?",
    "What are some challenges you have overcome?",
    "What are things that make you happy?",
    "What are some acts of kindness you have witnessed or done?",
    "What are some goals you have for the future?",
    "What are places that hold special meaning to you?",
    "What are some lessons you have learned recently?"
};

    public ListingActivity(){
        _name = "Listing";
        _description = "This activity helps you focus on the positive aspects of your life by listing as many things as possible within a given category. By doing so, you'll cultivate gratitude and recognize the abundance of good around you.";
        Start();
    }
    
    public void StartListingActivity(){
        Console.WriteLine("List as many responses as you can to the following prompt");
        Random random = new Random();
        string selectedPrompt = listingPrompts[random.Next(listingPrompts.Count)];
        Console.WriteLine($"--- {selectedPrompt} ---");
        Console.Write("You may begin in...");
        DisplayCountdown(5);
        Console.WriteLine();
        DateTime startTime = DateTime.Now; 
        DateTime endTime = startTime.AddSeconds(_duration);
        int count = 0;
        while(DateTime.Now < endTime){
            Console.Write("-");
            Console.ReadLine();
            count ++;
        }
        Console.WriteLine($"You listed {count} items");
        End();
    }
}