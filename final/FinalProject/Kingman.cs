using System;

class KingMan : Warrior
{
    private bool _switchedSides = false;

    // Constructor for the KingMan unit, inheriting from the Warrior base class.
    // Sets the KingMan's specific stats and marks them as a leader (true for the last boolean parameter).
    public KingMan() : base("King Man", 100, 20, 30, 60, true)
    {
        // King-Men start with a 'switchedSides' status of false.
    }

    // Override of the Defend method from the Warrior base class.
    public override void Defend(int damage)
    {
        // King-Men only defend if they have not switched sides yet.
        if (_switchedSides == false)
        {
            base.Defend(damage); // Call the base class's Defend method to handle damage.
        }
        // If they have switched sides, they do not defend against their new allies (as per the game's logic).
    }

    // Method to set the 'switchedSides' status of the KingMan.
    public void SetSwitchedSides(bool switchedSides)
    {
        _switchedSides = switchedSides;
    }

    public bool GetSwitchedSides(){
      return _switchedSides;
    }
}