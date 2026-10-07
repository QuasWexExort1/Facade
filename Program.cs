using System;
using GameEngine.Facades;

class Program
{
    static void Main()
    {
        GameFacade game = new GameFacade();

        game.StartNewGame();
        Console.WriteLine();

        game.PauseGame();
        Console.WriteLine();

        game.SaveGame();
        Console.WriteLine();

        game.ExitGame();

        Console.ReadLine();
    }
}
