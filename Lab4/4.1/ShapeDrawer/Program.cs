using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            Drawing drawing = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Circle;
            Window window = new Window("Shape Drawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyDown(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                     if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }
                     else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;

                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();

                    drawing.AddShape(newShape);

                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectedShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    drawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyDown(KeyCode.DeleteKey) || SplashKit.KeyDown(KeyCode.BackspaceKey))
                {
                    foreach (Shape s in drawing.SelectedShapes)
                    {
                        drawing.RemoveShape(s);
                    }
                }

                drawing.Draw();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}