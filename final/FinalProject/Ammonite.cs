using System;

class Ammonite : Warrior
{

    //Set base stats for Ammonites
   public Ammonite():base("Ammonite", 100, 15, 10, 65, false){

   }
    public override void DeadCheck()
    {
        // Ammonites don't die. All that will happen is they get injured
        if(GetHealth() < 0){    
            Random random = new Random();
            int randomInt = random.Next(GetHealth()*-1);
            SetDeadRounds(randomInt+1);
            SetHealth(50);
        }
    }
    public override void RetreatCheck()
    {
        // Ammonites won't retreat
        SetHasRetreated(false);
    }
}