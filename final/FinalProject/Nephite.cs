using System;

class Nephite : Warrior
{


   public Nephite():base("Nephite Warrior", 100, 20, 10, 50){

   }
   
   public Nephite(string type, int health, int attackPower, int defense, int morale):base(type, health, attackPower, defense, morale){
    
   }



}