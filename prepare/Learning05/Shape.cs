using System;

public abstract class Shape
{
    public Shape(string color){
        _color = color;
    }
    private string _color;

    public string GetColor(){
        return _color;
    }
    public void SetColor(string color){
        _color = color;
    }
    public abstract double GetArea();
}