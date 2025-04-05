using System;

class BattleSimulator
{
    private Army _nephiteArmy = new Army("Nephite");
    private Army _lamaniteArmy = new Army("Lamanite");
    private List<Warrior> _traitorWarriors = new List<Warrior>();

    public void SimulateBattleRound(int roundCount)
    {
        int count;
        // Determine the number of iterations for this round based on the size of the larger army.
        if (_nephiteArmy.GetArmyCount() > _lamaniteArmy.GetArmyCount())
        {
            count = _nephiteArmy.GetArmyCount();
        }
        else
        {
            count = _lamaniteArmy.GetArmyCount();
        }

        // Loop through a number of times equal to the larger army size, allowing each side to attack.
        for (int i = 0; i < count; i++)
        {
            // Attempt an attack from the Nephite army against the Lamanite army.
            WarriorAttack(i, _nephiteArmy, _lamaniteArmy);
            // Attempt an attack from the Lamanite army against the Nephite army.
            WarriorAttack(i, _lamaniteArmy, _nephiteArmy);
        }

        // Process any warriors who switched sides during this round.
        foreach (Warrior warrior in _traitorWarriors)
        {
            // Remove the traitor from their original army.
            _nephiteArmy.removeWarrior(warrior);
            // Reset the 'switched sides' flag on the KingMan, in case they switch back later (though not currently implemented).
            KingMan kingMan = (KingMan)warrior;
            kingMan.SetSwitchedSides(false);
        }
        // Clear the list of traitors for the next round.
        _traitorWarriors.Clear();

        // Reduce morale of each army based on the number of their leaders that are dead.
        int numberDeadLeaders = _nephiteArmy.GetNumberDeadLeaders();
        _nephiteArmy.ReduceMorale(numberDeadLeaders);
        numberDeadLeaders = _lamaniteArmy.GetNumberDeadLeaders();
        _lamaniteArmy.ReduceMorale(numberDeadLeaders);

        // Perform checks on both armies to remove dead/retreated units and update statistics.
        _nephiteArmy.ArmyCheck();
        _lamaniteArmy.ArmyCheck();

        // Display the statistics for both armies after the round.
        Console.WriteLine($"Statistics after round {roundCount}");
        _nephiteArmy.DisplayArmyStatistics();
        _lamaniteArmy.DisplayArmyStatistics();
        Console.WriteLine("Press Enter to Continue to the next Round");
        Console.ReadLine();
        Console.Clear();
    }

    public void SimulateBattle()
    {
        int count = 0;
        // Initialize the starting morale for both armies.
        _nephiteArmy.SetStartingMorale();
        _lamaniteArmy.SetStartingMorale();

        // Continue simulating rounds until one of the armies retreats.
        do
        {
            SimulateBattleRound(count + 1);
            count += 1;
        } while (!_nephiteArmy.ArmyRetreatCheck() && !_lamaniteArmy.ArmyRetreatCheck());

        // Determine the winner based on which army triggered the retreat condition.
        if (_lamaniteArmy.ArmyRetreatCheck())
        {
            Console.WriteLine("The Lamanites have retreated. The Nephites are Victorious");
        }
        else
        {
            Console.WriteLine("The Nephites have been defeated. The Lamanites are Victorious");
        }
    }

    private void WarriorAttack(int index, Army attackingArmy, Army targetArmy)
    {
        // Check if the attacking warrior exists within the bounds of their army and if they are capable of attacking.
        if (index < attackingArmy.GetArmyCount() && attackingArmy.GetWarrior(index).CanAttack())
        {
            // Find a valid target in the opposing army.
            int target = FindValidTarget(targetArmy);
            // If a valid target was found.
            if (target != -1)
            {
                // Make the attacking warrior attack the target and check if it resulted in a side switch.
                int warriorSwitch = attackingArmy.GetWarrior(index).Attack(targetArmy.GetWarrior(target));
                // If the attack caused a King-Man to switch sides (indicated by a return value of -1).
                if (warriorSwitch == -1)
                {
                    // Increment the count of traitors in the target army.
                    targetArmy.SetNumberTraitors(targetArmy.GetNumberTraitors() + 1);
                    // Add the newly turned warrior to the attacking army.
                    attackingArmy.AddUnits(targetArmy.GetWarrior(target));
                    // Add the traitor to a temporary list to be processed at the end of the round.
                    _traitorWarriors.Add(targetArmy.GetWarrior(target));
                }
            }
        }
    }

    private int FindValidTarget(Army army)
    {
        int targetCount = army.GetArmyCount();
        Random random = new Random();
        // Attempt to find a valid target up to 10 times to avoid targeting already dead or retreated units.
        for (int attempt = 0; attempt < 10; attempt++)
        {
            // Generate a random index within the target army.
            int targetIndex = random.Next(targetCount);
            Warrior target = army.GetWarrior(targetIndex);

            // Check if the warrior at the random index is alive, has not retreated, and is not in a "dead" state for a number of rounds.
            if (!target.GetIsDead() && !target.GetHasRetreated() && target.GetDeadRounds() == 0)
            {
                // If the target is valid, return its index.
                return targetIndex;
            }
        }
        // If no valid target is found after several attempts, return -1.
        return -1;
    }

    public void CreateArmies()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the nephite lamanite battle simulator");
        Console.WriteLine("First we'll create the nephite army");
        // Loop through the different types of Nephite warriors to prompt the user for each.
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"How many {GetNephiteWarriorType(i).GetUnitType()}s are going to be in this? ");
            string userInput = Console.ReadLine();
            // Attempt to parse the user input as an integer.
            if (int.TryParse(userInput, out int unitCount))
            {
                // Create the specified number of the current Nephite unit type and add them to the Nephite army.
                for (int j = 0; j < unitCount; j++)
                {
                    _nephiteArmy.AddUnits(GetNephiteWarriorType(i));
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                i--; // Decrement i to re-prompt for the same unit type if the input was invalid.
            }
        }
        Console.WriteLine("Great! Now we'll create the lamanite army");
        // Loop through the different types of Lamanite warriors to prompt the user for each.
        for (int i = 0; i < 4; i++)
        {
            Console.Write($"How many {GetLamaniteWarriorType(i).GetUnitType()}s are going to be in this? ");
            string userInput = Console.ReadLine();
            // Attempt to parse the user input as an integer.
            if (int.TryParse(userInput, out int unitCount))
            {
                // Create the specified number of the current Lamanite unit type and add them to the Lamanite army.
                for (int j = 0; j < unitCount; j++)
                {
                    _lamaniteArmy.AddUnits(GetLamaniteWarriorType(i));
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                i--; // Decrement i to re-prompt for the same unit type if the input was invalid.
            }
        }
        Console.WriteLine("Armies created!");
        Console.WriteLine("Press Enter to begin the battle.");
        Console.ReadLine();
        Console.Clear();
    }

    public Warrior GetNephiteWarriorType(int i)
    {
        switch (i)
        {
            case 0: // Chief Captain
                return new ChiefCaptain();
            case 1: // Captain
                return new Captain();
            case 2: // Ammonite
                return new Ammonite();
            case 3: // King Man
                return new KingMan();
            default: // Nephite Warrior
                return new NephiteWarrior();
        }
    }

    public Warrior GetLamaniteWarriorType(int i)
    {
        switch (i)
        {
            case 0:
                return new LamaniteKing(); // Lamanite King
            case 1:
                return new LamaniteCommander(); // Lamanite Commander
            case 2:
                return new Dissenter(); // Dissenter
            default:
                return new LamaniteWarrior(); // Lamanite Warrior
        }
    }
}