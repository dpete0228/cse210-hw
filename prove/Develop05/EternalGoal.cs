using System;

class EternalGoal : Goal
{
    public EternalGoal (string type):base(type){
    }
    public EternalGoal (string type, string name, string description, string points, string isCompleted):base(type,name, description, points, isCompleted){

    }
    public override int RecordEvent(){
        return _points;
    }
    public override string Display(){
        return $"[ ] {GetName()} ({GetDescription()})";
    }
    public override string SaveString()
    {
        return $"{GetClassType()}~|~{GetName()}~|~{GetDescription()}~|~{_points}~|~{_isCompleted}";
    }
}