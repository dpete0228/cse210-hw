using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        List<int> activityCount = [0, 0, 0];
        int choice = 0;
        while(choice != 4){
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1) Start Breathing Activity");
            Console.WriteLine("2) Start Reflection Activity");
            Console.WriteLine("3) Start Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            choice = int.Parse(userInput);
            switch(choice){
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartBreathingActivity();
                    activityCount[0]++;
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartReflectionActivity();
                    activityCount[1]++;
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartListingActivity();
                    activityCount[2]++;
                    break;
                case 4:
                    break;
                default:
                    choice = 0;
                    break;
            }
        }
        Console.Clear();
        Console.WriteLine("Good job at being mindful today!!\n");
        Console.WriteLine($"You successfully completed the breathing activity {activityCount[0]} time(s)");
        Console.WriteLine($"You successfully completed the reflecting activity {activityCount[1]} time(s)");
        Console.WriteLine($"You successfully completed the listing activity {activityCount[2]} time(s)");
        Console.WriteLine("\nYou did great!");
    }
}