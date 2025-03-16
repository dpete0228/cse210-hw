using System;
using System.Data;

class Goal
{
    private string _name;
    private string _description;
    
    private string _type;
    protected int _points;
    protected bool _isCompleted = false;
    public Goal (string type){
        Console.Write("What is the name of your goal? ");
        _name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        _description = Console.ReadLine();
        Console.Write("How many points is it worth? ");
        string userInput = Console.ReadLine();
        _points = int.Parse(userInput);
        _type = type;
    }
    public Goal(string type,string name, string description, string points, string isCompleted){
        _name = name;
        _description = description;
        _points = int.Parse(points);
        _isCompleted = bool.Parse(isCompleted);
        _type = type;
    }
    public virtual int RecordEvent(){
        return 0;
    }
    public virtual string Display(){
        return "";
    }
    public virtual string SaveString(){
        return "";
    }
    public string GetName(){
        return _name;
    }
    public string GetDescription(){
        return _description;
    }
    public string GetClassType(){
        return _type;
    }


}