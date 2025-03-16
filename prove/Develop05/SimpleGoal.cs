using System;

class SimpleGoal : Goal
{

    public SimpleGoal (string type):base(type){
    }
    public SimpleGoal (string type, string name, string description, string points, string isCompleted):base(type, name,description, points, isCompleted){
    }
    public override int RecordEvent(){
        _isCompleted = true;
        return _points;
    }
    public override string Display(){
        if (_isCompleted == true){
            return $"[✓] {GetName()} ({GetDescription()})";
        }
        return $"[ ] {GetName()} ({GetDescription()})";
    }
    public override string SaveString()
    {
        return $"{GetClassType()}~|~{GetName()}~|~{GetDescription()}~|~{_points}~|~{_isCompleted}";
    }
}