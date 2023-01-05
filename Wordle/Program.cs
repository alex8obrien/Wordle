using Lib;

namespace Wordle
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            bool gameOver;
            int score = 0, round = 0;
            
            Introduction();

            do
            {
                score += PlayGame();
                round++;

                gameOver = !StdInp.InputYNAsBool("Do you want to play again?");
            } while (!gameOver);
            
            Console.WriteLine("\nThanks for playing!");
            Console.WriteLine($"Your final score is {score} / {round}.");
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
            Console.WriteLine("If the letter is not in the word the letter will stay white.");
        }

        private static string GetSecretWord()
        {
            // ReSharper disable once InconsistentNaming
            string FILE_PATH = Directory.GetParent(Directory.GetCurrentDirectory().Split("\\bin")[0]) + "\\Wordle\\Files\\brit-a-z.txt";
            List<string> wordList = new List<string>();
            
            int limit = StdInp.InputIntInBound("\nPlease enter the length of the word you want to guess", 3, 10);

            using StreamReader reader = new(FILE_PATH);
            while ((reader.ReadLine() ?? null) is { } line)
            {
                if (line.Length == limit)
                {
                    wordList.Add(line);
                }
            }

            Random random = new();
            int index = random.Next(0, wordList.Count);
            return wordList[index];
        }

        private static int PlayGame()
        {
            string secretWord = GetSecretWord();
            int guessNumber = 0, limit = secretWord.Length;
            do
            {
                string guess = StdInp.Input("\nPlease enter your guess");

                if (guess.Length != limit)
                {
                    Console.WriteLine($"Please enter a {limit} letter word");
                    continue;
                }
                if (guess == "exit")
                {
                    Console.WriteLine("You have exited the game.");
                    return 0;
                }
                if (guess == secretWord)
                {
                    guessNumber++;
                    Console.WriteLine($"You have guessed the word correctly, in only {guessNumber} guesses!");
                    return 1;
                }

                guessNumber++;
                Console.WriteLine($"You have {6 - guessNumber} guesses left.\n");
                CompareWords(secretWord, guess);
                
            } while (guessNumber < 6);

            return 0;
        }
        
       private static void CompareWords(string secretWord, string guess)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == guess[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{secretWord[i]} ");
                    Console.ResetColor();
                }
                else if (secretWord.Contains(guess[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{guess[i]} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("_ ");
                }
            }
        }
    }
}