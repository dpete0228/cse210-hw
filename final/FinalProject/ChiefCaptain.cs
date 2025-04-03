using System;

class ChiefCaptain : Warrior
{


   public ChiefCaptain():base("Chief Captain", 150, 30, 20, 100){

   }

    public override int Attack(Warrior warrior) // Chief Captain attacks twice.
    {
        for(int i = 0; i < 2; i++){
            base.Attack(warrior);
        }
        return 0;
    }


}