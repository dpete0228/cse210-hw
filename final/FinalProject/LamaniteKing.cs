using System;

class LamaniteKing : Warrior
{

    // Initialize Lamanite King with Base Stats

   public LamaniteKing():base("Lamanite King", 100, 30, 15, 80, true){

   }

    public override void Defend(int damage)
    {
        // 1 in 5 chance to not take damage. Representing them staying at the back of the army
        Random random = new Random();
        if(random.Next(0,5) == 0){  
            base.Defend(damage);
        }
    }
}