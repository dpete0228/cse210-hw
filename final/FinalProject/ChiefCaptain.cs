using System;

class ChiefCaptain : Warrior
{

    // Initialize Chief Captain with base stats
   public ChiefCaptain():base("Chief Captain", 100, 30, 20, 100, true){

   }

    public override int Attack(Warrior warrior) // Chief Captain attacks twice.
    {
        for(int i = 0; i < 2; i++){
            base.Attack(warrior);
        }
        return 0;
    }


}