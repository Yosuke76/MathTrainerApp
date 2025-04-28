using System;
using System.Diagnostics;

public class MathTrainer
{
    public static void StartGame()
    {
        int numQuestions;
        int score = 0;
        string difficulty;

        int highscore = HighscoreManager.LoadHighscore(out double bestTime);

        Console.Clear();
        Console.WriteLine("Welcome to Math-Trainer!");
        Console.WriteLine("Select difficulty! (easy, standard, hard):");
        difficulty = Console.ReadLine().ToLower();

         while (difficulty != "easy" && difficulty != "standard" && difficulty != "hard")
         {
            Console.WriteLine("Invalid difficulty! Choose 'easy', 'standard' or 'hard': ");
            difficulty = Console.ReadLine().ToLower(); 
         }

         Console.WriteLine("How many questions do you want to answer?");

         int.TryParse(Console.ReadLine(), out numQuestions);

         Stopwatch totalTimer = new Stopwatch();
         totalTimer.Start();

         for(int i = 1; i <= numQuestions; i++)
         {
            bool questionCorrect = Questions.AskMathQuestion(difficulty);
            if(questionCorrect)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
         }
         totalTimer.Stop();

         double timeTaken = totalTimer.Elapsed.TotalSeconds;
         Console.WriteLine($"\nYou have anwsered {score} of {numQuestions} correct.");
         Console.WriteLine($"Time: {timeTaken:F2} seconds");

         if(score > highscore || (score == highscore && timeTaken < bestTime))
         {
            Console.WriteLine("New Highscore!");
            HighscoreManager.SaveHighscore(score, timeTaken);
         }
         else
         {
            Console.WriteLine("You did not beat the current Highscore!");
         }

         Console.WriteLine("\nPress any key to return to menu.");
         Console.ReadLine();
         MainMenu.ShowMenu();
    }
}
