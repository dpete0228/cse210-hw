class PromptGenerator
{
    public List<string> promptList_ = new List<string>
    {
        "What was the highlight of your day:",
        "What is something new you learned today:",
        "Describe a moment that made you smile:",
        "What is a goal you want to achieve this week:",
        "Write about a challenge you faced and how you handled it:"
    };

    // Returns a random prompt from the list
    public string RandomPrompt(){
        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0, promptList_.Count-1);
        string prompt_ = promptList_[randomIndex];
        return prompt_;
    }
}
