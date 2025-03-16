using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        bool quit = false;
        string choice;
        while(quit == false){
            Console.Clear();
            Console.WriteLine($"You have {goalManager.GetScore()} Cookies!");
            Console.WriteLine($"You have achieved the level of: {goalManager.GetLevel()}");
            Console.WriteLine("Menu options:");
            Console.WriteLine("1) Write a new goal\n2) List Goals\n3) Save Goals\n4) Load Goals\n5) Record Event\n6) Quit");
            Console.Write("Select a choice from the menu (Enter a number between 1-6): ");
            choice = Console.ReadLine();
            switch(choice){
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.DisplayGoals();
                    break;
                case "3":

                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    quit = true;
                    Console.Write("Do you want to save before quitting (y/n): ");
                    string userChoice = Console.ReadLine();
                    userChoice.ToLower();
                    if(userChoice == "y" || userChoice == "yes"){
                        goalManager.SaveGoals();
                    }
                    Console.WriteLine("Thank you for using the goal management software");
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }
    }
}