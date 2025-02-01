class Entry
{
    public string date_;  // Stores the date of the journal entry
    public string prompt_;  // Stores the prompt/question for the journal entry
    public string entry_;  // Stores the user's journal entry

    // Displays the journal entry in a formatted manner
    public void DisplayEntry(){
        Console.WriteLine($"Date:{date_} - Prompt: {prompt_} - Entry: {entry_}\n");
    }
}