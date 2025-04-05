using System;
using System.Collections.Generic;

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

    public Army(string armyType)
    {
        _armyType = armyType;
    }

    public void ArmyCheck()
    {
        List<int> listRemove = new List<int>();
        int count = 0;
        _numberInjured = 0;
        _armyMorale = 0;
        _numberHealthy = 0;
        // Iterate through the army to update unit statuses and count casualties.
        for (int i = 0; i < _army.Count; i++)
        {
            // Decrease the dead rounds counter for units that are temporarily out of combat.
            if (_army[i].GetDeadRounds() > 0)
            {
                _army[i].SetDeadRounds(_army[i].GetDeadRounds() - 1);
            }
            // If a warrior is dead.
            if (_army[i].GetIsDead())
            {
                _numberDead += 1;
                // Mark the index for removal, adjusting for already removed elements.
                listRemove.Add(i - count);
                count += 1;
            }
            // If a warrior has retreated.
            else if (_army[i].GetHasRetreated())
            {
                _numberRetreated += 1;
                // Mark the index for removal, adjusting for already removed elements.
                listRemove.Add(i - count);
                count += 1;
            }
            // If a warrior is injured (in the "dead rounds" state but not fully dead).
            else if (_army[i].GetDeadRounds() > 0)
            {
                _numberInjured += 1;
            }
            // If a warrior is healthy and active.
            else
            {
                _armyMorale += _army[i].GetMorale();
                _numberHealthy += 1;
            }
        }
        // Remove the dead and retreated warriors from the army list.
        foreach (int remove in listRemove)
        {
            _army.RemoveAt(remove);
        }
    }

    public void DisplayArmyStatistics()
    {
        Console.WriteLine($"{_armyType} Army Statistics:");
        Console.WriteLine($"Number of Healthy Warriors: {_numberHealthy}");
        Console.WriteLine($"Number of Injured Warriors: {_numberInjured}");
        Console.WriteLine($"Number of Dead Warriors: {_numberDead}");
        Console.WriteLine($"Number of Warriors who retreated: {_numberRetreated}");
        Console.WriteLine($"Number of Warriors who have turned traitor: {_numberTraitors}");
        Console.WriteLine($"Current Army Morale: {_armyMorale}");
    }

    public void removeWarrior(Warrior warrior)
    {
        _army.Remove(warrior);
    }

    public void AddUnits(Warrior warrior)
    {
        _army.Add(warrior);
    }

    public int GetNumberInjured()
    {
        return _numberInjured;
    }

    public int GetArmyMorale()
    {
        return _armyMorale;
    }

    public int GetNumberRetreated()
    {
        return _numberRetreated;
    }

    public int GetNumberDead()
    {
        return _numberDead;
    }

    public int GetArmyCount()
    {
        return _army.Count;
    }

    public Warrior GetWarrior(int index)
    {
        return _army[index];
    }

    public int GetNumberTraitors()
    {
        return _numberTraitors;
    }

    public void SetNumberTraitors(int numberTraitors)
    {
        _numberTraitors = numberTraitors;
    }

    public void SetStartingMorale()
    {
        int startingMorale = 0;
        // Calculate the initial total morale of the army.
        foreach (Warrior warrior in _army)
        {
            startingMorale += warrior.GetMorale();
        }
        _startingMorale = startingMorale;
    }

    public bool ArmyRetreatCheck()
    {
        // An army retreats if its current morale drops to one-third or less of its starting morale, or if all healthy warriors are gone.
        return (_armyMorale <= _startingMorale / 3) || _numberHealthy == 0;
    }

    public int GetNumberDeadLeaders()
    {
        int numberDeadLeaders = 0;
        // Count the number of dead warriors who are also leaders.
        foreach (Warrior warrior in _army)
        {
            if (warrior.GetIsLeader() && warrior.GetIsDead())
                numberDeadLeaders += 1;
        }
        return numberDeadLeaders;
    }

    public void ReduceMorale(int numberDeadLeaders)
    {
        // Apply a morale check to each warrior based on the number of dead leaders and have taken significant damage.
        foreach (Warrior warrior in _army)
        {
            warrior.SignificantDamageCheck(numberDeadLeaders);
        }
    }
}