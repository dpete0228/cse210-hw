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


   public Warrior(string type, int health, int attackPower, int defense, int morale){
        _type = type;
        _health = health;
        _attackPower = attackPower;
        _defense = defense;
        _morale = morale;
   }

   public virtual void Defend(int damage){
        if (damage > _defense){
            _health = _health - damage + _defense;
            _morale = _morale - damage + _defense;
            DeadCheck();
            if(_isDead == false && _deadRounds > 0){
                RetreatCheck();
            }
        }
   }

   public virtual void DeadCheck(){
        Random random = new Random();
        if(_health < 0){
            int randomInt = random.Next(50-_health);
            if(_health < 0 && randomInt != 1){
                _isDead = true;
            }else if(_health < 0 && randomInt == 1){
                randomInt = random.Next(_health*-1) + 1;
                _health = 50;
                _deadRounds = randomInt;
            }
        }
   }
   public virtual int Attack(Warrior warrior){
        int damageLow = _attackPower - 5;
        int damageHigh = _attackPower + 5;
        Random random = new Random();
        int damage = random.Next(damageLow, damageHigh);
        warrior.Defend(damage);
        return 0;
   }
   public virtual void RetreatCheck(){
        if(_morale <= 0){
            _hasRetreated = true;
        }
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
        _deadRounds=rounds;
    }

    public string GetUnitType(){
        return _type;
    }
    public void SetUnitType(string type){
        _type = type;
    }
    public bool CanAttack(){
        return !(_isDead&&_hasRetreated)&&_deadRounds == 0;
    }
}