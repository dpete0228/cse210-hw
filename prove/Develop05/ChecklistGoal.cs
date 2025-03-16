using System;
using System.Reflection;

class ChecklistGoal : Goal
{

    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;
    public ChecklistGoal (string type):base(type){
        Console.Write("How many times does this goal need to be accomplished for a bonus: ");
        string userInput = Console.ReadLine();
        _targetCount = int.Parse(userInput);
        _currentCount = 0;
        Console.Write("How many bonus points is it worth: ");
        userInput = Console.ReadLine();
        _bonusPoints = int.Parse(userInput);
    }
    public ChecklistGoal(string type, string name, string description, string points, string isCompleted, string currentCount, string targetCount, string bonusPoints):base(type, name, description, points, isCompleted){
        _targetCount = int.Parse(targetCount);
        _currentCount = int.Parse(currentCount);
        _bonusPoints = int.Parse(bonusPoints);
    }
    public override int RecordEvent(){
        _currentCount++;
        if(_targetCount == _currentCount){
            _isCompleted = true;
            return _bonusPoints + _points;
        }
            return _points;
    }
    public override string Display(){
        if (_isCompleted == true){
            return $"[✓] {GetName()} ({GetDescription()}) -- Currently Completed {_currentCount}/{_targetCount}";
        }
        return $"[ ] {GetName()} ({GetDescription()}) -- Currently Completed {_currentCount}/{_targetCount}";    
    }
    public override string SaveString()
    {
        return $"{GetClassType()}~|~{GetName()}~|~{GetDescription()}~|~{_points}~|~{_isCompleted}~|~{_currentCount}~|~{_targetCount}~|~{_bonusPoints}";
    }

}