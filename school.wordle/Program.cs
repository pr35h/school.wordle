using System;
using System.Collections.Generic;
using System.Linq;

class WordleGame
{
    static void Main()
    {
        string[] words = { "APPLE", "BEAST", "CLOUD", "DANCE", "ENTRY" };
        Random rand = new Random();
        int index = rand.Next(words.Length);

        string targetWord = words[index];
        int maxAttempts = 6;
        int currentAttempt = 0;

        Console.WriteLine("guess the word");

        while (currentAttempt < maxAttempts)
        {
            Console.Write($"\nattempt {currentAttempt + 1}: ");
            string guess = Console.ReadLine()?.ToUpper() ?? "";

            if (guess.Length != 5)
            {
                Console.WriteLine("5 letter words only");
                continue;
            }

            CheckGuess(guess, targetWord);

            if (guess == targetWord)
            {
                Console.WriteLine("\nyou won");
                return;
            }

            currentAttempt++;
        }

        Console.WriteLine($"\nyou lost, it was: {targetWord}");
    }

    static void CheckGuess(string guess, string target)
    {
        char[] result = new char[5]; 
        bool[] targetMatched = new bool[5];
        bool[] guessMatched = new bool[5]; 

        for (int i = 0; i < 5; i++)
        {
            if (guess[i] == target[i])
            {
                result[i] = 'G'; 
                targetMatched[i] = true;
                guessMatched[i] = true;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (guessMatched[i]) continue;

            for (int j = 0; j < 5; j++)
            {
                if (!targetMatched[j] && guess[i] == target[j])
                {
                    result[i] = 'Y';
                    targetMatched[j] = true;
                    break;
                }
            }
            if (result[i] == '\0') result[i] = 'X';
        }

        for (int i = 0; i < 5; i++)
        {
            Console.ForegroundColor = result[i] switch
            {
                'G' => ConsoleColor.Green,
                'Y' => ConsoleColor.Yellow,
                _ => ConsoleColor.Gray
            };
            Console.Write(guess[i] + " ");
        }
        Console.ResetColor();
        Console.WriteLine();
    }
}
