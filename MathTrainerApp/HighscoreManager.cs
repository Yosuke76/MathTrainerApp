using System;
using System.IO;

class HighscoreManager
{
    private const string filename = "highscore.txt";

    public static int LoadHighscore(out double bestTime) // lädt Highscore
    {
        int score = 0;
        bestTime = double.MaxValue;

        if(File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            if(lines.Length >= 2)
            {
                int.TryParse(lines[0], out score);
                double.TryParse(lines[1], out bestTime);
            }
        }
        return score;
    }

    public static void SaveHighscore(int score, double time)
    {
        File.WriteAllLines(filename, new[] {score.ToString(), time.ToString()}); // speichert Highscore
    }
}
