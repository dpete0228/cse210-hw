using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int guess;
        do{
            Console.Write("What is your guess? ");
            string userInput2 = Console.ReadLine();
            guess = int.Parse(userInput2);
            if (guess == magicNumber){
                Console.WriteLine("You guessed it!");
            }else if(guess < magicNumber){
                Console.WriteLine("Higher");
            }else{
                Console.WriteLine("Lower");
            }
        }while(magicNumber != guess);  
    }
}