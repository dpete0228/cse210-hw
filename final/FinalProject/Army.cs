using System;

class Army
{

    private List<Warrior> _army = new List<Warrior>();
    private string _armyType;
    private int _numberInjured;
    private int _armyMorale;
    private int _startingMorale;
    private int _numberRetreated = 0;
    private int _numberDead = 0;
    private int _numberTraitors = 0;
    private int _numberHealthy;
    public Army(string armyType){
        _armyType = armyType;
    }
    
    public void ArmyCheck(){
        List<int> listRemove = new List<int>(); 
        int count = 0;
        _numberInjured = 0;
        _armyMorale = 0;
        _numberHealthy = 0;
        for(int i = 0; i < _army.Count; i++){
            if(_army[i].GetDeadRounds() > 0){
                _army[i].SetDeadRounds(_army[i].GetDeadRounds()-1);
            }
            if(_army[i].GetIsDead()){
                _numberDead +=1;
                listRemove.Add(i - count);
                count += 1;
            }else if(_army[i].GetHasRetreated()){
                _numberRetreated += 1;
                listRemove.Add(i-count);
                count+=1;
            }else if(_army[i].GetDeadRounds() > 0){
                _numberInjured +=1;
            }else{
                _armyMorale+=_army[i].GetMorale();
                _numberHealthy += 1;
            }
        }
        foreach(int remove in listRemove){
            _army.RemoveAt(remove);
        }
    }

    public void DisplayArmyStatistics(){
        Console.WriteLine($"{_armyType} Army Statistics:");
        Console.WriteLine($"Number of Healthy Warriors: {_numberHealthy}");
        Console.WriteLine($"Number of Injured Warriors: {_numberInjured}");
        Console.WriteLine($"Number of Dead Warriors: {_numberDead}");
        Console.WriteLine($"Number of Warriors who retreated: {_numberRetreated}");
        Console.WriteLine($"Number of Warriors who have turned traitor: {_numberTraitors}");
    }

    public void removeWarrior(int index){
        _army.RemoveAt(index);
    }
    public void AddUnits(Warrior warrior){
        _army.Add(warrior);
    }
    public int GetNumberInjured(){
        return _numberInjured;
    }

    public int GetArmyMorale(){
        return _armyMorale;
    }
    public int GetNumberRetreated(){
        return _numberRetreated;
    }
    public int GetNumberDead(){
        return _numberDead;
    }
    public int GetArmyCount(){
        return _army.Count;
    }
    public Warrior GetWarrior(int index){
        return _army[index];
    }
    
    public int GetNumberTraitors(){
        return _numberTraitors;
    }
    public void SetNumberTraitors(int numberTraitors){
        _numberTraitors = numberTraitors;
    }
    public void SetStartingMorale(int startingMorale){
        _startingMorale = startingMorale;
    }
    public bool ArmyRetreatCheck(){
        return (_armyMorale <= _startingMorale/3) && _numberHealthy == 0;
    }

    

}