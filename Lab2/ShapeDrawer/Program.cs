using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Shape myShape = new Shape();
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                }

                if (myShape.IsAt(SplashKit.MousePosition()))
                {
                    if (SplashKit.KeyDown(KeyCode.SpaceKey))
                    {
                        myShape.Color = SplashKit.RandomRGBColor(255);
                    }
                }

                myShape.Draw();

                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}