using System;

class Ammonite : Warrior
{


   public Ammonite():base("Ammonite", 100, 15, 10, 65){

   }
   public Ammonite(string type, int health, int attackPower, int defense, int morale):base(type, health, attackPower, defense, morale){

   }
    public override void DeadCheck()
    {
        Random random = new Random();
        int randomInt = random.Next(GetHealth()) + 1;
        SetDeadRounds(randomInt+1);
    }
    public override void RetreatCheck()
    {
        SetHasRetreated(false);
    }
}