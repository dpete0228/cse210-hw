using System;

class Warrior
{
    private string _type;
    private int _health;
    private int _attackPower;
    private int _defense;
    private int _morale;
    private bool _isDead = false;
    private bool _hasRetreated = false;
    private int _deadRounds;
    private int _previousRoundHealth;
    private bool _isLeader;

    public Warrior(string type, int health, int attackPower, int defense, int morale, bool isLeader)
    {
        _type = type;
        _health = health;
        _previousRoundHealth = health; // Initialize previous round health to current health.
        _attackPower = attackPower;
        _defense = defense;
        _morale = morale;
        _isLeader = isLeader;
    }

    public virtual void Defend(int damage)
    {
        // Only apply damage if it exceeds the warrior's defense.
        if (damage > _defense)
        {
            _health = _health - damage + _defense; // Reduce health based on damage absorbed.
            DeadCheck(); // Check if the warrior has died.
            // If the warrior is not dead but is in the "dead rounds" state (temporarily incapacitated).
            if (_isDead == false && _deadRounds > 0)
            {
                RetreatCheck(); // Check if the warrior should retreat due to low morale.
            }
        }
    }

    public virtual void DeadCheck()
    {
        Random random = new Random();
        // If health drops below zero.
        if (_health < 0)
        {
            // Introduce a chance for the warrior to be temporarily incapacitated instead of immediately dying.
            int randomInt = random.Next(5 - _health); // Higher negative health increases the range.
            if (randomInt != 1)
            {
                _isDead = true; // Warrior is killed.
            }
            else if (randomInt == 1)
            {
                // Warrior is temporarily incapacitated for a random number of rounds.
                randomInt = random.Next(_health * -1) + 1; // Number of dead rounds based on how much health was lost.
                _health = 50; // Set health to a temporary value indicating incapacitated.
                _deadRounds = randomInt;
            }
        }
    }

    public virtual int Attack(Warrior warrior)
    {
        // Generate a random damage value within a range based on the attacker's attack power.
        int damageLow = _attackPower - 5;
        int damageHigh = _attackPower + 5;
        Random random = new Random();
        int damage = random.Next(damageLow, damageHigh);
        // Make the target warrior defend against the calculated damage.
        warrior.Defend(damage);
        return 0; // Return 0 for a standard attack.
    }

    public virtual void RetreatCheck()
    {
        // A warrior retreats if their morale drops to zero or below.
        if (_morale <= 0)
        {
            _hasRetreated = true;
        }
    }

        public bool CanAttack()
    {
        // A warrior can attack if they are not dead, have not retreated, and are not currently in the "dead rounds" state.
        return !(_isDead && _hasRetreated) && _deadRounds == 0;
    }

    public void SetPreviousRoundHealth()
    {
        _previousRoundHealth = _health;
    }

    public void SignificantDamageCheck(int additionalDamage)
    {
        // Check if the warrior has lost a significant portion of their health since the previous round.
        if (_health < _previousRoundHealth * 0.3) // Lost more than 70% of health in the last round.
        {
            _morale -= 10 + additionalDamage; // Decrease morale more significantly if heavy damage was taken, with an additional penalty.
        }
    }

    public bool GetIsLeader()
    {
        return _isLeader;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int value)
    {
        _health = value;
    }

    public int GetAttackPower()
    {
        return _attackPower;
    }

    public void SetAttackPower(int value)
    {
        _attackPower = value;
    }

    public int GetDefense()
    {
        return _defense;
    }

    public void SetDefense(int value)
    {
        _defense = value;
    }

    public int GetMorale()
    {
        return _morale;
    }

    public void SetMorale(int value)
    {
        _morale = value;
    }

    public bool GetIsDead()
    {
        return _isDead;
    }

    public void SetIsDead(bool value)
    {
        _isDead = value;
    }

    public bool GetHasRetreated()
    {
        return _hasRetreated;
    }

    public void SetHasRetreated(bool value)
    {
        _hasRetreated = value;
    }

    public int GetDeadRounds()
    {
        return _deadRounds;
    }

    public void SetDeadRounds(int rounds)
    {
        _deadRounds = rounds;
    }

    public string GetUnitType()
    {
        return _type;
    }

    public void SetUnitType(string type)
    {
        _type = type;
    }


}