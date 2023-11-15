using Monopoly;
using SplashKitSDK;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        GameLogic newgame = new GameLogic();
        newgame.Initialize();
        newgame.Game_Main();
        Console.ReadKey();
    }
}