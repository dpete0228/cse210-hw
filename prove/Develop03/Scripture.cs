using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _verse = new List<Word>();

    public Scripture(string words){
        string book;
        int chapter = 0;
        int startVerse = 0;
        int endVerse = 0;
        string []section = words.Split("~|~");
        for (int i = 0; i < section.Length; i++)
        {
            if (i == 0)
            {
                string[] reference = section[0].Split("~/~");

                book = reference[0];
                

                chapter = int.Parse(reference[1]);


                startVerse = int.Parse(reference[2]);

                if (reference.Length > 3)
                {
                    endVerse = int.Parse(reference[3]);
                    _reference = new Reference(book, chapter, startVerse, endVerse);
                }
                else
                {
                    _reference = new Reference(book, chapter, startVerse);
                }
            }else{
                foreach (string word in section[1].Split(' ')){
                    Word newWord = new Word(word);
                    _verse.Add(newWord);
                }
            }
        }

    }
    public Scripture(Reference reference, string words){
        foreach (string word in words.Split(' ')){
            Word newWord = new Word(word);
            _verse.Add(newWord);
        }
        _reference = reference;
    }
    public void HideWords(){
        Random randomGenerator = new Random();
        bool alreadyHidden = true;
        while(alreadyHidden == true){
            int randomNumber = randomGenerator.Next(0, _verse.Count());
            alreadyHidden = _verse[randomNumber].HideWord();
        }
    }
    public string GetFormattedVerse(){
        string formattedVerse = _reference.GetFormattedReference();
        foreach (Word word in _verse){
            formattedVerse += word.GetRenderedText();
        }
        return formattedVerse;
    }
    public bool IsCompletelyHidden(){
        bool completelyHidden = true;
        foreach(Word word in _verse){
            if(word.IsHidden() == false){
                completelyHidden = false;
                return completelyHidden;
            }
        }
        return completelyHidden;
    }
    
    public string DisplayReference(){
        return _reference.GetFormattedReference();
    }

 }