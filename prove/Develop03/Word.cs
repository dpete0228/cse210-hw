using System;

class Word
{
    private string _word;
    private bool _isHidden = false;

    public Word(string word){
        _word = word;
    }
    public bool HideWord(){
        bool alreadyHidden = false;
        if(_isHidden == true){
            alreadyHidden = true;
            return alreadyHidden;
        }
        _isHidden = true;
        return alreadyHidden;

    }
    public void ShowWord(){
        _isHidden = false;
    }
    public string GetRenderedText(){
        string _renderedText=" ";
        if (_isHidden == false){
            _renderedText+=_word;
            return _renderedText;
        }else{
            foreach(char character in _word){
                _renderedText+='_';
            }
            return _renderedText;
        }
    }
    public bool IsHidden(){
        return _isHidden;
    }
}