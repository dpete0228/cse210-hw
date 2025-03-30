using System;
using System.Configuration.Assemblies;

class BattleSimulator
{
    private List<Warrior> _nephiteArmy = new List<Warrior>();
    private List<Warrior> _lamaniteArmy = new List<Warrior>();

public void SimulateBattleRound()
{
    int count;
    if (_nephiteArmy.Count > _lamaniteArmy.Count)
    {
        count = _nephiteArmy.Count;
    }
    else
    {
        count = _lamaniteArmy.Count;
    }

    for (int i = 0; i < count; i++)
    {
        if (i < _nephiteArmy.Count && _nephiteArmy[i].CanAttack())
        {
            int target = FindValidTarget(_lamaniteArmy);
            if(target != -1){
                _nephiteArmy[i].Attack(_lamaniteArmy[target]);
            }
        }

        if (i < _lamaniteArmy.Count && _lamaniteArmy[i].CanAttack())
        {
            int target = FindValidTarget(_nephiteArmy);
            if(target != -1){
                _lamaniteArmy[i].Attack(_nephiteArmy[target]);
            }
        }
    }
}

private int FindValidTarget(List<Warrior> army)
{
    int targetCount = army.Count;
    Random random = new Random();
    for (int attempt = 0; attempt < 10; attempt++)
    {
        int targetIndex = random.Next(targetCount);
        Warrior target = army[targetIndex];

        if (!target.GetIsDead() && !target.GetHasRetreated() && target.GetDeadRounds() == 0)
        {
            return targetIndex;
        }
    }

    return -1;
}

public void CreateArmies()
{
    Console.WriteLine("Welcome to the nephite lamanite battle simulator");
    Console.WriteLine("First we'll create the nephite army");
    for (int i = 0; i < 4; i++){    
        Console.Write($"How many {GetNephiteWarriorType(i).GetUnitType()}s are going to be in this? ");
        string userInput = Console.ReadLine();
        int unitCount = int.Parse(userInput);
        for(int j = 0; j < unitCount; j++){
            _nephiteArmy.Add(GetNephiteWarriorType(i));
        }
    }
    Console.WriteLine("Great! Now we'll create the lamanite army");
    for (int i = 0; i < 4; i++){    
        Console.Write($"How many {GetLamaniteWarriorType(i).GetUnitType()}s are going to be in this? ");
        string userInput = Console.ReadLine();
        int unitCount = int.Parse(userInput);
        for(int j = 0; j < unitCount; j++){
            _lamaniteArmy.Add(GetLamaniteWarriorType(i));
        }
    }    
}

    public Warrior GetNephiteWarriorType(int i){
    
        switch(i){
            case 0: // Chief Captain
                Nephite chiefCaptain = new Nephite();
                return chiefCaptain;
            case 1: // Captain
                Nephite captain = new Nephite();
                return captain;
            case 2: // Ammonite
                Ammonite ammonite = new Ammonite();
                return ammonite;
            default: // Nephite
                Nephite nephite = new Nephite();
                return nephite;

        }
    }

    public Warrior GetLamaniteWarriorType(int i){
        switch(i){
            case 0:
                Lamanite lamaniteKing = new Lamanite();
                return lamaniteKing;
            case 1:
                Lamanite lamaniteCommander = new Lamanite();
                return lamaniteCommander;
            case 2:
                Lamanite dissenter = new Lamanite();
                return dissenter;

            default:
                Lamanite lamanite = new Lamanite();
                return lamanite;
        }
    }
}
