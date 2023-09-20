/*class Tank
{
    int X, Y;
    string color;

    public void SetPosition(int _X, int _Y)
    {
        X = _X;
        Y = _Y;
    }

    public void SetColor(string _C)
    {
        color = _C;
    }

    public int GetX() { return X; }
    public int GetY() { return Y; }
}
class Program
{
    static void Main(string[] args)
    {
        Tank Player1 = new Tank();
        Player1.SetPosition(100, 500);
        Player1.SetColor("green");

        Tank Player2 = new Tank();
        Player2.SetPosition(500, 400);
        Player2.SetColor("red");

        Tank V1 = new Tank();
        V1.SetPosition(100, 100);
        V1.SetColor("white");

        Tank V2 = new Tank();
        V2.SetPosition(600, 100);
        V2.SetColor("white");

        Tank V3 = new Tank();
        V3.SetPosition(50, 250);
        V3.SetColor("white");



        Console.WriteLine("Please press D to move Player1");
        string read = Console.ReadLine();
        if (read == "D")
        {
            Player1.SetPosition(100, 300);
        }

        Console.WriteLine("New position after press D for Player1 is " + Player1.GetX() + " " + Player1.GetY());

        Console.ReadKey();
    }
}*/
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        new Window("Window Title... to change", 800, 600);

        SplashKit.Delay(5000);
    }
}
