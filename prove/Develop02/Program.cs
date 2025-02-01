using System;
using System.IO;
/*
 * David Peters
 * This journal program exceeds the requirements by incorporating security features.
 * All journal entries and the password are encoded when saved to a file and decoded when loaded,
 * providing an additional layer of security to protect the user's data.
 */

class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = new Journal();
        journal1.DisplayEntries(); // Display any pre-loaded entries

        int choice = 3;
        while(choice != 5){
            // Display the menu options to the user
            Console.WriteLine("Welcome to my journal program! ");
            Console.WriteLine("Please choose from the following options: ");
            Console.WriteLine("1) Write a new entry");
            Console.WriteLine("2) Display the journal");
            Console.WriteLine("3) Save the journal to a file (Will overwrite file)");
            Console.WriteLine("4) Load the journal from a file (Will lose currently working on entries, make sure to save first)");
            Console.WriteLine("5) Exit");
            
            // Prompt user for input
            Console.Write("Please enter which option you would like (1-5): ");
            string textChoice = Console.ReadLine();
            choice = int.Parse(textChoice);

            // Execute the corresponding action based on user's choice
            switch(choice){
                case 1:
                    journal1.CreateEntry(); // Add a new journal entry
                    break;
                case 2:
                    journal1.DisplayEntries(); // Display all journal entries
                    break;
                case 3:
                    journal1.SaveJournal(); // Save journal entries to a file with encryption
                    break;
                case 4:
                    journal1.LoadJournal(); // Load journal entries from a file with password protection
                    break;
                case 5:
                    break; // Exit the program
            }
        }
    }
}
