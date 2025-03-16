using System;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;
    public GoalManager(){
    }
    public void CreateGoal(){
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1) Simple Goal\n2) Eternal Goal\n3) Checklist Goal");
        Console.Write("Select a choice from the menu (Enter a number between 1-3): ");
        string userChoice = Console.ReadLine();
        switch(userChoice){
            case "1":
                SimpleGoal newSimpleGoal = new SimpleGoal("simple");
                _goals.Add(newSimpleGoal);
                break;
            case "2":
                EternalGoal newEternalGoal = new EternalGoal("eternal");
                _goals.Add(newEternalGoal);
                break;
            case "3":
                ChecklistGoal newChecklistGoal = new ChecklistGoal("checklist");
                _goals.Add(newChecklistGoal);
                break;
            default:
                break;
        }
    }
    public void RecordEvent(){
        DisplayGoals();
        Console.Write($"Which goal would you like to record (Enter a number between 1 and {_goals.Count()}): ");
        string userChoice = Console.ReadLine();
        int userInt = int.Parse(userChoice) - 1;
        int _pointsReceived = _goals[userInt].RecordEvent();
        _score += _pointsReceived;
        Console.WriteLine($"Congradulations! You have received {_pointsReceived} Cookies!!");
    }
    public void DisplayGoals(){
        for(int i = 0; i < _goals.Count(); i++){
            Console.WriteLine($"{i+1}) {_goals[i].Display()}");
        }

    }
    public void SaveGoals(){
        Console.Write("What file do you want to save your goals to: ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
    {
            // You can add text to the file with the WriteLine method
            outputFile.WriteLine($"{_score}");
            foreach(Goal goal in _goals){
                outputFile.WriteLine(goal.SaveString());
            }
    }   
    }
    public void LoadGoals(){
        _goals.Clear();
        _goals.TrimExcess();
        Console.Write("What file do you want to load your goals to: ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i=1; i<lines.Count(); i++)
        {
            string[] parts = lines[i].Split("~|~");
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            string points = parts[3];
            string isCompleted = parts[4];
            if(type == "checklist"){
                string currentCount = parts[5];
                string targetCount = parts[6];
                string bonusPoints = parts[7];
                ChecklistGoal newChecklistGoal = new ChecklistGoal(type, name, description, points, isCompleted, currentCount, targetCount, bonusPoints);
                _goals.Add(newChecklistGoal);
            }
            switch(type){
            case "simple":
                SimpleGoal newSimpleGoal = new SimpleGoal(type, name, description, points, isCompleted);
                _goals.Add(newSimpleGoal);
                break;
            case "eternal":
                EternalGoal newEternalGoal = new EternalGoal(type, name, description, points, isCompleted);
                _goals.Add(newEternalGoal);
                break;
            }   
        }
    }
    public int GetScore(){
        return _score;
    }
    public string GetLevel(){
        if(_score < 50){
            return "Cookie Enthusiast";
        }else if(_score < 150){
            return "Cookie Eater";
        }else if(_score < 400){
            return "Cookie Critic";
        }else if(_score < 1000){
            return "Cookie Monster";
        }else if(_score < 5000){
            return "Cookie Lord";
        }else{
            return "Cookie King";
        }
    }

}