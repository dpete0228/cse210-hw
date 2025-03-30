using System;

class Lamanite : Warrior
{


   public Lamanite():base("Lamanite Warrior", 100, 15, 7, 40){

   }
   public Lamanite(string type, int health, int attackPower, int defense, int morale):base(type, health, attackPower, defense, morale){}
}