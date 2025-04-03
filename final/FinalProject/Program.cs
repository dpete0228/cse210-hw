using System;

class Program
{
    static void Main(string[] args)
    {
        BattleSimulator battleSimulator = new BattleSimulator();
        battleSimulator.CreateArmies();
        battleSimulator.SimulateBattle();
    }
}