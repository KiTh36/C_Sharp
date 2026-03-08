using System;
using System.IO;

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        string[] wordsEn = File.ReadAllLines("EN_words.txt");
        string[] wordsUa = File.ReadAllLines("UA_words.txt");
        string[] wordsDe = File.ReadAllLines("DE_words.txt");

        Console.WriteLine("Welcome to the Translator Game!");

        Console.WriteLine("Choose language you want to translate: to (UA/DE):");
        string lang = (Console.ReadLine() ?? "").ToUpper();

        string[] targetWords = lang == "UA" ? wordsUa : wordsDe;

        while (true)
        {
            int posWord = rnd.Next(0, wordsEn.Length);
            bool UserGuessed = false;
            int maxAttempts = 3;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                Console.WriteLine($"Translate this word to {lang}: {wordsEn[posWord]} ");
                string userResponse = Console.ReadLine() ?? "";

                if (userResponse.Trim().Equals(targetWords[posWord].Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("CORRECT");
                    Console.ResetColor();
                    UserGuessed = true; 
                    break; 
                }
                else
                {
                    int attemptsLeft = maxAttempts - attempt;
                    if (attemptsLeft > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"WRONG. You have {attemptsLeft} attempts left.");
                        Console.ResetColor();
                    }
                }
            }

            if (!UserGuessed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"GAME OVER for this word. The right answer was: {targetWords[posWord]}");
                Console.ResetColor();
            }
        }
    }
}