using Lib;

namespace Wordle
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            bool gameOver = false;
            int score = 0, round = 0;
            
            Introduction();

            do
            {
                score += PlayGame(GetSecretWord());
                round++;
                
                bool playAgain = StdInp.InputYNAsBool("Do you want to play again?");
                if (!playAgain)
                { gameOver = true; }
                
            } while (!gameOver);
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine($"Your final score is {score} over {round} rounds.");
        }

        private static void Introduction()
        {
            Console.WriteLine("Hello, welcome to the game of Wordle!");
            bool yn = StdInp.InputYNAsBool("Would you like to read the rule for Wordle?");

            if (!yn) return;

            Console.WriteLine("\nThe rules are simple, you have 6 chances to guess the secret word.");
            Console.WriteLine("If you guess the word correctly, you will get 1 point.");
            Console.WriteLine("When you want to finish, type 'exit' to exit the game and see your score.");
            Console.WriteLine("\nIf the letter is in the correct place the letter will turn green.");
            Console.WriteLine("If the letter is in the wrong place the letter will turn yellow.");
            Console.WriteLine("If the letter is not in the word the letter will stay white.\n");
        }

        private static string GetSecretWord()
        {
            string filePath = "Wordle\\Files\\brit-a-z.txt";
            int numberOfLines = FileIO.TotalLines("Wordle\\Files\\brit-a-z.txt");
            
            Random randInt = new Random();
            int randomLine = randInt.Next(1, numberOfLines);

            return FileIO.LineAt(filePath, randomLine);
        }

        private static int PlayGame(string secretWord)
        {
            return -1;
        }
    }
}