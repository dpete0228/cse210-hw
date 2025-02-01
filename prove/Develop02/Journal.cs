using System;
using System.IO;

class Journal
{
    public List<Entry> journalEntries_ = new List<Entry>(); // List to store journal entries

    // Loads journal entries from a file
    public void LoadJournal()
    {
        Console.Write("What filename would you like to load your journal from (Don't forget the extension .txt): ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        bool correct1 = false;
        for (int i = 0; i < 3; i++) // Allow up to 3 attempts for password
        {
            Console.Write("Enter the password: ");
            string password = Console.ReadLine();
            if (password == Decode(lines[0]))
            {
                correct1 = true;
                break;
            }
            else
            {
                Console.WriteLine($"Incorrect password. Attempts remaining: {2 - i}");
            }
        }

        if (!correct1)
        {
            Console.WriteLine("Too many failed attempts. Exiting.");
            return;
        }

        // Load and decode each journal entry
        for (int count = 1; count < lines.Length; count++) // Start from 1 to skip password line
        {
            string line = lines[count];
            Entry entryTemp = new Entry();
            string[] parts = line.Split("~|~");
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = Decode(parts[i]); // Decode each part
            }
            entryTemp.date_ = parts[0];
            entryTemp.prompt_ = parts[1];
            entryTemp.entry_ = parts[2];
            journalEntries_.Add(entryTemp);
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    // Decodes an encoded string
    public string Decode(string encodedWord)
    {
        string word = ""; // Initialize an empty string
        
        foreach (char c in encodedWord)
        {
            byte ASCIIValue = Convert.ToByte(c);
            ASCIIValue -= 3; // Simple encoding shift
            char decodedChar = Convert.ToChar(ASCIIValue);
            word += decodedChar; 
        }

        return word;
    }

    // Encodes a string for security
    public string Encode(string encodedWord)
    {
        string word = ""; 
        
        foreach (char c in encodedWord)
        {
            byte ASCIIValue = Convert.ToByte(c);
            ASCIIValue += 3; // Simple encoding shift
            char decodedChar = Convert.ToChar(ASCIIValue);
            word += decodedChar; 
        }

        return word;
    }

    // Creates a new journal entry
    public void CreateEntry(){
        Entry newEntry = new Entry();
        DateTime theCurrentTime = DateTime.Now;
        newEntry.date_ = theCurrentTime.ToShortDateString();
        
        PromptGenerator newPrompt = new PromptGenerator();
        newEntry.prompt_ = newPrompt.RandomPrompt();

        string correct = "y";
        do{
            if (correct == "n"){
                Console.WriteLine("Please try again then");
            }
            Console.Write($"{newEntry.prompt_} ");
            newEntry.entry_ = Console.ReadLine();
            newEntry.DisplayEntry();
            Console.Write("Does this look right ('y'/'n')? ");
            correct = Console.ReadLine();
        } while (correct == "n");

        journalEntries_.Add(newEntry);
        Console.WriteLine("Journal Entry Created");
    }

    // Displays all journal entries
    public void DisplayEntries(){
        foreach (Entry journalEntry_ in journalEntries_){
            journalEntry_.DisplayEntry();
        }
    }

    // Saves journal entries to a file with password protection
    public void SaveJournal(){
        Console.Write("What filename would you like to save this to (Don't forget the extension .txt): ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            Console.Write("What do you want the password to be? ");
            string password = Console.ReadLine();
            outputFile.WriteLine(Encode(password)); // Save encoded password

            foreach (Entry journalEntry_ in journalEntries_){
                outputFile.WriteLine($"{Encode(journalEntry_.date_)}~|~{Encode(journalEntry_.prompt_)}~|~{Encode(journalEntry_.entry_)}");
            }
        }
    }
}