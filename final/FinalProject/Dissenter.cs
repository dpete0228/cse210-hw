using System;

class Dissenter : Warrior
{

    // Set base stats for Dissenters
   public Dissenter():base("Dissenter", 100, 30, 12, 60, false){

   }

    public override int Attack(Warrior warrior)
    {
        //If a dissenter is attacking a kingman, there is a chance that the kingman will become a dissenter
        if(warrior.GetUnitType() == "King Man"){
            Random random = new Random();
            KingMan kingMan = (KingMan) warrior;
            if(random.Next(0,3) == 0 && !kingMan.GetSwitchedSides()){
                kingMan.SetSwitchedSides(true);
                return -1;
            }
        }
        base.Attack(warrior);
        return 0;
    }



}