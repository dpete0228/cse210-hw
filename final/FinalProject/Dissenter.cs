using System;

class Dissenter : Warrior
{


   public Dissenter():base("Dissenter", 150, 30, 20, 75){

   }

    public override int Attack(Warrior warrior)
    {
        if(warrior.GetUnitType() == "King Man"){
            Random random = new Random();
            if(random.Next(0,3) == 0){
                return -1;
            }
        }
        base.Attack(warrior);
        return 0;
    }



}