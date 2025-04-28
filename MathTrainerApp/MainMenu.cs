using System;

class MainMenu
{
    static void Main(string[] args)
    {
        ShowMenu();
    }

    public static void ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("Ready for some Calculations?!");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. Exit Game");

        Console.WriteLine("Choose an option!");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                MathTrainer.StartGame(); // zum starten des Spiels 
                break;
            case "2":
                Environment.Exit(0); // Spiel beenden
                break;
            default:
                Console.WriteLine("Invalid Input, please try again!");
                Console.ReadLine();
                ShowMenu(); // Menü erneut anzeigen
                break;
        }
    }
}