using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(){
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through slow, intentional breathing. Clear your mind and focus on each breath as you inhale deeply and exhale fully, promoting calmness and reducing stress.";
        Start();
    }
    
    public void StartBreathingActivity(){
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        bool breatheIn = true;
        while(DateTime.Now < endTime || breatheIn == false){
            if(breatheIn == true){
                Console.Write("\nBreathe in...");
            }else{
                Console.Write("\nBreathe out...");
            }
            DisplayCountdown(5);
            
            breatheIn = !breatheIn;
        }
    End();
    }
    
}