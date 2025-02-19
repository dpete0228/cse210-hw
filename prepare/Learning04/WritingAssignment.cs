    using System;

public class WritingAssignment : Assignment
{   
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic){
        _title = title;
    }
    private string _title;

    public string GetWritingInformation(){
        return $"{_title} by {_studentName}";
    }
    
}