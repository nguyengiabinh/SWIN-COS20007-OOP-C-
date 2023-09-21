using SplashKitSDK;


namespace Pingpong
{
    public class Program
    {
        public static void Main()
        {
            new Window("New game", 800, 600);
            int x = 100, y = 100;
            int direction = 0;

            SplashKit.LoadSoundEffect("bell", "typical-trap-loop-140bpm-129880.mp3");
            SplashKit.LoadSoundEffect("sample1", "sunflower-street-drumloop-85bpm-163900.mp3");
            SoundEffect sound = SplashKit.SoundEffectNamed("sample1");
            sound.Play();

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.FillCircle(Color.Red, x, y, 20);
                SplashKit.DrawText("1. Bell", Color.Red, 200, 50);
                SplashKit.DrawText("2. Bell", Color.Red, 200, 60);

                double MX = SplashKit.MousePosition().X;
                double MY = SplashKit.MousePosition().Y;

                if ((MX >= 200) && (MX <= 500) && (MY >= 40) && (MY <= 60) && (SplashKit.MouseClicked(MouseButton.LeftButton)))
                {
                    sound.Stop();
                    sound = SplashKit.SoundEffectNamed("bell");
                    sound.Play();
                    Console.Write("Run bell");
                }

                if ((MX >= 200) && (MX <= 500) && (MY >= 80) && (MY <= 100) && (SplashKit.MouseClicked(MouseButton.LeftButton)))
                {
                    sound.Stop();
                    sound = SplashKit.SoundEffectNamed("sample1");
                    sound.Play();
                    Console.Write("Run bell 2");
                }
                    SplashKit.DrawText("Mouse position" + MX.ToString() + MY.ToString(), Color.Red, 100, 20);

                if (x == 400) direction = 1;
                if (x == 100) direction = 0;

                if (direction == 1) direction -= 5;
                else x += 5;

                SplashKit.Delay(20);
                SplashKit.RefreshScreen();
                SplashKit.ClearScreen();
            }
            while (!SplashKit.WindowCloseRequested("New game"));

        }
    }
}

