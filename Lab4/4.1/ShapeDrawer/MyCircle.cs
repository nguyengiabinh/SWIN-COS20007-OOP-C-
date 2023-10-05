using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public MyCircle(Color clr, int radius) : base(clr)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.Blue, 50)
        {

        }
        public override void Draw()
        {
            SplashKit.FillCircle(Color, X, Y, Radius);
            if (Select == true)
            {
                DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, Radius +2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(X, Y, Radius));

        }

    }

}
