using System;

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse = 0;
    public Reference(string book, int chapter, int verse){
        _book = book;
        _chapter = chapter;
        _startVerse=verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse){
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
    public string GetFormattedReference(){
        string formattedReference;
        if(_endVerse == 0){
            formattedReference = $"{_book} {_chapter}:{_startVerse}:";
        }else{
            formattedReference = $"{_book} {_chapter}:{_startVerse}-{_endVerse}:";
        }
        return formattedReference;
    }
}