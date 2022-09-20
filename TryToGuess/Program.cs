using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryToGuess
{
    enum Player
    {
        Man,
        Computer
    }
    //enum Answer
    //{
    //    Yes, No, Less, Greater
    //}
    class TryToGuess
    {
        private int minNumber;
        private int maxNumber;
        private int maxTries;
        private Player player;

        public TryToGuess(int minNumber = 1, int maxNumber = 50, int maxTries = 4, Player player = Player.Man)
        {
            this.minNumber = minNumber;
            this.maxNumber = maxNumber;
            this.maxTries = maxTries;
            this.player = player;
        }

        public void Start()
        {
            if (player == Player.Man)
            {
                ManGuesses();
            }
            else
            {
                ComputerGuesses();
            }
        }

        private void ManGuesses()
        {
            Random rand = new Random();
            int guessedNumber = rand.Next(0, maxNumber);
            int lastNumber = 0;
            int tries = 0;
            Console.WriteLine($"Let's Go! Try to guess my number from {minNumber} to {maxNumber}!");
            while (lastNumber != guessedNumber && tries < maxTries)
            {
                lastNumber = int.Parse(Console.ReadLine());
                if (lastNumber == guessedNumber)
                {
                    Console.WriteLine("Cool! You guessed my number!");
                    break;
                }
                else if (lastNumber < guessedNumber && lastNumber == guessedNumber - 1)
                {
                    Console.WriteLine("My number greater, but very close! :)");
                }
                else if (lastNumber < guessedNumber)
                {
                    Console.WriteLine("No, my number is greater! Try again.");
                }
                else if (lastNumber > guessedNumber && lastNumber == guessedNumber + 1)
                {
                    Console.WriteLine("My number less, but very close! :)");
                }
                else
                {
                    Console.WriteLine("No, my number is less.Try again.");
                }

                tries++;
                if (tries == maxTries)
                {
                    Console.WriteLine("Sorry, but it was your last chance, you lost!");
                }
            }
        }

        private void ComputerGuesses()
        {
            Console.WriteLine($"Guess a number for the computer from {minNumber} to {maxNumber}");
            int guessedNumber = 0;
            while (guessedNumber == 0)
            {
                int number = int.Parse(Console.ReadLine());
                if (number >= minNumber && number <= maxNumber)
                {
                    guessedNumber = number;
                }
            }

            int lastGuess = 0;
            int tries = 0;
            while (lastGuess != guessedNumber && tries < maxTries)
            {
                lastGuess = (maxNumber + minNumber) / 2;
                Console.WriteLine($"{lastGuess} - this number did you guess?");
                Console.WriteLine("Please enter: if YES, input 'Y'. If number is GREATER - 'G'. If number is LESS - 'L'.");

                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Console.WriteLine("I guessed your number!");
                    break;
                }
                else if (answer.ToLower() == "l")
                {
                    maxNumber = lastGuess;
                }
                else if (answer.ToLower() == "g")
                {
                    minNumber = lastGuess;
                }
                tries++;
                if (tries==maxTries)
                {
                    Console.WriteLine("I have no more attempts. You won!");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var game = new TryToGuess(1, 100, 5, Player.Man);
            game.Start();

            Console.ReadLine();
        }
    }
}
