using System;

class NephiteWarrior : Warrior
{


   public NephiteWarrior():base("Nephite Warrior", 100, 20, 10, 50){

   }
   
   public NephiteWarrior(string type, int health, int attackPower, int defense, int morale):base(type, health, attackPower, defense, morale){
    
   }



}