using System.Linq.Expressions;
namespace NumberGuessingGame;
class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the number Guessing Game!");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("Please enter a number between 1 and 20");
        Console.WriteLine("You have got 5 chances to guess the correct number!");
        Console.WriteLine("---------------------------------------------------");
        int mysteryNum = new Random().Next(1, 21);
        int userGuess = 0;
        int chances = 1;
        Console.WriteLine("Enter your guess: ");
        while (chances <= 5)
        {
            userGuess = Convert.ToInt32(Console.ReadLine());
            if (userGuess == mysteryNum)
            {
                Console.WriteLine("Congratulations! Your guess is correct!");
                break;
            }
            else if (userGuess < mysteryNum)
            {
                if (chances == 5)
                {
                    Console.WriteLine("You have tried all your chances! ");
                    Console.WriteLine("Game Over!");
                    break;
                }
                Console.WriteLine($"You have {5 - chances} chances left");
                Console.WriteLine("Enter a greater number:");
            }
            else if (userGuess > mysteryNum)
            {
                if (chances == 5)
                {
                    Console.WriteLine("You have tried all your chances! ");
                    Console.WriteLine("Game Over!");
                    break;
                }
                Console.WriteLine($"You have {5 - chances} chances left");
                Console.WriteLine("Enter a smaller number:");
            }
            else
            {
                Console.WriteLine("You have tried all your chances! ");
                Console.WriteLine("Game Over!");
                break;
            }
            chances++;
        }
        Console.WriteLine("The correct number is:" + mysteryNum);
    }
}