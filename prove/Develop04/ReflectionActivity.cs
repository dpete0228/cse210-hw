using System;

public class ReflectionActivity : Activity
{
    private List<string> _reflectionPrompts = new List<string>
{
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless.",
    "Think of a time when you overcame a major challenge.",
    "Think of a time when you stayed strong under pressure.",
    "Think of a time when you worked hard to achieve a goal.",
    "Think of a time when you showed kindness to a stranger.",
    "Think of a time when you forgave someone, even when it was hard.",
    "Think of a time when you made a tough but necessary decision.",
    "Think of a time when you supported a friend through a difficult moment.",
    "Think of a time when you learned something valuable from a failure.",
    "Think of a time when you took a risk that paid off.",
    "Think of a time when you motivated someone else to keep going.",
    "Think of a time when you turned a setback into an opportunity.",
    "Think of a time when you stood by your values, even when it was hard.",
    "Think of a time when you showed leadership in a tough situation.",
    "Think of a time when you made a positive impact on someone's life.",
    "Think of a time when you handled criticism well.",
    "Think of a time when you showed patience and understanding."
};
private List<string> _reflectionQuestions = new List<string>
{
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?",
    "How did this experience shape your perspective on challenges?",
    "What emotions did you feel during this experience?",
    "How did others react to your actions?",
    "What obstacles did you have to overcome?",
    "Would you handle this situation differently if it happened again?",
    "How did this experience strengthen your character?",
    "Did this experience change your values or priorities in any way?",
    "What skills did you use to navigate this situation?",
    "Who, if anyone, inspired you during this experience?",
    "How can you apply the lessons from this experience to future goals?",
    "What advice would you give to someone facing a similar situation?"
};


    public ReflectionActivity(){
        _name = "Reflecting";
        _description = "This activity encourages deep thinking about moments of strength and resilience in your life. Through guided prompts, you’ll reflect on meaningful experiences, gaining insight and recognizing your personal growth.";
        Start();
    }

    public void StartReflectionActivity(){
       
        Console.WriteLine("\nConsider the following prompt:\n");
        Random random = new Random();
        string selectedPrompt =_reflectionPrompts[random.Next(_reflectionPrompts.Count)];
        Console.WriteLine($"--- {selectedPrompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to your experience.");
        Console.Write("You may begin in: ");
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        DisplayCountdown(5);
        Console.Clear();
        while(DateTime.Now < endTime){
            string selectedQuestion = _reflectionQuestions[random.Next(_reflectionQuestions.Count)];
            Console.Write($"\n{selectedQuestion}");
            DisplayAnimation(10);
        }
    End();
    }
}