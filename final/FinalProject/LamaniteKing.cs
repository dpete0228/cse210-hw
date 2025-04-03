using System;

class LamaniteKing : Warrior
{


   public LamaniteKing():base("Lamanite King", 100, 25, 15, 80){

   }

    public override void Defend(int damage)
    {
        Random random = new Random();
        if(random.Next(0,5) == 0){  
            base.Defend(damage);
        }
    }
}