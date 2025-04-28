using System;
using System.Diagnostics;

class Questions
{
    // Einziges Random-Objekt auf Klassenebene
    private static readonly Random rand = new Random();
    
    // Konfigurierbares Zeitlimit (in Sekunden) je nach Schwierigkeitsgrad
    private static int GetTimeLimit(string difficulty)
    {
        switch (difficulty)
        {
            case "easy": return 15;
            case "standard": return 10;
            case "hard": return 8;
            default: return 10;
        }
    }

    public static bool AskMathQuestion(string difficulty)
    {
        int num1, num2, answer = 0;
        char operation = ' ';
        int rangeMin = 1, rangeMax = 20;
        int timeLimit = GetTimeLimit(difficulty);

        if (difficulty == "standard")
        {
            rangeMax = 50;
        }
        else if (difficulty == "hard")
        {
            rangeMax = 100;
        }

        num1 = rand.Next(rangeMin, rangeMax + 1);
        num2 = rand.Next(rangeMin, rangeMax + 1);
        int opChoice = rand.Next(1, 5);

        switch (opChoice)
        {
            case 1:
                operation = '+';
                answer = num1 + num2;
                break;
            case 2:
                operation = '-';
                // Bei Subtraktion sicherstellen, dass das Ergebnis nicht negativ wird
                if (num1 < num2)
                {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
                answer = num1 - num2;
                break;
            case 3:
                operation = '*';
                // Bei Multiplikation kleinere Zahlen verwenden, um das Ergebnis überschaubar zu halten
                num1 = rand.Next(rangeMin, Math.Min(rangeMax, 12) + 1);
                num2 = rand.Next(rangeMin, Math.Min(rangeMax, 12) + 1);
                answer = num1 * num2;
                break;
            case 4:
                operation = '/';
                // Für Division: Zuerst num2 wählen (nicht 0)
                num2 = rand.Next(1, Math.Min(rangeMax / 2, 10) + 1);
                // Dann num1 so wählen, dass es durch num2 teilbar ist
                num1 = num2 * rand.Next(1, rangeMax / num2 + 1);
                answer = num1 / num2;
                break;    
        }

        Console.WriteLine($"What is {num1} {operation} {num2}? (Zeit: {timeLimit} Sekunden)");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        string userInput = Console.ReadLine();
        stopwatch.Stop();

        double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
        
        if(elapsedSeconds > timeLimit)
        {
            Console.WriteLine($"Time is up! Du hast {elapsedSeconds:F1} Sekunden gebraucht (Limit: {timeLimit} Sekunden)");
            return false;
        }

        if(int.TryParse(userInput, out int userAnswer) && userAnswer == answer)
        {
            Console.WriteLine($"Richtig! Du hast {elapsedSeconds:F1} Sekunden gebraucht.");
            return true;
        }
        Console.WriteLine($"Falsch! Die richtige Antwort wäre {answer} gewesen.");
        return false;
    }
}