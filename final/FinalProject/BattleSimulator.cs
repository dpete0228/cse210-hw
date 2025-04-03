using System;


class BattleSimulator
{
    private Army _nephiteArmy = new Army("Nephite");
    private Army _lamaniteArmy = new Army("Lamanite");

public void SimulateBattleRound(int roundCount)
{
    int count;
    if (_nephiteArmy.GetArmyCount() > _lamaniteArmy.GetArmyCount())
    {
        count = _nephiteArmy.GetArmyCount();
    }
    else
    {
        count = _lamaniteArmy.GetArmyCount();
    }

    for (int i = 0; i < count; i++)
    {
        WarriorAttack(i, _nephiteArmy, _lamaniteArmy);
        WarriorAttack(i, _lamaniteArmy, _nephiteArmy);
    }
    _nephiteArmy.ArmyCheck();
    _lamaniteArmy.ArmyCheck();
    Console.WriteLine($"Statistics after round {roundCount}");
    _nephiteArmy.DisplayArmyStatistics();
    _lamaniteArmy.DisplayArmyStatistics();
}

public void SimulateBattle(){
    int count = 0;
    do{
        SimulateBattleRound(count+1);
        count +=1;
    }while(!(_nephiteArmy.ArmyRetreatCheck() && _lamaniteArmy.ArmyRetreatCheck()));
}

private void WarriorAttack(int index, Army attackingArmy, Army targetArmy){
    if (index < attackingArmy.GetArmyCount() && attackingArmy.GetWarrior(index).CanAttack())
        {
            int target = FindValidTarget(targetArmy);
            if(target != -1){
                int warriorSwitch = attackingArmy.GetWarrior(index).Attack(targetArmy.GetWarrior(target));
                if(warriorSwitch == -1){
                    attackingArmy.AddUnits(targetArmy.GetWarrior(target));
                    targetArmy.removeWarrior(index);
                    targetArmy.SetNumberTraitors(targetArmy.GetNumberTraitors()+1);
                }
            }
        }
}
private int FindValidTarget(Army army)
{
    int targetCount = army.GetArmyCount();
    Random random = new Random();
    for (int attempt = 0; attempt < 10; attempt++)
    {
        int targetIndex = random.Next(targetCount);
        Warrior target = army.GetWarrior(targetIndex);

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
    for (int i = 0; i < 5; i++){    
        Console.Write($"How many {GetNephiteWarriorType(i).GetUnitType()}s are going to be in this? ");
        string userInput = Console.ReadLine();
        int unitCount = int.Parse(userInput);
        for(int j = 0; j < unitCount; j++){
            _nephiteArmy.AddUnits(GetNephiteWarriorType(i));
        }
    }
    Console.WriteLine("Great! Now we'll create the lamanite army");
    for (int i = 0; i < 4; i++){    
        Console.Write($"How many {GetLamaniteWarriorType(i).GetUnitType()}s are going to be in this? ");
        string userInput = Console.ReadLine();
        int unitCount = int.Parse(userInput);
        for(int j = 0; j < unitCount; j++){
            _lamaniteArmy.AddUnits(GetLamaniteWarriorType(i));
        }
    }    
}

    public Warrior GetNephiteWarriorType(int i){
    
        switch(i){
            case 0: // Chief Captain
                ChiefCaptain chiefCaptain = new ChiefCaptain();
                return chiefCaptain;
            case 1: // Captain
                Captain captain = new Captain();
                return captain;
            case 2: // Ammonite
                Ammonite ammonite = new Ammonite();
                return ammonite;
            case 3: // King Man
                KingMan kingMan = new KingMan();
                return kingMan;
            default: // Nephite Warrior
                NephiteWarrior nephiteWarrior = new NephiteWarrior();
                return nephiteWarrior;

        }
    }

    public Warrior GetLamaniteWarriorType(int i){
        switch(i){
            case 0:
                LamaniteKing lamaniteKing = new LamaniteKing();
                return lamaniteKing;
            case 1:
                LamaniteCommander lamaniteCommander = new LamaniteCommander();
                return lamaniteCommander;
            case 2:
                Dissenter dissenter = new Dissenter();
                return dissenter;

            default:
                LamaniteWarrior lamaniteWarrior = new LamaniteWarrior();
                return lamaniteWarrior;
        }
    }
}
