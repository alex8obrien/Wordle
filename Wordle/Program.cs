using Lib;

namespace Wordle
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            bool gameOver = false;
            int score = 0;
            
            Console.WriteLine("Hello, World!");
            Introduction();

            do
            {
                string secretWord = GetSecretWord();
                score += PlayGame();
                
                bool playAgain = StdInp.InputYNAsBool("Do you want to play again?");
                if (!playAgain)
                { gameOver = true; }
                
            } while (!gameOver);
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine($"Your final score is {score}");
        }

        private static void Introduction()
        {
            Console.WriteLine("Hello, welcome to the game of Wordle!");
            bool yn = StdInp.InputYNAsBool("Would you like to read the rule for Wordle?");

            if (!yn) return;

            Console.WriteLine("The rules are simple, you have 6 chances to guess the correct word.");
            Console.WriteLine("If you guess the word correctly, you will get 1 point.");
            Console.WriteLine("If you run out of chances, you will lose 1 point.");
            Console.WriteLine("When you want to finish, type 'exit' to exit the game and see your score.");
        }

        private static string GetSecretWord()
        {
            string filePath = "Wordle\\Files\\brit-a-z.txt";
            int numberOfLines = FileIO.TotalLines("Wordle\\Files\\brit-a-z.txt");
            
            Random randInt = new Random();
            int randomLine = randInt.Next(1, numberOfLines);

            return FileIO.LineAt(filePath, randomLine);
        }

        private static int PlayGame()
        {
            return -1;
        }
    }
}