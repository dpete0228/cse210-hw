using System;
using System.Net.Quic;


//To meet the exceeding requirements it can pull the scriptures from a file and the user can choose which to memorize
class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");
        List<Scripture> scriptures = new List<Scripture>();
        Console.WriteLine("Here are the choices for scriptures to memorize:");
        for(int i = 0; i < lines.Count(); i++){
            Scripture temp = new Scripture(lines[i]);
            scriptures.Add(temp);
            Console.WriteLine($"{i+1}) {temp.DisplayReference()}");
        }
        Console.Write("Which one do you want: ");
        string userChoice = Console.ReadLine();
        int choice = int.Parse(userChoice) - 1;
        Scripture scripture = new Scripture(lines[choice]);
        bool quit = false;
        string userInput;
        while(quit == false){
            Console.Clear();
            Console.WriteLine(scripture.GetFormattedVerse());
            if (scripture.IsCompletelyHidden() == true){
                Console.WriteLine("All the words are hidden. Goodbye");
                quit = true;
                return;
            }
            scripture.HideWords();
            Console.Write("Press enter if you want to hide the next word. Type 'quit' if you want to quit. What do you want to do: ");
            userInput = Console.ReadLine();
            if (userInput == "quit"){
                quit = true;
                Console.WriteLine("Exiting now");
            }

        }
    }
}